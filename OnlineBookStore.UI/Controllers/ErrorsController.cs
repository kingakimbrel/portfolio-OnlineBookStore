using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBookStore.UI.Const;
using OnlineBookStore.UI.ViewModels;
using OnlineBookStore.UI.Resources;

namespace OnlineBookStore.UI.Controllers
{
    public class ErrorsController : Controller
    {
        public ErrorsController()
        {
        }

        public virtual ActionResult Forbidden(Exception exception)
        {
            var viewModel = CreateViewModel(ErrorsResources.Forbidden, ErrorsResources.ForbiddenDescription, exception);

            return View(eView.Error, viewModel);
        }

        public virtual ActionResult NotFound(Exception exception)
        {
            var viewModel = CreateViewModel(ErrorsResources.NotFound, ErrorsResources.NotFoundDescription, exception);

            return View(eView.Error, viewModel);
        }

        public virtual ActionResult InternalServerError(Exception exception)
        {
            var viewModel = CreateViewModel(ErrorsResources.InternalServerError, ErrorsResources.InternalServerErrorDescription, exception);

            return View(eView.Error, viewModel);
        }

        public virtual ActionResult Unauthorized(Exception exception)
        {
            var viewModel = CreateViewModel(ErrorsResources.Unauthorized, ErrorsResources.UnauthorizedDescription, exception);

            return View(eView.Error, viewModel);
        }


        private ErrorViewModel CreateViewModel(string errorType, string errorDescription, Exception exception)
        {
            var subject = "[" + UiResources.ApplicationName + "] " + errorType;
            var body = string.Format("W aplikacji {0} pod adresem {1} wystąpił błąd, który się powtarza. Proszę o sprawdzenie. {2}.", UiResources.ApplicationName, Request.Url, DateTime.Now);

            var viewModel = new ErrorViewModel
            {
                ErrorType = errorType,
                ErrorDescription = errorDescription,
                SupportEmailAddress = "support@mail.com",
                MessageSubject = subject,
                MessageBody = body,
                Exception = exception
            };

            return viewModel;
        }

    }
}
