using AutoMapper;
using OnlineBookStore.CustomProxy.DataTransferObject.Dictionaries;
using OnlineBookStore.DAL.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.DAL.Entities;
using OnlineBookStore.Common.Automapper;

namespace OnlineBookStore.Services.Automapper
{
    public class DictionaryProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<DictionaryEntity, DictionaryVO>();

            Mapper.CreateMap<DictionaryVO, DictionaryEntity>();

            Mapper.CreateMap<DictionaryVO, CategoryDictionary>();

            Mapper.CreateMap<Author, DictionaryVO>().IgnoreAllNonExisting()
               .ForMember(dest => dest.Id, o => o.MapFrom(s => s.Id))
               .ForMember(dest => dest.Value, o => o.MapFrom(s => s.First + " " + s.Last));
        }
    }
}
