using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookStore.UI.ViewModels
{
    public class ErrorViewModel
    {
        public string ErrorType { get; set; }

        public string ErrorDescription { get; set; }

        public string SupportEmailAddress { get; set; }

        public string MessageSubject { get; set; }

        public string MessageBody { get; set; }

        public Exception Exception { get; set; }
    }
}