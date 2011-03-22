using System;
using System.Collections.Generic;

namespace FubuMusicStore.Domain
{
    public class Order
    {
        public virtual int OrderId { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual string Username { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        public virtual decimal Total { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}