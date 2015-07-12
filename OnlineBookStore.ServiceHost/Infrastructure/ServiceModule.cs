using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Extensions.Interception.Infrastructure.Language;
using OnlineBookStore.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookStore.ServiceHost.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<OnlineBookStoreService>().ToSelf().InRequestScope().Intercept().With<ServiceInterceptor>();
        }

    }
}