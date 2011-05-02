using System;
using FubuFastPack.Crud;
using FubuFastPack.Domain;
using FubuFastPack.Persistence;
using FubuMusicStore.Domain;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.View;

namespace FubuMusicStore.Actions.api.Albums
{
    public class AlbumCrudAction 
    {
        private readonly IRepository _repository;

        public AlbumCrudAction(IRepository repository)
        {
            _repository = repository;
        }
        
        [UrlForNew(typeof(Album))]
        public EditAlbumModel Edit(EditAlbumRequest request)
       {
            var album = _repository.FindBy<Album>(x => x.Slug == request.Slug);
            return new EditAlbumModel{Album = album};
       }

        public FubuContinuation Post(EditAlbumModel album)
        {
            return FubuContinuation.RedirectTo(new ListAlbumsRequest());
        }
    }

    public class EditAlbumRequest : IRequestBySlug
    {
        public string Slug { get; set; }
    }

    public class EditAlbumModel
    {
        public Album Album { get; set; }
    }

    public class Edit : FubuPage<EditAlbumModel>{}
}