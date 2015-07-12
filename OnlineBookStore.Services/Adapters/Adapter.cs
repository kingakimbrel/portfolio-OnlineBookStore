using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.CustomProxy.DataTransferObject;
using OnlineBookStore.DAL.Entities;
using OnlineBookStore.Common.Automapper;
using OnlineBookStore.DAL.Repository.Logic;

namespace OnlineBookStore.Services.Adapters
{
    public class Adapter : IAdapter
    {
        public Order MapOrderVoToEntity(OrderVO orderVO)
        {
            Order order = orderVO.MapTo<Order>();
            order.OrderItems.ToList().ForEach(x => x.Order = order);

            return order;
        }
    }
}
