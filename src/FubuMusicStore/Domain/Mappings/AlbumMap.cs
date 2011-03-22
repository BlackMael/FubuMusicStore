namespace FubuMusicStore.Domain.Mappings
{
    public class AlbumMap : DomainMap<Album>
    {
        public AlbumMap()
        {
            Map(x => x.AlbumId);
            Map(x => x.Title);
            Map(x => x.Price);
            Map(x => x.AlbumArtUrl);

            References(x => x.Artist);
            References(x => x.Genre);

            HasMany(x => x.OrderDetails);
        }
    }

    public class ArtistMap : DomainMap<Artist>
    {
        public ArtistMap()
        {
            Map(x => x.Name);
            Map(x => x.ArtistId);
        }
    }
    
    public class CartMap : DomainMap<Cart>
    {
        public CartMap()
        {
            Map(x => x.Count);
            Map(x => x.DateCreated);
            Map(x => x.RecordId);
            Map(x => x.CartId);

            References(x => x.Album);
        }
    }

    public class OrderMap : DomainMap<Order>
    {
        public OrderMap()
        {
            Map(x => x.OrderId);
            Map(x => x.OrderDate);
            Map(x => x.Username);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Address);
            Map(x => x.City);
            Map(x => x.State);
            Map(x => x.PostalCode);
            Map(x => x.Phone);
            Map(x => x.Email);

            HasMany(x => x.OrderDetails);
        }
    }

    public class OrderDetailMap : DomainMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Map(x => x.OrderDetailId);
            Map(x => x.Quantity);
            Map(x => x.UnitPrice);

            References(x => x.Album);
            References(x => x.Order);
        }
    }
}