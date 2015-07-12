using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineBookStore.CustomProxy.DataTransferObject;
using OnlineBookStore.CustomProxy.IServices;
using OnlineBookStore.UI.Const;
using OnlineBookStore.UI.Controllers;
using OnlineBookStore.UI.Models;

namespace OnlineBookStore.UI.Tests.Controllers
{
    [TestClass]
    public class CartControllerTest : ControllerBaseTest
    {
        private CartController _sut;
        private Mock<IOnlineBookStoreService> _onlineBookStoreServiceMock;

        [TestInitialize]
        public void SetUp()
        {
            base.SetUp();
            _onlineBookStoreServiceMock = new Mock<IOnlineBookStoreService>();
            _kernel.Rebind<IOnlineBookStoreService>().ToConstant(_onlineBookStoreServiceMock.Object);
            _sut = GetControllerForTest<CartController>();
        }

        [TestMethod]
        public void Can_AddNewLines()
        {
            // Arrange - create some test products
            BookModel b1 = new BookModel { Id = 1, Title = "Book1" };
            BookModel b2 = new BookModel { Id = 2, Title = "Book2" };

            // Arrange - create a new cart
            Cart target = new Cart();

            // Act
            target.AddItem(b1, 1);
            target.AddItem(b2, 1);
            CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Book, b1);
            Assert.AreEqual(results[1].Book, b2);
        }

        [TestMethod]
        public void Can_AddQuantityForExistingLines()
        {
            // Arrange - create some test products
            BookModel b1 = new BookModel { Id = 1, Title = "Book1" };
            BookModel b2 = new BookModel { Id = 2, Title = "Book2" };

            // Arrange - create a new cart
            Cart target = new Cart();

            // Act
            target.AddItem(b1, 1);
            target.AddItem(b2, 1);
            target.AddItem(b1, 10);
            CartLine[] results = target.Lines.OrderBy(c => c.Book.Id).ToArray();
            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Quantity, 11);
            Assert.AreEqual(results[1].Quantity, 1);
        }

        [TestMethod]
        public void Checkout_WithValidCartAndShippingDetails()
        {
            // Arrange - create a cart with an item
            Cart cart = new Cart();
            BookModel b1 = new BookModel { Id = 1, Title = "Book1" };
            cart.AddItem(b1, 1);

            // Arrange shipping details
            ShippingDetailsModel shippingDetails = new ShippingDetailsModel() { FirstName = "Kinga", LastName = "Gabrysiak", Line1 = "Kozacka", City = "Gliwice", Country = "Polska", Zip = "44-105" };

            // Act - try to checkout
            ViewResult result = _sut.Checkout(cart, shippingDetails);

            // Assert - check that the order has been passed to be saved
            _onlineBookStoreServiceMock.Verify(m => m.SaveOrder(It.IsAny<SaveOrderRequest>()), Times.Once());
            // Assert - check that the method is returning the Completed view
            Assert.AreEqual(eView.Completed, result.ViewName);
            // Assert - check that we are passing a valid model to the view
            Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void Checkout_CannotWithEmptyCart()
        {
            // Arrange - create an empty cart
            Cart cart = new Cart();
            // Arrange - create shipping details
            ShippingDetailsModel shippingDetails = new ShippingDetailsModel() { FirstName = "Kinga", LastName = "Gabrysiak", Line1 = "Kozacka", City = "Gliwice", Country = "Polska", Zip = "44-105" };

            // Act
            ViewResult result = _sut.Checkout(cart, shippingDetails);

            // Assert
            _onlineBookStoreServiceMock.Verify(m => m.SaveOrder(It.IsAny<SaveOrderRequest>()), Times.Never());
            // Assert - check that the method is returning the default view
            Assert.AreEqual("", result.ViewName);
            // Assert - check that we are passing an invalid model to the view
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);

        }
    }
}
