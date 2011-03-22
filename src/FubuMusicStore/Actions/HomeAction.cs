using System;
using System.Collections.Generic;
using FubuFastPack.Persistence;
using FubuMusicStore.Domain;
using System.Linq;
using FubuMVC.Core.View;

namespace FubuMusicStore.Actions
{
    public class HomeAction
    {
        private readonly IRepository _repository;

        public HomeAction(IRepository repository )
        {
            _repository = repository;
        }

        public HomeViewModel Get(HomeRequest request)
        {

            var topSellingAlbums = _repository.Query<Album>()
                .Take(5)
                .ToList();

            return new HomeViewModel(){ Albums = topSellingAlbums};
        }
    }

    public class HomeRequest
    {
    }

    public class HomeViewModel
    {
        public IList<Album> Albums { get; set; }
    }

    public class HomeView : FubuPage<HomeViewModel>{}
}