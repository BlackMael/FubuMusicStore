using FubuFastPack.JqGrid;
using FubuMusicStore.Domain;
using FubuMVC.Core.View;

namespace FubuMusicStore.Actions.api.Albums
{
    public class ListAlbumsAction
    {
        public ListAlbumsViewModel Get(ListAlbumsRequest request)
        {
            return new ListAlbumsViewModel();   
        }
    }

    public class ListAlbumsRequest
    {
    }

    public class ListAlbumsViewModel
    {
    }

    public class AlbumGrid : RepositoryGrid<Album>
    {
        public AlbumGrid()
        {
            Show(x => x.Name);
            Show(x => x.Price);
        }
    }

    public class ListAlbums : FubuPage<ListAlbumsViewModel>{}
}