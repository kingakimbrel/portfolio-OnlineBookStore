using OnlineBookStore.CustomProxy.DataTransferObject;
using OnlineBookStore.CustomProxy.IServices;
using OnlineBookStore.UI.Models;
using OnlineBookStore.UI.ViewModels;
using OnlineBookStore.Common.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBookStore.UI.Const;

namespace OnlineBookStore.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly IOnlineBookStoreService _onlineBookStoreService;
        public BookController() { }
        public BookController(IOnlineBookStoreService onlineBookStoreService)
        {
            this._onlineBookStoreService = onlineBookStoreService;
        }

        public ActionResult Home()
        {

            return View();
        }

        public ViewResult Index()
        {
            BookListViewModel model = new BookListViewModel();
            GetAllBooksResponse response = _onlineBookStoreService.GetAllBooks();
            model.Books = response.List.MapTo<BookModel>();
            return View(model);
        }

        public ViewResult List(int category = 0, int page = 1)
        {
            BookListViewModel model = new BookListViewModel
            {
                Books = _onlineBookStoreService.GetBooksFromCategory(new GetBooksFromCategoryRequest { CategoryId = category }).Books.MapTo<BookModel>(),
                CurrentCategory = category
            };
            return View(eView.Index, model);
        }
    }
}