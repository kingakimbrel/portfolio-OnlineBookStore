using OnlineBookStore.CustomProxy.DataTransferObject.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.CustomProxy.DataTransferObject
{
    public class BookVO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryVO Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public AuthorVO Author { get; set; }
    }
}
