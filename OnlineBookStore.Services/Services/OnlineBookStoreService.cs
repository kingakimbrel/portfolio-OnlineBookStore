using OnlineBookStore.CustomProxy.DataTransferObject;
using OnlineBookStore.CustomProxy.IServices;
using OnlineBookStore.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Transactions;
using OnlineBookStore.Common.Automapper;
using OnlineBookStore.DAL.Entities;
using OnlineBookStore.DAL.Dictionaries;
using OnlineBookStore.CustomProxy.DataTransferObject.Dictionaries;
using OnlineBookStore.Services.Adapters;
using OnlineBookStore.Services.Helpers;

namespace OnlineBookStore.Services.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(TransactionIsolationLevel = IsolationLevel.ReadCommitted)]
    public class OnlineBookStoreService : IOnlineBookStoreService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IDictionaryRepository _dictionaryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAdapter _adapter;

        public OnlineBookStoreService()
        {

        }
        public OnlineBookStoreService(IBookRepository bookRepository, IDictionaryRepository dictionaryRepository, IOrderRepository orderRepository, ICustomerRepository customerRepository, IAdapter adapter)
        {
            this._bookRepository = bookRepository;
            this._dictionaryRepository = dictionaryRepository;
            this._orderRepository = orderRepository;
            this._customerRepository = customerRepository;
            this._adapter = adapter;
        }

        public virtual GetBookByIdResponse GetBookById(GetBookByIdRequest request)
        {
            if (request == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            GetBookByIdResponse response = new GetBookByIdResponse();
            response.Book = _bookRepository.Get<Book>(request.BookId) == null ? new BookVO() : _bookRepository.Get<Book>(request.BookId).MapTo<BookVO>();

            return response;
        }

        public virtual GetAllBooksResponse GetAllBooks()
        {
            GetAllBooksResponse response = new GetAllBooksResponse();
            response.List = _bookRepository.GetAll<Book>().ToList().MapTo<BookVO>();

            return response;
        }

        public virtual GetBooksFromCategoryResponse GetBooksFromCategory(GetBooksFromCategoryRequest request)
        {
            if (request == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            GetBooksFromCategoryResponse response = new GetBooksFromCategoryResponse();
            response.Books = _bookRepository.GetBooksFromCategory(request.CategoryId).MapTo<BookVO>();

            return response;
        }

        public virtual GetBooksForPageResponse GetBooksForPage(GetBooksForPageRequest request)
        {
            throw new NotImplementedException();
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public virtual void SaveBook(SaveBookRequest request)
        {
            if (request == null || request.Book == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            Book book = request.Book.MapTo<Book>();
            book.Category = _dictionaryRepository.Load<CategoryDictionary>(book.Category.Id);
            book.Author = _dictionaryRepository.Load<Author>(book.Author.Id);

            _bookRepository.SaveOrUpdate(book);
        }

        public virtual GetDictionaryResponse GetCategories()
        {
            GetDictionaryResponse response = new GetDictionaryResponse();
            response.Dictionary = _dictionaryRepository.GetAll<CategoryDictionary>().MapTo<DictionaryVO>();

            return response;
        }

        public virtual GetDictionaryResponse GetAuthors()
        {
            GetDictionaryResponse response = new GetDictionaryResponse();
            response.Dictionary = _dictionaryRepository.GetAll<Author>().MapTo<DictionaryVO>();

            return response;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public virtual void SaveOrder(SaveOrderRequest request)
        {
            if (request == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            Order order = _adapter.MapOrderVoToEntity(request.OrderVO);

            ShippingDetails sDetails = _customerRepository.CheckIfExists(order.ShippingDetails);
            if (sDetails != null)
                order.ShippingDetails = sDetails;

            _orderRepository.SaveOrUpdate(order);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public virtual DeleteBookResponse DeleteBook(DeleteBookRequest request)
        {
            if (request == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            DeleteBookResponse response = new DeleteBookResponse();
            Book book = _bookRepository.Get<Book>(request.BookId);

            if (book == null)
                FaultExceptionHelper.ThrowResponseFault(new string[] { "Book does not exist in the database." });

            _bookRepository.Delete(book);
            response.Book = book.MapTo<BookVO>();

            return response;
        }

        public virtual GetAllCustomersResponse GetAllCustomers()
        {
            GetAllCustomersResponse response = new GetAllCustomersResponse();

            IList<ShippingDetails> list = _customerRepository.GetAll<ShippingDetails>();

            if (list.ToList().Count > 0)
                response.ShippingDetails = list.MapTo<ShippingDetailsVO>();
            else
                response.ShippingDetails = new List<ShippingDetailsVO>();

            return response;
        }

        public virtual GetAllOrdersResponse GetAllOrders()
        {
            GetAllOrdersResponse response = new GetAllOrdersResponse();

            IList<Order> list = _orderRepository.GetAll<Order>();

            if (list.ToList().Count > 0)
                response.Orders = list.MapTo<OrderVO>();
            else
                response.Orders = new List<OrderVO>();

            return response;
        }


        public virtual GetShippingDetailsByIdResponse GetShippingDetailsById(GetShippingDetailsByIdRequest request)
        {
            if (request == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            GetShippingDetailsByIdResponse response = new GetShippingDetailsByIdResponse();
            ShippingDetails sDetail = _customerRepository.Get<ShippingDetails>(request.ShippingDetailsId);

            if (sDetail == null)
                FaultExceptionHelper.ThrowResponseFault(new string[] { "Customer not found!" });

            response.ShippingDetails = sDetail.MapTo<ShippingDetailsVO>();

            return response;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public virtual void SaveShippingDetails(SaveShippingDetailsRequest request)
        {
            if (request.ShippingDetails == null || request == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            ShippingDetails sDetails = request.ShippingDetails.MapTo<ShippingDetails>();

            _customerRepository.SaveOrUpdate(sDetails);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public virtual DeleteShippingDetailsResponse DeleteShippingDetails(DeleteShippingDetailsRequest request)
        {
            if (request == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            DeleteShippingDetailsResponse response = new DeleteShippingDetailsResponse();

            ShippingDetails sDetail = _orderRepository.Get<ShippingDetails>(request.ShippingDetailsId);

            if (sDetail == null)
                FaultExceptionHelper.ThrowResponseFault(new string[] { "Customer not found!" });

            _customerRepository.Delete(sDetail);
            response.ShippingDetails = sDetail.MapTo<ShippingDetailsVO>();

            return response;
        }

        public virtual GetOrderByIdResponse GetOrderById(GetOrderByIdRequest request)
        {
            if (request == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            GetOrderByIdResponse response = new GetOrderByIdResponse();

            Order order = _orderRepository.Get<Order>(request.OrderId);

            if (order == null)
                FaultExceptionHelper.ThrowResponseFault(new string[] { "Order not found!" });

            response.Order = order.MapTo<OrderVO>();

            return response;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public virtual DeleteOrderResponse DeleteOrder(DeleteOrderRequest request)
        {
            if (request == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            DeleteOrderResponse response = new DeleteOrderResponse();

            Order order = _orderRepository.Get<Order>(request.OrderId);

            if (order == null)
                FaultExceptionHelper.ThrowResponseFault(new string[] { "Order not found!" });

            _orderRepository.Delete(order);
            response.Order = order.MapTo<OrderVO>();

            return response;
        }

        public virtual GetOrdersByShippingDetailsIdResponse GetOrdersByShippingDetailsId(GetOrdersByShippingDetailsIdRequest request)
        {
            if (request == null)
                FaultExceptionHelper.ThrowValidationFault(new string[] { "Request can not be empty!" });

            GetOrdersByShippingDetailsIdResponse response = new GetOrdersByShippingDetailsIdResponse();
            ShippingDetails sDetail = _customerRepository.Get<ShippingDetails>(request.ShippingDetailsId);

            if (sDetail == null)
                FaultExceptionHelper.ThrowResponseFault(new string[] { "Customer not found!" });

            response.Orders = sDetail.Orders.MapTo<OrderVO>();

            return response;
        }
    }
}
