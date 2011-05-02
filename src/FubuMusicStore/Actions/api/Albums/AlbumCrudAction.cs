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
            return new EditAlbumModel(album);
       }

        public FubuContinuation Post(Album album)
        {
            return FubuContinuation.RedirectTo(new ListAlbumsRequest());
        }
    }

    public class EditAlbumRequest : IRequestBySlug
    {
        public string Slug { get; set; }
    }

    public class EditAlbumModel : EditEntityModel
    {
        public Album Album { get; set; }

        public EditAlbumModel(Album target) : base(target)
        {
            Album = target;
        }
    }

    public class Edit : FubuPage<EditAlbumModel>{}
}