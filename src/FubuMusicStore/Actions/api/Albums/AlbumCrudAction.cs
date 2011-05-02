using System;
using FubuFastPack.Crud;
using FubuFastPack.Domain;
using FubuMusicStore.Domain;
using FubuMVC.Core;
using FubuMVC.Core.View;

namespace FubuMusicStore.Actions.api.Albums
{
    public class AlbumCrudAction : CrudController<Album, EditAlbumModel>
    {
        public EditAlbumModel Edit(Album model)
        {
            return new EditAlbumModel(model);
        }
        
        public CreationRequest<EditAlbumModel> Create(EditAlbumModel input)
        {
            throw new NotImplementedException();
        }

        public Album New()
        {
            return new Album();
        }
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