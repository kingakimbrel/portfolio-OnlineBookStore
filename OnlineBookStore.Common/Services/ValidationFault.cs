using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Common.Services
{
    [DataContract]
    public class ValidationFault : ResponseFault
    {
        public ValidationFault(List<string> exceptionMessages)
            : base(exceptionMessages)
        {         
        }
    }
}
