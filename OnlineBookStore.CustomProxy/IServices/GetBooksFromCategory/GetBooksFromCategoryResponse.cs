using OnlineBookStore.CustomProxy.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomProxy.IServices
{
    public class GetBooksFromCategoryResponse : BaseResponse
    {
        public IList<BookVO> Books { get; set; }
    }
}
