using FubuFastPack.Persistence;

namespace FubuMusicStore.Actions.api.Artists
{
    public class ListArtistsAction
    {
        private readonly IRepository _repository;

        public ListArtistsAction(IRepository repository)
        {
            _repository = repository;
        }
    }
}