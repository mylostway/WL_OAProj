using System;
using System.Collections.Generic;
using System.Text;

using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dto;
using WL_OA.Data.dal;
using WL_OA.Data.dal.Chloe;

using NHibernate;
using NHibernate.Criterion;

using BLL.settings;
using BLL.util;

//using Chloe;

namespace WL_OA.BLL.query
{
    public abstract class BaseBLL<T, S, Q>
        where T : BaseEntity<S>, new()
        where Q : BaseQueryParam
    {
        /// <summary>
        /// 根据指定ID获取实例
        /// </summary>
        /// <returns></returns>
        public virtual QueryResult<T> GetEntityById(S id)
        {
            var session = NHibernateSessionManager.GetSession();

            var queryEntity = session.Get<T>(id);

            return new QueryResult<T>(queryEntity);
        }

        /// <summary>
        /// 根据参数查找实体列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public abstract QueryResult<IList<T>> GetEntityList(Q param);

        /// <summary>
        /// 增加Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual BaseOpResult AddEntity(T entity)
        {
            try
            {
                entity.CheckValidator();

                var session = NHibernateSessionManager.GetSession();
                var trans = session.BeginTransaction();
                var id = session.Save(entity);
                trans.Commit();

                //ChloeUtil.DbContext.Insert(entity);
            }
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            
            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 增加一个列表
        /// </summary>
        /// <param name="entityList"></param>
        public virtual BaseOpResult AddEntityList(List<T> entityList, bool bIsAutomic = false)
        {
            try
            {
                var session = NHibernateSessionManager.GetSession();
                var trans = session.BeginTransaction();

                foreach (var e in entityList)
                {
                    try
                    {
                        e.CheckValidator();

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
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 更新Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual BaseOpResult UpdateEntity(T entity)
        {
            try
            {
                entity.CheckValidator();

                var session = NHibernateSessionManager.GetSession();
                var trans = session.BeginTransaction();
                session.Update(entity);
                trans.Commit();
            }
            catch(Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 删除Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual BaseOpResult DelEntity(T entity)
        {
            try
            {
                entity.CheckValidator();

                var session = NHibernateSessionManager.GetSession();
                var trans = session.BeginTransaction();
                session.Delete(entity);
                trans.Commit();
            }
            catch(Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 获取开启事务的session，用于扩展一堆之后复杂的DB操作。
        /// </summary>
        /// <returns></returns>
        public ISession StartTrans()
        {
            var session = NHibernateSessionManager.GetSession();
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


    public abstract class CommBaseBLL<T, Q> : BaseBLL<T, int, Q>
        where T : BaseEntity<int>, new()
        where Q : BaseQueryParam
    {
        /// <summary>
        /// 删除Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual BaseOpResult DelEntity(int entityID)
        {
            try
            {
                var session = NHibernateSessionManager.GetSession();
                var trans = session.BeginTransaction();
                var entity = (new T());
                entity.Fid = entityID;
                session.Delete(entity);
                trans.Commit();
            }
            catch(Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            return BaseOpResult.SucceedInstance;
        }
    }
}
