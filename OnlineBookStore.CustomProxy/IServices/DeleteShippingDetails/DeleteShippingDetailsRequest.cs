﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomProxy.IServices
{
    public class DeleteShippingDetailsRequest : BaseRequest
    {
        public int ShippingDetailsId { get; set; }
    }
}
