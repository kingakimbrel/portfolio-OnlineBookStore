using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.CustomProxy.DataTransferObject;

namespace OnlineBookStore.CustomProxy.IServices
{
    public class GetAllCustomersResponse : BaseResponse
    {
        public IList<ShippingDetailsVO> ShippingDetails { get; set; }
    }
}
