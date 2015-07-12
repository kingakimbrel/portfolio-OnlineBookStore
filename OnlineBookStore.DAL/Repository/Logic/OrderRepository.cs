using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using OnlineBookStore.DAL.Repository.Abstract;

namespace OnlineBookStore.DAL.Repository.Logic
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(ISession session)
            : base(session)
        {

        }
    }
}
