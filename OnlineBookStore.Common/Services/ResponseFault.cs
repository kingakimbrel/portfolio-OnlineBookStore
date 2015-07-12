using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Common.Services
{
    [DataContract]
    public class ResponseFault : BaseFault
    {
        public ResponseFault(List<string> exceptionMessages)
        {
            this.ExceptionMessages = exceptionMessages;
        }

        [DataMember]
        public List<string> ExceptionMessages { get; set; }
    }
}
