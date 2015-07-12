using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.CustomProxy.DataTransferObject;

namespace OnlineBookStore.CustomProxy.IServices
{
    public class SaveShippingDetailsRequest : BaseRequest
    {
        public ShippingDetailsVO ShippingDetails { get; set; }
    }
}
