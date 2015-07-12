using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBookStore.CustomProxy.IServices;
using OnlineBookStore.UI.Models;
using OnlineBookStore.Common.Automapper;

namespace OnlineBookStore.UI.Controllers
{
    public class NavController : Controller
    {
        private readonly IOnlineBookStoreService _onlineBookStoreService;

        public NavController(IOnlineBookStoreService onlineBookStoreService)
        {
            this._onlineBookStoreService = onlineBookStoreService;
        }

        public PartialViewResult Menu(int category = 0)
        {
            ViewBag.CurrentCategory = category;
            IEnumerable<CategoryModel> categories = _onlineBookStoreService.GetCategories().Dictionary.MapTo<CategoryModel>();

            return PartialView(categories.OrderBy(x => x.Id));
        }

    }
}
