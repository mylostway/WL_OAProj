using System;
using System.Collections.Generic;
using System.Text;

using Data;
using Data.entity;
using Data.param;
using Data.dto;
using Data.dal;
using Data.dal.Chloe;

using NHibernate;
using NHibernate.Criterion;

using BLL.settings;
using BLL.util;

using Chloe;

namespace BLL.query
{
    public abstract class BaseBLL<T,S>
        where T : BaseEntity<S>,new()
    {
        /// <summary>
        /// 根据指定ID获取实例
        /// </summary>
        /// <returns></returns>
        public virtual QueryResult<T> GetEntityById(S id)
        {
            var session = NHibernateHelper.getSession();

            var queryEntity = session.Get<T>(id);

            return new QueryResult<T>(queryEntity);
        }

        /// <summary>
        /// 根据参数查找实体列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public abstract QueryResult<IList<T>> GetEntityList(BaseQueryParam param);

        /// <summary>
        /// 增加Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void AddEntity(T entity)
        {
            var session = NHibernateHelper.getSession();
            var trans = session.BeginTransaction();
            var id = session.Save(entity);
            trans.Commit();

            //ChloeUtil.DbContext.Insert(entity);
        }


        /// <summary>
        /// 增加一个列表
        /// </summary>
        /// <param name="entityList"></param>
        public virtual void AddEntityList(List<T> entityList, bool bIsAutomic = false)
        {
            var session = NHibernateHelper.getSession();
            var trans = session.BeginTransaction();

            foreach (var e in entityList)
            {
                try
                {
                    var id = session.Save(e);
                }
                catch (Exception ex)
                {
                    if (bIsAutomic)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
            }
            trans.Commit();

            /*
            foreach (var e in entityList)
            {
                ChloeUtil.DbContext.Insert(e);
            }
            */
        }


        /// <summary>
        /// 更新Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void UpdateEntity(T entity)
        {
            var session = NHibernateHelper.getSession();
            var trans = session.BeginTransaction();
            session.Update(entity);
            trans.Commit();
        }


        /// <summary>
        /// 删除Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void DelEntity(T entity)
        {
            var session = NHibernateHelper.getSession();
            var trans = session.BeginTransaction();
            session.Delete(entity);
            trans.Commit();
        }


        /// <summary>
        /// 获取开启事务的session，用于扩展一堆之后复杂的DB操作。
        /// </summary>
        /// <returns></returns>
        public ISession StartTrans()
        {
            var session = NHibernateHelper.getSession();
            session.BeginTransaction();
            return session;
        }


        /// <summary>
        /// 提交已经开启事务的session，StartTrans方法的补充commit
        /// </summary>
        /// <param name="session"></param>
        public void CommitOnSession(ISession session)
        {
            session.Transaction.Commit();
        }


        /// <summary>
        /// 回滚已经开启事务的session，StartTrans方法的补充rollback
        /// </summary>
        /// <param name="session"></param>
        public void RollBackOnSession(ISession session)
        {
            session.Transaction.Rollback();
        }
    }


    public abstract class CommBaseBLL<T> : BaseBLL<T,int>
        where T : BaseEntity<int>,new()
    {
        /// <summary>
        /// 删除Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void DelEntity(int entityID)
        {
            var session = NHibernateHelper.getSession();
            var trans = session.BeginTransaction();
            var entity = (new T());
            entity.Fid = entityID;
            session.Delete(entity);
            trans.Commit();
        }
    }
}
