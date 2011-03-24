using System;
using System.Collections.Generic;
using FubuFastPack.Domain;

namespace FubuMusicStore.Domain
{
    public class Order : DomainEntity
    {
        public virtual int OrderId { get; set; }
        public virtual DateTime OrderDate { get; set; }
       
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual decimal Total { get; set; }

        public virtual IList<OrderDetail> OrderDetails { get; set; }
    }
}