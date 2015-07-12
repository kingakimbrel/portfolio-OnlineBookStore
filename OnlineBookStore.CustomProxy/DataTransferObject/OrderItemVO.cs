using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomProxy.DataTransferObject
{
    public class OrderItemVO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public BookVO Book { get; set; }
        public int Amount { get; set; }
    }
}
