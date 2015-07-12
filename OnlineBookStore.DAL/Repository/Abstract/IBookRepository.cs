using OnlineBookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Repository.Abstract
{
    public interface IBookRepository : IRepository
    {
        IList<Book> GetBooksOfAuthor(int authorId);
        IList<Book> GetBooksFromCategory(int categoryId);
    }
}
