using FubuFastPack.Domain;

namespace FubuMusicStore.Domain
{
    public class Artist : DomainEntity
    {
        public virtual int OriginalId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Slug { get; set; }
    }
}