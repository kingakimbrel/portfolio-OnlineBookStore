using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBookStore.UI.Models
{
    public class CartLine
    {
        public BookModel Book { get; set; }
        public int Quantity { get; set; }
    }
}
