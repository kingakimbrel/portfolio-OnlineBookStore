using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.CustomProxy.DataTransferObject.Dictionaries;

namespace OnlineBookStore.CustomProxy.IServices
{
    public class GetDictionaryResponse : BaseResponse
    {
        public IList<DictionaryVO> Dictionary { get; set; }
    }
}
