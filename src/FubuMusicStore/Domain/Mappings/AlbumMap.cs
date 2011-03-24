namespace FubuMusicStore.Domain.Mappings
{
    public class AlbumMap : DomainMap<Album>
    {
        public AlbumMap()
        {
            Map(x => x.OriginalId);
            Map(x => x.Name);
            Map(x => x.Price);
            //Map(x => x.AlbumArtUrl);

            References(x => x.Artist);
            References(x => x.Genre);

            HasMany(x => x.OrderDetails);
            Table("Albums");
        }
    }

    public class ArtistMap : DomainMap<Artist>
    {
        public ArtistMap()
        {
            Map(x => x.Name);
            Map(x => x.OriginalId);
            Table("Artists");
        }
    }
    
    //public class CartMap : DomainMap<Cart>
    //{
    //    public CartMap()
    //    {
    //        Map(x => x.Count);
    //        Map(x => x.DateCreated);
    //        Map(x => x.RecordId);
    //        Map(x => x.CartId);

    //        References(x => x.Album);

    //    }
    //}

    public class OrderMap : DomainMap<Order>
    {
        public OrderMap()
        {
            Map(x => x.OrderId);
            Map(x => x.OrderDate);
            Map(x => x.Address);
            Map(x => x.City);
            Map(x => x.State);
            Map(x => x.PostalCode);

            HasMany(x => x.OrderDetails);
            Table("Orders");
        }
    }

    public class OrderDetailMap : DomainMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Map(x => x.OriginalId);
            Map(x => x.Quantity);
            Map(x => x.UnitPrice);

           
            References(x => x.Order);
            Table("OrderDetails");
        }
    }

    public class TrackMap : DomainMap<Track>
    {
        public TrackMap()
        {
            References(x => x.Album);
            Map(x => x.Bytes);
            Map(x => x.Composer);
            Map(x => x.Milliseconds);
            Map(x => x.Name);
            Map(x => x.OriginalId);
            Map(x => x.UnitPrice);
            Table("Tracks");
        }
    }

    public class GenreMap : DomainMap<Genre>
    {
        public GenreMap()
        {
            HasMany(x => x.Albums);
            Map(x => x.OriginalId);
            Map(x => x.Slug);
            Map(x => x.Name);
            Table("Genres");
        }
    }
}