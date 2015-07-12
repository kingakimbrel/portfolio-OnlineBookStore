using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using OnlineBookStore.CustomProxy.IServices;
using OnlineBookStore.UI.Models;
using OnlineBookStore.UI.Const;
using OnlineBookStore.Common.Automapper;
using OnlineBookStore.CustomProxy.DataTransferObject;

namespace OnlineBookStore.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly IOnlineBookStoreService _onlineBookStoreService;
        public CartController() { }
        public CartController(IOnlineBookStoreService onlineBookStoreService)
        {
            this._onlineBookStoreService = onlineBookStoreService;
        }
        public RedirectToRouteResult AddToCart(Cart cart, int id, string returnUrl)
        {
            BookModel book = _onlineBookStoreService.GetBookById(new GetBookByIdRequest() { BookId = id }).Book.MapTo<BookModel>();
            if (book.Id != 0)
            {
                cart.AddItem(book, 1);
            }
            return RedirectToAction(eAction.Index, new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            BookModel book = _onlineBookStoreService.GetBookById(new GetBookByIdRequest() { BookId = id }).Book.MapTo<BookModel>();
            if (book.Id != 0)
            {
                cart.RemoveItem(book);
            }
            return RedirectToAction(eAction.Index, new { returnUrl });
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            Debug.WriteLine(returnUrl);
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public PartialViewResult CartSummary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetailsModel());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetailsModel shippingDetail)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, but your cart is empty...");
            }
            if (ModelState.IsValid)
            {
                OrderModel model = cart.BindToOrder(shippingDetail);
                _onlineBookStoreService.SaveOrder(new SaveOrderRequest() { OrderVO = model.MapTo<OrderVO>() });
                cart.Clear();

                return View("Completed");
            }
            else
            {
                //throw new Exception("Test error");
                return View(new ShippingDetailsModel());
            }
        }
    }
}
