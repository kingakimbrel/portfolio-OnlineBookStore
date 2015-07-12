using OnlineBookStore.DAL.Entities;
using OnlineBookStore.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace OnlineBookStore.DAL.Repository.Logic
{
    public class BookRepository : Repository, IBookRepository
    {
        public BookRepository(ISession session)
            : base(session)
        {

        }
        public IList<Book> GetBooksOfAuthor(int authorId)
        {
            return Session.QueryOver<Book>()
                .Where(p => p.Author.Id == authorId)
                .List();
        }


        public IList<Book> GetBooksFromCategory(int categoryId)
        {
            return Session.QueryOver<Book>()
                .Where(p => p.Category.Id == categoryId || categoryId == 0)
                .List();
        }
    }
}
