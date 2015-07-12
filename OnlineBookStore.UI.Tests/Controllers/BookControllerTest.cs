using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineBookStore.CustomProxy.DataTransferObject;
using OnlineBookStore.CustomProxy.DataTransferObject.Dictionaries;
using OnlineBookStore.CustomProxy.IServices;
using OnlineBookStore.UI.Controllers;
using OnlineBookStore.UI.Models;
using OnlineBookStore.UI.ViewModels;

namespace OnlineBookStore.UI.Tests.Controllers
{
    [TestClass]
    public class BookControllerTest : ControllerBaseTest
    {
        private BookController _sut;
        private Mock<IOnlineBookStoreService> _onlineBookStoreServiceMock;

        [TestInitialize]
        public void SetUp()
        {
            base.SetUp();
            _onlineBookStoreServiceMock = new Mock<IOnlineBookStoreService>();
            _kernel.Rebind<IOnlineBookStoreService>().ToConstant(_onlineBookStoreServiceMock.Object);
            _sut = GetControllerForTest<BookController>();
        }

        [TestMethod]
        public void Index_ShouldReturnList()
        {
            // Arrange
            _onlineBookStoreServiceMock
                       .Setup(x => x.GetAllBooks())
                       .Returns(GetAllBooksResponseMock());

            // Act
            ViewResult result = _sut.Index();

            // Assert - check if return specific ViewModel object having fixed number of items 
            Assert.IsInstanceOfType(result.Model, typeof(BookListViewModel));
            Assert.AreEqual(((BookListViewModel)result.Model).Books.ToList().Count, 2);
        }

        #region RequestResponseMock
        private GetAllBooksResponse GetAllBooksResponseMock()
        {
            GetAllBooksResponse response = new GetAllBooksResponse();
            List<BookVO> books = new List<BookVO>();
            books.Add(new BookVO()
            {
                Id = 1,
                Title = "Book1",
                Category = new CategoryVO() { Id = 1 }
            });
            books.Add(new BookVO()
            {
                Id = 2,
                Title = "Book2",
                Category = new CategoryVO() { Id = 2 }
            });
            response.List = books;

            return response;
        }

        #endregion
    }
}
