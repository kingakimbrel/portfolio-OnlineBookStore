﻿using OnlineBookStore.CustomProxy.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomProxy.IServices
{
    public class SaveBookRequest : BaseRequest
    {
        public BookVO Book { get; set; }
    }
}
