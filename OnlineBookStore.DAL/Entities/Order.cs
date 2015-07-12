using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStore.DAL.Entities
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual DateTime? OrderDate { get; set; }
        public virtual ShippingDetails ShippingDetails { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }
    }
}