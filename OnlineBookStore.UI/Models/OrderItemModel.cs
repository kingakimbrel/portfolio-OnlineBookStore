using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookStore.UI.Models
{
    public class OrderItemModel : BaseModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public BookModel Book { get; set; }
        public int Amount { get; set; }
    }
}