using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomProxy.DataTransferObject
{
    public class OrderVO
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public ShippingDetailsVO ShippingDetails { get; set; }
        public IList<OrderItemVO> OrderItems { get; set; }
    }
}
