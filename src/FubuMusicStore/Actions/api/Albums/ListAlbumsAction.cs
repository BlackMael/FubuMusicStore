using FubuCore.Reflection;
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

    public class AlbumGrid : RepositoryGrid<Domain.Album>
    {
        public AlbumGrid()
        {
            //this.AllowCreateNew();
            this.AddColumn(new LinkColumn<Album>(ReflectionHelper.GetAccessor<Album>(x => x.Name),ReflectionHelper.GetAccessor<Album>(x => x.Slug),
                                                 typeof (EditAlbumRequest)));
            Show(x => x.Price);
        }
    }

    public class ListAlbums : FubuPage<ListAlbumsViewModel>{}
}