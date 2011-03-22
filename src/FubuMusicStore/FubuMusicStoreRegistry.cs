using FubuCore;
using FubuFastPack.NHibernate;
using FubuFastPack.StructureMap;
using FubuMVC.Core;
using FubuMVC.Core.Configuration;
using FubuMVC.StructureMap;
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

                x.For<DatabaseSettings>().Use(c =>
                                                  {
                                                      var settingsProvider = c.GetInstance<ISettingsProvider>();
                                                      return settingsProvider.SettingsFor<DatabaseSettings>();

                                                  });
                x.BootstrapNHibernate<FubuMusicStoreNHibernateRegistry>(ConfigurationBehavior.UsePersistedConfigurationIfItExists);
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