using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.DAL.Repository.Abstract
{
    public interface IRepository
    {
        void Save(object obj);

        void SaveOrUpdate(object obj);

        void Flush();

        T Get<T>(int id);

        T Load<T>(int id);

        IList<T> GetAll<T>() where T : class;

        void Delete(object obj);
    } 
}
