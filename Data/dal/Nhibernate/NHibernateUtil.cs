using System;
using System.Collections.Generic;
using System.Text;
using Data.utils.tools;
using NHibernate;
using NHibernate.Cfg;

namespace Data.dal
{
    public class NHibernateUtil
    {
        private static readonly ISessionFactory sessionFactory;

        private static string HibernateHbmXmlFileName = "hibernate.cfg.xml";

        private static ISession curSession = null;

        static NHibernateUtil()
        {
            var cfg = new Configuration().Configure();            
            sessionFactory = cfg.BuildSessionFactory();

            curSession = sessionFactory.OpenSession(new NHibernateHelper.NHibernateSqlInjector());            
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
    }
}
