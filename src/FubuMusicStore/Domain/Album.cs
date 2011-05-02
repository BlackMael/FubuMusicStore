using System.Collections.Generic;
using FubuFastPack.Domain;
using FubuValidation;

namespace FubuMusicStore.Domain
{
    public class Album : DomainEntity
    {
        public virtual int OriginalId { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Slug { get; set; }
        public virtual string AlbumArtUrl { get; set; }
        public virtual string ArtSmall { get; set; }
        public virtual string ArtMedium { get; set; }
        public virtual string ArtLarge { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

        public virtual IList<Track> Tracks { get; set; }

        public virtual IList<OrderDetail> OrderDetails { get; set; }
    }
}