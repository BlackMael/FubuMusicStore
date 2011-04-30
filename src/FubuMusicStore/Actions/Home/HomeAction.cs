using System;
using System.Collections.Generic;
using FubuFastPack.Persistence;
using FubuMusicStore.Domain;
using System.Linq;
using FubuMVC.Core.View;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Order = FubuMusicStore.Domain.Order;

namespace FubuMusicStore.Actions.Home
{
    public class OrderSummary
    {
        public Track Track { get; set; }
        public int OrderCount { get; set; }
    }

    public class HomeAction
    {
        private readonly IRepository _repository;
        private readonly ISession _session;

        public HomeAction(IRepository repository, ISession session )
        {
            _repository = repository;
            _session = session;
        }

        public HomeViewModel Get(HomeRequest request)
        {
            OrderSummary orderSummaryAlias = null;
            var orderCount = QueryOver.Of<OrderDetail>()
                .SelectList(list => list
                                        .SelectGroup(c => c.Track).WithAlias(() => orderSummaryAlias.Track)
                                        .SelectCount(c => c.Track).WithAlias(() => orderSummaryAlias.OrderCount))
                .TransformUsing(Transformers.AliasToBean<OrderSummary>())
                .OrderBy(Projections.Count<OrderDetail>(c => c.Track)).Desc
                .Take(request.Count);
                
                
                

            var topSellingAlbums = _session.QueryOver<Track>()
                .Fetch(x => x.Album).Eager
                .Fetch(x => x.Album.Artist).Eager
                .WithSubquery.WhereExists(orderCount)
                .Take(request.Count)
                .List();
                
                

            return new HomeViewModel(){ Tracks = topSellingAlbums};
        }
    }

    public class HomeRequest
    {
        public HomeRequest()
        {
            Count = 8;
        }

        public int Count { get; set; }
    }

    public class HomeViewModel
    {
        public IList<Track> Tracks { get; set; }
    }

    public class HomeView : FubuPage<HomeViewModel>{}
}