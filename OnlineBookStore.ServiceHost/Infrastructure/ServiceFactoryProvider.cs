using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using OnlineBookStore.DAL.Mappings;

namespace OnlineBookStore.ServiceHost.Infrastructure
{
    public class SessionFactoryProvider
    {
        private static readonly Lazy<ISessionFactory> _sessionFactory
            = new Lazy<ISessionFactory>(CreateSessionFactory);

        private SessionFactoryProvider()
        {
        }

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory.Value; }
        }

        public static ISession CurrentSession
        {
            get { return _sessionFactory.Value.GetCurrentSession(); }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["OnlineBookStoreConnection"];
            if (connectionStringSettings == null)
                throw new ArgumentException("Nie ustawiono parametru OnlineBookStoreConnection");

            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                #if DEBUG
                .ShowSql().FormatSql()
                #endif
.ConnectionString(c => c.FromConnectionStringWithKey("OnlineBookStoreConnection")))
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<BookMap>())
                //.CurrentSessionContext<T>()
                .BuildSessionFactory();

            return sessionFactory;
        }
    }
}