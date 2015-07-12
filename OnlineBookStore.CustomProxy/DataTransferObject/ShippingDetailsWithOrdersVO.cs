using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomProxy.DataTransferObject
{
    public class ShippingDetailsWithOrdersVO : ShippingDetailsVO
    {
        public IList<OrderVO> Orders { get; set; }
    }
}
