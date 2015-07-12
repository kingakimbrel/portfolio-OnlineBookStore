using OnlineBookStore.CustomProxy.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.Common.Services;

namespace OnlineBookStore.CustomProxy.IServices
{
    [ServiceContract]
    public interface IOnlineBookStoreService
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        GetBookByIdResponse GetBookById(GetBookByIdRequest request);

        [OperationContract]
        GetAllBooksResponse GetAllBooks();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        GetBooksFromCategoryResponse GetBooksFromCategory(GetBooksFromCategoryRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        GetBooksForPageResponse GetBooksForPage(GetBooksForPageRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void SaveBook(SaveBookRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [FaultContract(typeof(ResponseFault))]
        DeleteBookResponse DeleteBook(DeleteBookRequest request);

        [OperationContract]
        GetDictionaryResponse GetAuthors();

        [OperationContract]
        GetDictionaryResponse GetCategories();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [FaultContract(typeof(ResponseFault))]
        void SaveOrder(SaveOrderRequest request);

        [OperationContract]
        GetAllCustomersResponse GetAllCustomers();

        [OperationContract]
        GetAllOrdersResponse GetAllOrders();

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [FaultContract(typeof(ResponseFault))]
        GetShippingDetailsByIdResponse GetShippingDetailsById(GetShippingDetailsByIdRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        void SaveShippingDetails(SaveShippingDetailsRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [FaultContract(typeof(ResponseFault))]
        DeleteShippingDetailsResponse DeleteShippingDetails(DeleteShippingDetailsRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [FaultContract(typeof(ResponseFault))]
        GetOrderByIdResponse GetOrderById(GetOrderByIdRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [FaultContract(typeof(ResponseFault))]
        DeleteOrderResponse DeleteOrder(DeleteOrderRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [FaultContract(typeof(ResponseFault))]
        GetOrdersByShippingDetailsIdResponse GetOrdersByShippingDetailsId(GetOrdersByShippingDetailsIdRequest request);
    }
}
