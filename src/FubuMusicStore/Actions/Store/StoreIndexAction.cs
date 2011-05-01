using System;
using System.Collections.Generic;
using FubuFastPack.Persistence;
using FubuMusicStore.Domain;
using System.Linq;
using FubuMVC.Core;
using FubuMVC.Core.View;

namespace FubuMusicStore.Actions.Store
{
    public class StoreIndexAction
    {
        private readonly IRepository _repository;

        public StoreIndexAction(IRepository repository)
        {
            _repository = repository;
        }

        public StoreIndexViewModel Get(StoreIndexRequest request)
        {
            var albums = _repository.Query<Domain.Album>()
                .Where(x => x.Genre.Slug == request.GenreSlug)
                .ToList();

            return new StoreIndexViewModel()
                       {
                           Albums = albums
                       };
        }
    }

    public class StoreIndexRequest
    {
        [RouteInput("")]
        public string GenreSlug { get; set; }
    }

    public class StoreIndexViewModel
    {
        public virtual IEnumerable<Domain.Album> Albums { get; set; }
        
    }

    public class StoreIndexView : FubuPage<StoreIndexViewModel>{}
    public class AlbumBrowseControl : FubuControl<Domain.Album>{}
}