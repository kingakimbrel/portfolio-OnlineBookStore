using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBookStore.Common.Automapper;
using OnlineBookStore.UI.Models;
using OnlineBookStore.CustomProxy.DataTransferObject;
using OnlineBookStore.CustomProxy.DataTransferObject.Dictionaries;
using System.Web.Mvc;

namespace OnlineBookStore.UI.Infrastructure.Automapper
{
    public class InternalProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AuthorVO, AuthorModel>().IgnoreAllNonExisting();
            Mapper.CreateMap<AuthorModel, AuthorVO>().IgnoreAllNonExisting();

            Mapper.CreateMap<BookVO, BookModel>().IgnoreAllNonExisting();
            Mapper.CreateMap<BookModel, BookVO>().IgnoreAllNonExisting();

            Mapper.CreateMap<CategoryVO, CategoryModel>().IgnoreAllNonExisting();
            Mapper.CreateMap<CategoryModel, CategoryVO>().IgnoreAllNonExisting();
            Mapper.CreateMap<DictionaryVO, CategoryModel>().IgnoreAllNonExisting();

            Mapper.CreateMap<OrderVO, OrderModel>().IgnoreAllNonExisting();
            Mapper.CreateMap<OrderModel, OrderVO>().IgnoreAllNonExisting();

            Mapper.CreateMap<OrderItemVO, OrderItemModel>().IgnoreAllNonExisting();
            Mapper.CreateMap<OrderItemModel, OrderItemVO>().IgnoreAllNonExisting();

            Mapper.CreateMap<ShippingDetailsVO, ShippingDetailsModel>().IgnoreAllNonExisting();
            Mapper.CreateMap<ShippingDetailsModel, ShippingDetailsVO>().IgnoreAllNonExisting();

            Mapper.CreateMap<CartLine, OrderItemModel>().IgnoreAllNonExisting()
                .ForMember(dest=>dest.Amount, o=>o.MapFrom(s=>s.Quantity));
            Mapper.CreateMap<OrderItemModel, CartLine>().IgnoreAllNonExisting()
                .ForMember(dest => dest.Quantity, o => o.MapFrom(s => s.Amount));


            Mapper.CreateMap<DictionaryVO, SelectListItem>().IgnoreAllNonExisting()
                .ForMember(dest => dest.Text, o => o.MapFrom(s => s.Value))
                .ForMember(dest => dest.Value, o => o.MapFrom(s => s.Id));
        }
    }
}