using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.CustomProxy.DataTransferObject;
using OnlineBookStore.DAL.Entities;

namespace OnlineBookStore.Services.Adapters
{
    public interface IAdapter
    {
        Order MapOrderVoToEntity(OrderVO orderVO);
    }
}
