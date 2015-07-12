using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.DAL.Repository.Abstract;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using NHibernate;

namespace OnlineBookStore.DAL.Repository.Logic
{
    public abstract class Repository
    {
        private ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        protected ISession Session
        {
            get { return session; }
        }

        public void Save(object obj)
        {
            Session.Save(obj);
        }

        public void SaveOrUpdate(object obj)
        {
            Session.SaveOrUpdate(obj);
        }

        public void Flush()
        {
            Session.Flush();
        }

        public T Get<T>(int id)
        {
            return Session.Get<T>(id);
        }

        public T Load<T>(int id)
        {
            return Session.Load<T>(id);
        }

        public IList<T> GetAll<T>() where T : class
        {
            return Session.QueryOver<T>().List();
        }

        public void Delete(object obj)
        {
            Session.Delete(obj);
        }
    }
}
