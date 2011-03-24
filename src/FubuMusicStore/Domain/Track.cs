using FubuFastPack.Domain;

namespace FubuMusicStore.Domain
{
    public class Track : DomainEntity
    {
        public virtual Album Album { get; set; }
        public virtual int OriginalId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Composer { get; set; }
        public virtual int Milliseconds { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual int Bytes { get; set; }
    }
}