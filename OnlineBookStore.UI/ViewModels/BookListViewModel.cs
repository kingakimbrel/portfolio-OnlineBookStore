using OnlineBookStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookStore.UI.ViewModels
{
    public class BookListViewModel : BaseViewModel
    {
        public IEnumerable<BookModel> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CurrentCategory { get; set; }
    }
}