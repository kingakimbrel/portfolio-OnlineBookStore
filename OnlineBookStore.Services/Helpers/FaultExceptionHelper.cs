using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.Common.Services;
using OnlineBookStore.Common.Utils;

namespace OnlineBookStore.Services.Helpers
{
    public static class FaultExceptionHelper
    {
        public static void ThrowValidationFault(params string[] messages)
        {
            throw new FaultException<ValidationFault>(new ValidationFault(messages.ToList()), messages.StringJoin());
        }

        public static void ThrowResponseFault(params string[] messages)
        {
            throw new FaultException<ResponseFault>(new ResponseFault(messages.ToList()), messages.StringJoin());
        }
    }
}
