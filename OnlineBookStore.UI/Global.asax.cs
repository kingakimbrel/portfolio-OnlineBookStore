using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Elmah;
using OnlineBookStore.UI.Binders;
using OnlineBookStore.UI.Const;
using OnlineBookStore.UI.Controllers;
using OnlineBookStore.UI.Infrastructure.Automapper;
using OnlineBookStore.UI.Models;

namespace OnlineBookStore.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {

            Error += new EventHandler(MvcApplication_Error);

        }

        void MvcApplication_Error(object sender, System.EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;

            bool success = RaiseErrorSignal(exception);

            Response.Clear();


            var routeData = new RouteData();

            routeData.Values["controller"] = "Errors";
            routeData.Values["action"] = "InternalServerError";
            routeData.Values["exception"] = exception;

            Response.StatusCode = 500;

            if (httpException != null)
            {
                Response.StatusCode = httpException.GetHttpCode();

                switch (Response.StatusCode)
                {
                    case 403:
                        routeData.Values["action"] = eAction.Forbidden;
                        break;
                    case 404:
                        routeData.Values["action"] = eAction.NotFound;
                        break;
                    case 401:
                        routeData.Values["action"] = eAction.Unauthorized;
                        break;
                }
            }

            Response.TrySkipIisCustomErrors = true;
            Server.ClearError();

            var errorsController = new ErrorsController() as IController;
            var wrapper = new HttpContextWrapper(Context);
            wrapper.Response.ContentEncoding = Encoding.UTF8;
            var requestContext = new RequestContext(wrapper, routeData);
            errorsController.Execute(requestContext);

        }

        private static bool RaiseErrorSignal(Exception e)
        {
            var context = HttpContext.Current;
            if (context == null)
                return false;

            var signal = ErrorSignal.FromContext(context);
            if (signal == null)
                return false;

            signal.Raise(e, context);
            return true;
        }

        public void ErrorLog_Filtering(object sender, ExceptionFilterEventArgs e)
        {
            //if (e.Exception is FaultException<ValidationFault>)
            //    e.Dismiss();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());

            AutoMapperConfiguration.Configure();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }
    }
}