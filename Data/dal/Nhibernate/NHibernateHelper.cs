using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using WL_OA.Data.utils.tools;

using NHibernate;
using NHibernate.Cfg;

namespace WL_OA.Data.dal
{
    /// <summary>
    /// NHibernate连接管理器
    /// </summary>
    public class NHibernateSessionManager
    {
        internal class NHibernateSession
        {
            private readonly ISessionFactory sessionFactory;

            private const string HIBERNATE_CFG_FILE_NAME = "hibernate.cfg.xml";

            private static ISession curSession = null;

            internal NHibernateSession()
            {
                var cfg = new Configuration().Configure();
                sessionFactory = cfg.BuildSessionFactory();

                curSession = sessionFactory.OpenSession();
            }

            internal ISession GetSession()
            {
                return curSession;
            }

            internal void CloseSession()
            {

            }
        }

        private NHibernateSession m_session = null;

        protected static NHibernateSessionManager Instance { get; private set; } = new NHibernateSessionManager();

        private NHibernateSessionManager()
        {
            m_session = new NHibernateSession();
        }

        public static ISession GetSession()
        {
            return Instance.m_session.GetSession();
        }
    }



    /// <summary>
    /// Nhibernate的Query扩展方法，方便使用
    /// </summary>
    static class NhibernateHelper
    {
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
