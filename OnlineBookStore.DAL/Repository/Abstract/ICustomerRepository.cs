using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.DAL.Entities;

namespace OnlineBookStore.DAL.Repository.Abstract
{
    public interface ICustomerRepository : IRepository
    {
        ShippingDetails CheckIfExists(ShippingDetails sDetail);
    }
}
