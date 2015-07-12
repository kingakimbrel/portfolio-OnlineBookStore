using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookStore.UI.Infrastructure.Automapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.AddProfile<InternalProfile>();
            Mapper.AssertConfigurationIsValid();
        }
    }
}