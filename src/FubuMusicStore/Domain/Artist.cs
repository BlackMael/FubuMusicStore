using FubuFastPack.Domain;

namespace FubuMusicStore.Domain
{
    public class Artist : DomainEntity
    {
        public virtual int ArtistId { get; set; }
        public virtual string Name { get; set; }
    }
}