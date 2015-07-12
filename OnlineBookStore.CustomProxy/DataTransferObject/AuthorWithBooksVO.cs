using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomProxy.DataTransferObject
{
    public class AuthorWithBooksVO : AuthorVO
    {
        public IList<BookVO> Books { get; set; }
    }
}
