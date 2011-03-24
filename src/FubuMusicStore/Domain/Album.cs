using System.Collections.Generic;
using FubuFastPack.Domain;

namespace FubuMusicStore.Domain
{
    public class Album : DomainEntity
    {
        public virtual int OriginalId { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Slug { get; set; }
        public virtual string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

        public virtual IList<OrderDetail> OrderDetails { get; set; }
    }
}