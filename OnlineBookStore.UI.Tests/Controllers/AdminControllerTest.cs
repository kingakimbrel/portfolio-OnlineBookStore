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
using OnlineBookStore.UI.Controllers;
using OnlineBookStore.UI.Models;

namespace OnlineBookStore.UI.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest : ControllerBaseTest
    {
        private AdminController _sut;
        private Mock<IOnlineBookStoreService> _onlineBookStoreServiceMock;

        [TestInitialize]
        public void SetUp()
        {
            base.SetUp();
            _onlineBookStoreServiceMock = new Mock<IOnlineBookStoreService>();
            _kernel.Rebind<IOnlineBookStoreService>().ToConstant(_onlineBookStoreServiceMock.Object);
            _sut = GetControllerForTest<AdminController>();
        }

        [TestMethod]
        public void Edit_CanSaveValidChanges()
        {
            // Arrange - create a book
            BookModel book = new BookModel { Id = 1, Title = "Book1" };

            // Act - try to save the book
            ActionResult result = _sut.Edit(book);

            // Assert - check that the service was called
            _onlineBookStoreServiceMock.Verify(m => m.SaveBook(It.Is<SaveBookRequest>(
                request => request.Book.Id == book.Id)));
            // Assert - check the method result type
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Delete_CanDeleteValidBooks()
        {
            // Arrange - create a book
            BookModel book = new BookModel { Id = 1, Title = "Book1" };
            _onlineBookStoreServiceMock
                       .Setup(x => x.DeleteBook(It.Is<DeleteBookRequest>(request => request.BookId == book.Id)))
                       .Returns(DeleteBookResponseMock(book));

            // Act - delete the book
            _sut.Delete(book.Id);

            // Assert - ensure that the service method was called
            _onlineBookStoreServiceMock.Verify(m => m.DeleteBook(It.Is<DeleteBookRequest>(
                request => request.BookId == book.Id)));
        }

        #region RequestResponseMock
        private DeleteBookResponse DeleteBookResponseMock(BookModel book)
        {
            DeleteBookResponse response = new DeleteBookResponse();
            response.Book = new BookVO() { Id = book.Id, Title = book.Title };

            return response;
        }

        #endregion
    }
}
