using System.Web.Mvc;
using System.Configuration;
using System.Web;
using OnlineBookStore.UI.Const;

namespace OnlineBookStore.UI.Exstensions
{
    public static class UrlHelperExtensions
    {
        public static string Home(this UrlHelper helper)
        {
            return helper.Action(eAction.Index, eController.Book);
        }

        //public static string LogOut(this UrlHelper helper)
        //{
        //    return helper.RouteUrl("LogOut");
        //}

        public static string GetHelpLink(this UrlHelper helper)
        {
            var path = VirtualPathUtility.ToAbsolute("~/" + ConfigurationManager.AppSettings["HelpFileURL"]);
            return path;
        }
    }
}