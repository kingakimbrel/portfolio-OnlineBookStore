using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineBookStore.CustomProxy.DataTransferObject;

namespace OnlineBookStore.CustomProxy.IServices
{
    public class GetShippingDetailsByIdResponse : BaseResponse
    {
        public ShippingDetailsVO ShippingDetails { get; set; }
    }
}
