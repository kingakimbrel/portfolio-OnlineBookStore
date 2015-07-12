using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using OnlineBookStore.UI.App_Start;
using OnlineBookStore.UI.Infrastructure.Automapper;

namespace OnlineBookStore.UI.Tests.Controllers
{
    [TestClass]
    public class ControllerBaseTest
    {
        protected IKernel _kernel;

        public ControllerBaseTest()
        {
            AutoMapperConfiguration.Configure();
        }

        [TestInitialize]
        public void SetUp()
        {
            _kernel = new StandardKernel();
            _kernel = NinjectWebCommon.CreateKernel(_kernel);

            //_kernel.Rebind<ISessionWrapper>().ToConstant(new SessionMock());
            //_kernel.Rebind<IProfileWrapper>().ToConstant(new ProfileMock());
        }

        public T GetControllerForTest<T>() where T : Controller, IController
        {
            T controller = _kernel.Get<T>();
            return controller;
        }
    }
}
