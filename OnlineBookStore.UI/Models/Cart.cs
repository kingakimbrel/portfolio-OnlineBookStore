using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineBookStore.Common.Automapper;

namespace OnlineBookStore.UI.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddItem(BookModel book, int quantity)
        {
            CartLine line = lineCollection.Where(b => b.Book.Id == book.Id).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Book = book, Quantity = quantity });
            }
            else 
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveItem(BookModel book)
        {
            lineCollection.RemoveAll(b => b.Book.Id == book.Id);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Book.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public OrderModel BindToOrder(ShippingDetailsModel shippingDetails)
        {
            OrderModel model = new OrderModel();
            model.OrderDate = DateTime.Now;
            model.ShippingDetails = shippingDetails;
            model.OrderItems = this.lineCollection.MapTo<OrderItemModel>();

            return model;
        }
    }
    
}
