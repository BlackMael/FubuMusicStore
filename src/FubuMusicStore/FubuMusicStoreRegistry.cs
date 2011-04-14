using FubuCore;
using FubuFastPack.NHibernate;
using FubuFastPack.StructureMap;
using FubuMVC.Core;
using FubuMVC.Core.Configuration;
using FubuMVC.Core.Packaging;
using FubuMVC.StructureMap;
using NHibernate.Dialect;
using NHibernate.Driver;
using StructureMap;

namespace FubuMusicStore
{
    public class FubuMusicStoreRegistry : FubuRegistry
    {
        public FubuMusicStoreRegistry()
        {
            IncludeDiagnostics(true);

            Actions.IncludeTypesNamed(x => x.EndsWith("Action"));

            Views.TryToAttachWithDefaultConventions();
        }
    }

    public static class DatabaseDriver
    {
        private static IContainer _container;
        private static DatabaseSettings _settings;
        private static string FILE_NAME;

        static DatabaseDriver()
        {
            FILE_NAME = FileSystem.Combine(FubuMvcPackageFacility.GetApplicationPath(), "chinook.db");
        }
        public static void Bootstrap(bool cleanFile)
        {
            if (_container != null) return;

            _container = BootstrapContainer();
        }

        public static IContainer BootstrapContainer()
        {
          
            return new Container(x =>
            {
                x.AddRegistry(new FastPackRegistry());
                _settings = new DatabaseSettings()
                {
                    ConnectionString = "Data Source={0};Version=3;".ToFormat(FILE_NAME),
                    DialectType = typeof(SQLiteDialect),
                    ProxyFactory = "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle",
                    ShowSql = true,
                    DriverType = typeof(SQLite20Driver)
                };
                x.For<DatabaseSettings>().Use(_settings);
                x.BootstrapNHibernate<FubuMusicStoreNHibernateRegistry>(ConfigurationBehavior.AlwaysUseNewConfiguration);
                x.UseExplicitNHibernateTransactionBoundary();
            });
        }

        public static IContainer GetFullFastPackContainer()
        {
            _container = BootstrapContainer();
            _container.Configure(x =>
            {
                x.AddRegistry(new FastPackRegistry());
                x.For<IObjectConverter>().Use<ObjectConverter>();
            });


            FubuApplication.For<FubuMusicStoreRegistry>().StructureMap(() => _container).Bootstrap();

            _container.GetInstance<ISchemaWriter>().BuildSchema();

            return _container;
        }

        public static IContainer BuildWebsiteContainer()
        {
            Bootstrap(true);

            return _container;
        }

        public static IContainer ContainerWithoutDatabase()
        {
            return _container.GetNestedContainer();
        }

        public static IContainer ContainerWithDatabase()
        {
            var nested = _container.GetNestedContainer();

            var writer = nested.GetInstance<ISchemaWriter>();
            writer.BuildSchema();

            return nested;
        }

        
    }
}