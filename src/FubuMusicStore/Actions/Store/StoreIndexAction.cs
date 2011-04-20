using System;
using System.Collections.Generic;
using FubuFastPack.Persistence;
using FubuMusicStore.Domain;
using System.Linq;
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
            return new StoreIndexViewModel(){};
        }
    }

    public class StoreIndexRequest
    {
    }

    public class StoreIndexViewModel
    {
        
    }

    public class StoreIndexView : FubuPage<StoreIndexViewModel>{}
}