using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomProxy.IServices
{
    public class GetOrderByIdRequest : BaseRequest
    {
        public int OrderId { get; set; }
    }
}
