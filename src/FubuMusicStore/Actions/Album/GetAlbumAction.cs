using System.Linq;
using FubuFastPack.Persistence;
using FubuMVC.Core;
using FubuMVC.Core.View;
using NHibernate;

namespace FubuMusicStore.Actions.Album
{
    public class GetAlbumAction
    {
        private readonly ISession _session;

        public GetAlbumAction(ISession session)
        {
            _session = session;
        }

        public GetAlbumViewModel Get(GetAlbumRequest request)
        {
            var album = _session.QueryOver<Domain.Album>()
                .Fetch(x => x.Artist).Eager
                .Fetch(x => x.Genre).Eager
                .Fetch(x => x.Tracks).Eager
                .Where(x => x.Slug == request.AlbumSlug)
                .FutureValue().Value;

            return new GetAlbumViewModel() {Album = album};
        }


    }

    public class GetAlbumRequest
    {
        [RouteInput]
        public string AlbumSlug { get; set; }
    }

    public class GetAlbumViewModel
    {
        public Domain.Album Album { get; set; }
    }

    public class GetAlbumView : FubuPage<GetAlbumViewModel> {}
}