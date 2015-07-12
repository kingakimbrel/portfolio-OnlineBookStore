using AutoMapper;
using OnlineBookStore.Common.Automapper;
using OnlineBookStore.CustomProxy.DataTransferObject;
using OnlineBookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.DAL.Dictionaries;
using OnlineBookStore.CustomProxy.DataTransferObject.Dictionaries;

namespace OnlineBookStore.Services.Automapper
{
    public class OnlineBookStoreProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Author, AuthorVO>().IgnoreAllNonExisting();
            Mapper.CreateMap<AuthorVO, Author>().IgnoreAllNonExisting();

            Mapper.CreateMap<Book, BookVO>().IgnoreAllNonExisting();
            Mapper.CreateMap<BookVO, Book>().IgnoreAllNonExisting();

            Mapper.CreateMap<CategoryDictionary, CategoryVO>().IgnoreAllNonExisting();
            Mapper.CreateMap<CategoryVO, CategoryDictionary>().IgnoreAllNonExisting();

            Mapper.CreateMap<Order, OrderVO>().IgnoreAllNonExisting();
            Mapper.CreateMap<OrderVO, Order>().IgnoreAllNonExisting();

            Mapper.CreateMap<OrderItem, OrderItemVO>().IgnoreAllNonExisting()
                .ForMember(dest => dest.OrderId, o => o.MapFrom(s => s.Order.Id));
            Mapper.CreateMap<OrderItemVO, OrderItem>().IgnoreAllNonExisting();

            Mapper.CreateMap<ShippingDetails, ShippingDetailsVO>().IgnoreAllNonExisting();
            Mapper.CreateMap<ShippingDetailsVO, ShippingDetails>().IgnoreAllNonExisting();

            // mapowanie dla AuthorWithBooks oraz ShippingDetailWithOrders - problem z selfrefernce
        }
    }
}
