using System.Collections.Generic;
using FubuFastPack.Domain;

namespace FubuMusicStore.Domain
{
    public class Genre : DomainEntity
    {
        public virtual int OriginalId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Slug { get; set; }
        public virtual string Description { get; set; }

        public virtual IList<Album> Albums { get; set; }
    }
}