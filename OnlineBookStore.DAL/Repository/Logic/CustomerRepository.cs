using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using OnlineBookStore.DAL.Entities;
using OnlineBookStore.DAL.Repository.Abstract;

namespace OnlineBookStore.DAL.Repository.Logic
{
    public class CustomerRepository : Repository, ICustomerRepository
    {
        public CustomerRepository(ISession session)
            : base(session)
        {

        }

        public ShippingDetails CheckIfExists(ShippingDetails sDetail)
        {
            return Session.QueryOver<ShippingDetails>()
                .Where(x => x.FirstName == sDetail.FirstName 
                    && x.LastName == sDetail.LastName 
                    && x.Line1 == sDetail.Line1 
                    && x.Line2 == sDetail.Line2 
                    && x.Line3 == sDetail.Line3 
                    && x.City == sDetail.City 
                    && x.Country == sDetail.Country)
                .List().FirstOrDefault();
        }
    }
}
