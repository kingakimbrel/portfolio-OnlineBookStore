using Ninject.Modules;
using Ninject.Web.Common;
using OnlineBookStore.DAL.Repository.Abstract;
using OnlineBookStore.DAL.Repository.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using OnlineBookStore.DAL.Repository;
using NHibernate;
using OnlineBookStore.Services.Adapters;

namespace OnlineBookStore.ServiceHost.Infrastructure
{
    public class RepositoryModule : NinjectModule
    {

        public override void Load()
        {
            Bind<ISession>().ToMethod(c => SessionFactoryProvider.SessionFactory.OpenSession()).InRequestScope();
            Bind<IBookRepository>().To<BookRepository>().InRequestScope();
            Bind<IDictionaryRepository>().To<DictionaryRepository>().InRequestScope();
            Bind<IOrderRepository>().To<OrderRepository>().InRequestScope();
            Bind<ICustomerRepository>().To<CustomerRepository>().InRequestScope();

            Bind<IAdapter>().To<Adapter>().InRequestScope();
        }

    }
}