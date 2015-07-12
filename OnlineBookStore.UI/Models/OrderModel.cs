using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBookStore.UI.Models
{
    public class OrderModel
    {
        [Display(Name = "Id.")]
        public int Id { get; set; }
        [Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; }
        public ShippingDetailsModel ShippingDetails { get; set; }
        public IList<OrderItemModel> OrderItems { get; set; }

        public decimal ComputeTotalValue()
        {
            return OrderItems.Sum(x => x.Book.Price * x.Amount);
        }
    }
}