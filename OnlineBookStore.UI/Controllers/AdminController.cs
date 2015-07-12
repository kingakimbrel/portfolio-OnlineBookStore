using OnlineBookStore.CustomProxy.IServices;
using OnlineBookStore.UI.Const;
using OnlineBookStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBookStore.Common.Automapper;
using OnlineBookStore.UI.ViewModels;
using OnlineBookStore.CustomProxy.DataTransferObject;
using OnlineBookStore.UI.Resources;
using System.Diagnostics;

namespace OnlineBookStore.UI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IOnlineBookStoreService _onlineBookStoreService;

        public AdminController() { }

        public AdminController(IOnlineBookStoreService onlineBookStoreService)
        {
            this._onlineBookStoreService = onlineBookStoreService;
        }

        public ActionResult Index()
        {
            BookListViewModel model = new BookListViewModel();
            GetAllBooksResponse response = _onlineBookStoreService.GetAllBooks();
            model.Books = response.List.MapTo<BookModel>();
            return View(model);
        }

        public ActionResult Edit(int bookId)
        {
            if (bookId > 0)
            {
                GetBookByIdResponse response = _onlineBookStoreService.GetBookById(new GetBookByIdRequest { BookId = bookId });
                BookModel book = response.Book.MapTo<BookModel>();

                ViewData["Categories"] = LoadCategories();
                ViewData["Authors"] = LoadAuthors();
                return View(book);
            }
            else
            {
                throw new ArgumentNullException(string.Join(ErrorsResources.InternalServerError,
                    string.Format(ErrorsResources.MissingParameter, "bookId")));
            }
        }

        [HttpPost]
        public ActionResult Edit(BookModel book)
        {
            if (ModelState.IsValid)
            {
                _onlineBookStoreService.SaveBook(new SaveBookRequest() { Book = book.MapTo<BookVO>() });

                if (book.Id > 0)
                    TempData["message"] = string.Format("{0}[{1}] has been updated.", book.Title, book.Id);
                else
                    TempData["message"] = string.Format("{0} has been added.", book.Title);

                return RedirectToAction(eAction.Index);
            }
            else
            {
                ViewData["Categories"] = LoadCategories();
                ViewData["Authors"] = LoadAuthors();
                return View(book);
            }
        }

        public ViewResult Create()
        {
            ViewData["Categories"] = LoadCategories();
            ViewData["Authors"] = LoadAuthors();
            return View(eView.Edit, new BookModel());
        }

        [HttpPost]
        public ActionResult Delete(int bookId)
        {
            if (bookId > 0)
            {
                DeleteBookResponse response = _onlineBookStoreService.DeleteBook(new DeleteBookRequest() { BookId = bookId });
                if (response.Book != null)
                {
                    TempData["message"] = string.Format("{0}[{1}] has been deleted.", response.Book.Title, response.Book.Id);
                }
                return RedirectToAction(eAction.Index);
            }
            else
            {
                throw new ArgumentNullException(string.Join(ErrorsResources.InternalServerError,
                    string.Format(ErrorsResources.MissingParameter, "bookId")));
            }
        }

        public ActionResult Customers()
        {
            GetAllCustomersResponse response = _onlineBookStoreService.GetAllCustomers();

            if (response.ShippingDetails.Count > 0)
                return View(response.ShippingDetails.MapTo<ShippingDetailsModel>());
            else
                return View();
        }

        public ActionResult Orders()
        {
            GetAllOrdersResponse response = _onlineBookStoreService.GetAllOrders();

            if (response.Orders.Count > 0)
            {
                List<OrderModel> list = response.Orders.MapTo<OrderModel>();
                return View(list);
            }
            else
            {
                return View();
            }
        }

        // View details of specyfic order or all customer's orders
        public ActionResult Details(int? orderId, int? customerId)
        {
            List<OrderModel> list = new List<OrderModel>();

            if (orderId > 0)
            {
                GetOrderByIdResponse response = _onlineBookStoreService.GetOrderById(
                    new GetOrderByIdRequest() { OrderId = (int)orderId });

                OrderModel model = response.Order.MapTo<OrderModel>();
                list.Add(model);

                return View(list);
            }
            else if (customerId > 0)
            {
                GetOrdersByShippingDetailsIdResponse res = _onlineBookStoreService.GetOrdersByShippingDetailsId(
                    new GetOrdersByShippingDetailsIdRequest() { ShippingDetailsId = (int)customerId });

                list = res.Orders.MapTo<OrderModel>();
                return View(list);
            }
            else
            {
                throw new ArgumentNullException(string.Join(ErrorsResources.InternalServerError,
                    string.Format(ErrorsResources.MissingParameter, "orderId")));
            }
        }

        public ViewResult Main()
        {
            return View();
        }

        public ViewResult EditCustomer(int shippingDetailsId)
        {
            if (shippingDetailsId > 0)
            {
                GetShippingDetailsByIdResponse response = _onlineBookStoreService.GetShippingDetailsById(
                    new GetShippingDetailsByIdRequest { ShippingDetailsId = shippingDetailsId });

                ShippingDetailsModel shippingDetails = response.ShippingDetails.MapTo<ShippingDetailsModel>();

                return View(shippingDetails);
            }
            else
            {
                throw new ArgumentNullException(string.Join(ErrorsResources.InternalServerError,
                    string.Format(ErrorsResources.MissingParameter, "shippingDetailsId")));
            }
        }
        [HttpPost]
        public ActionResult EditCustomer(ShippingDetailsModel sd)
        {
            if (ModelState.IsValid)
            {
                _onlineBookStoreService.SaveShippingDetails(
                    new SaveShippingDetailsRequest() { ShippingDetails = sd.MapTo<ShippingDetailsVO>() });

                TempData["message"] = string.Format("Customer [{0} {1}] has been updated", sd.FirstName, sd.LastName);

                return RedirectToAction(eAction.Customers);

            }
            else
            {
                return View(sd);
            }
        }
        [HttpPost]
        public ActionResult DeleteCustomer(int shippingDetailsId)
        {
            if (shippingDetailsId > 0)
            {
                GetOrdersByShippingDetailsIdResponse res = _onlineBookStoreService.GetOrdersByShippingDetailsId(
                    new GetOrdersByShippingDetailsIdRequest() { ShippingDetailsId = shippingDetailsId });

                if (res.Orders.ToList().Count > 0)
                {
                    TempData["message"] = string.Format("[{0} {1}] has some orders in database. Deleting is impossible.",
                        res.Orders.FirstOrDefault().ShippingDetails.FirstName, res.Orders.FirstOrDefault().ShippingDetails.LastName);
                }
                else
                {
                    DeleteShippingDetailsResponse response = _onlineBookStoreService.DeleteShippingDetails(
                        new DeleteShippingDetailsRequest() { ShippingDetailsId = shippingDetailsId });

                    if (response.ShippingDetails != null)
                    {
                        TempData["message"] = string.Format("Customer [{0} {1}] has been deleted.",
                            response.ShippingDetails.FirstName, response.ShippingDetails.LastName);
                    }
                }

                return RedirectToAction(eAction.Customers);
            }
            else
            {
                throw new ArgumentNullException(string.Join(ErrorsResources.InternalServerError,
                    string.Format(ErrorsResources.MissingParameter, "shippingDetailsId")));
            }
        }

        #region Navigation
        public ActionResult Menu(string category = null)
        {
            if (!category.Equals(null))
            {
                if (category.Equals("Books"))
                {
                    return RedirectToAction(eAction.Index);
                }
                else
                {
                    if (category.Equals("Orders"))
                    {
                        return RedirectToAction(eAction.Orders);
                    }
                    else
                    {
                        return RedirectToAction(eAction.Customers);
                    }
                }
            }
            else
            {
                return RedirectToAction(eAction.Main);
            }

        }

        public PartialViewResult NavBar(string category = null)
        {
            ViewBag.CurrentCategory = category;
            string[] categories = { "Books", "Orders", "Customers" };
            return PartialView(eView.Menu, categories);
        }
        #endregion

        #region Private Methods
        private List<SelectListItem> LoadCategories()
        {
            List<SelectListItem> categories = _onlineBookStoreService.GetCategories().Dictionary.MapTo<SelectListItem>();
            return categories;
        }

        private List<SelectListItem> LoadAuthors()
        {
            List<SelectListItem> categories = _onlineBookStoreService.GetAuthors().Dictionary.MapTo<SelectListItem>();
            return categories;
        }
        #endregion
    }
}