using FubuFastPack.Domain;

namespace FubuMusicStore.Domain
{
    public class OrderDetail : DomainEntity
    {
        public virtual int OriginalId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }

        public virtual Track Track { get; set; }
        public virtual Order Order { get; set; }
    }
}