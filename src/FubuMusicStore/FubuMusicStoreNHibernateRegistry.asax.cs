using FubuFastPack.NHibernate;
using FubuMusicStore.Domain.Mappings;

namespace FubuMusicStore
{
    public class FubuMusicStoreNHibernateRegistry : NHibernateRegistry
    {
        public FubuMusicStoreNHibernateRegistry(DatabaseSettings settings)
        {
            SetProperties(settings.GetProperties());
            MappingsFromAssembly(typeof(AlbumMap).Assembly);
        }
    }

    
}