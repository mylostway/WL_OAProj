using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Data.utils.tools;

using NHibernate;
using NHibernate.Cfg;

namespace Data.dal
{
    public static class NHibernateHelper
    {
        private static readonly ISessionFactory sessionFactory;

        private static string HibernateHbmXmlFileName = "hibernate.cfg.xml";

        private static ISession curSession = null;

        static NHibernateHelper()
        {
            var cfg = new Configuration().Configure();            
            sessionFactory = cfg.BuildSessionFactory();

            curSession = sessionFactory.OpenSession(new utils.tools.NHibernateHelper.NHibernateSqlInjector());            
        }

        public static ISessionFactory getSessionFactory()
        {
            return sessionFactory;
        }

        public static ISession getSession()
        {
            //return sessionFactory.OpenSession(new NHibernateHelper.NHibernateSqlInjector());
            return curSession;
        }

        public static void closeSessionFactory()
        {

        }

        public static void WhereIfNotNull<T, S>(this IQueryOver<T, T> query, S obj, Expression<Func<T, bool>> exp)
        {
            if (null != obj)
            {
                query.And(exp);
            }
        }


        public static void WhereIf<T>(this IQueryOver<T, T> query, bool condition, Expression<Func<T, bool>> exp)
        {
            if (condition)
            {
                query.And(exp);
            }
        }


        public static void WhereIfStrNotEmpty<T>(this IQueryOver<T, T> query, string strVal, Expression<Func<T, bool>> exp)
        {
            if (!string.IsNullOrEmpty(strVal))
            {
                query.And(exp);
            }
        }
    }

}
