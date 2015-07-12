using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Services.Automapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.AddProfile<OnlineBookStoreProfile>();
            Mapper.AddProfile<DictionaryProfile>();

            Mapper.AssertConfigurationIsValid();
        }
    }
}
