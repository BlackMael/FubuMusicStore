using FubuFastPack.NHibernate;

namespace FubuMusicStore
{
    public class FubuMusicStoreNHibernateRegistry : NHibernateRegistry
    {
        public FubuMusicStoreNHibernateRegistry(DatabaseSettings settings)
        {
            SetProperties(settings.GetProperties());
            MappingFromThisAssembly();
        }
    }

    
}