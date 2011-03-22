using System.Collections.Generic;
using FubuFastPack.Domain;

namespace FubuMusicStore.Domain
{
    public class Album : DomainEntity
    {
        public virtual int AlbumId { get; set; }
        public virtual string Title { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}