using OnlineBookStore.DAL.Dictionaries;
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
    public class DictionaryRepository : Repository, IDictionaryRepository
    {
        public DictionaryRepository(ISession session)
            : base(session)
        {

        }

    }
}
