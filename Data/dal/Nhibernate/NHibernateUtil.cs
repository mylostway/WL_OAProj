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
            //cfg.SetProperty("characterEncoding", "GBK");
            sessionFactory = cfg.BuildSessionFactory();

            curSession = sessionFactory.OpenSession(new NHibernateHelper.NHibernateSqlInjector());

            var query = curSession.CreateSQLQuery("SET character_set_client=gbk");
            var nRet = query.ExecuteUpdate();

            query = curSession.CreateSQLQuery("SET character_set_connection=gbk");
            nRet = query.ExecuteUpdate();

            query = curSession.CreateSQLQuery("SET character_set_database=utf8");
            nRet = query.ExecuteUpdate();

            query = curSession.CreateSQLQuery("SET character_set_results=gbk");
            nRet = query.ExecuteUpdate();

            query = curSession.CreateSQLQuery("SET character_set_server=gbk");
            nRet = query.ExecuteUpdate();

            curSession.Flush(); 

            query = curSession.CreateSQLQuery("show variables like '%char%'");
            var list = query.List();
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
