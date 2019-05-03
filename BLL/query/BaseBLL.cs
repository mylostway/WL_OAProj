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
using WL_OA.Data;
using WL_OA.Data.dal.Cache;

//using Chloe;

namespace WL_OA.BLL
{
    /// <summary>
    /// 基础业务类
    /// </summary>
    public abstract class BaseBLL : IRequestContext, IBLL
    {
        /// <summary>
        /// 请求上下文
        /// </summary>
        private SysRequestContext m_requestContext = null;

        /// <summary>
        /// 请求服务注册器
        /// </summary>
        private IServiceProvider m_serviceProvider = null;

        /// <summary>
        /// 缓存服务
        /// </summary>
        protected ICacheContext m_cache;


        /// <summary>
        /// 默认缓存失效时间
        /// </summary>
        const double DEFAULT_CACHE_EXPIRE_MIN = 10;


        /// <summary>
        /// 获取默认缓存失效时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDefaultCacheExpireTime()
        {
            return DateTime.Now.AddMinutes(DEFAULT_CACHE_EXPIRE_MIN);
        }


        /// <summary>
        /// 获取请求上下文
        /// </summary>
        /// <returns></returns>
        public SysRequestContext GetRequestContext()
        {
            return m_requestContext;
        }

        /// <summary>
        /// 设置请求上下文
        /// </summary>
        /// <param name="context"></param>
        public void SetRequestContext(SysRequestContext context)
        {
            m_requestContext = context;
        }


        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="C">要获取的服务类型</typeparam>
        /// <returns></returns>
        public C GetServices<C>()
            where C : class
        {
            return m_serviceProvider?.GetService(typeof(C)) as C;
        }


        /// <summary>
        /// 设置服务提供者
        /// </summary>
        /// <param name="sp"></param>
        public void SetServicesProvider(IServiceProvider sp)
        {
            m_serviceProvider = sp;
        }
    }


    /// <summary>
    /// 基础实现的查询业务逻辑
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="Q"></typeparam>
    public abstract class SimpleBaseBLL<T, S, Q> : BaseBLL
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
                entity.IsValid();

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
        /// <param name="bIsAutomic">是否原子操作（目前仅仅表示，如果批量操作中有一个失败则全部回退，默认false）</param>
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
                        e.IsValid();
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
        /// 增加一个列表，传入已经开启事务的session（相当于封装一个简便函数而已）
        /// </summary>
        /// <param name="entityList"></param>
        public virtual BaseOpResult AddEntityList<W>(ISession session, IList<W> entityList, bool bIsAutomic = false)
            where W : BaseEntity<int>, new()
        {
            if (null == entityList || 0 == entityList.Count) return new BaseOpResult();

            try
            {
                foreach (var e in entityList)
                {
                    try
                    {
                        e.IsValid();
                        var id = session.Save(e);
                    }
                    catch (Exception ex)
                    {
                        if (bIsAutomic)
                        {
                            throw ex;
                        }
                    }
                }

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
                entity.IsValid();
                var session = NHibernateSessionManager.GetSession();
                var trans = session.BeginTransaction();
                session.Update(entity, entity.Fid);
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
                entity.IsValid();

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
        /// 软删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual BaseOpResult SoftDelEntity(T entity)
        {
            try
            {
                //entity.IsValid();

                var session = NHibernateSessionManager.GetSession();
                var trans = session.BeginTransaction();
                var queryEntity = session.Get<T>(entity.Fid);
                if (null == queryEntity) return new BaseOpResult(QueryResultCode.Failed, "要废弃的记录不存在");
                if(queryEntity.Fstate != 0)
                {
                    queryEntity.Fstate = 0;
                    session.Update(queryEntity);
                    trans.Commit();
                }
            }
            catch (Exception ex)
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


        /// <summary>
        /// 检查当前请求的用户是否有权限做xx操作（简单封装）
        /// </summary>
        /// <param name="opID"></param>
        /// <returns></returns>
        public virtual bool CanUserDo(string opID,string opUser = "")
        {
            if(opUser.NullOrEmpty()) opUser = GetRequestContext().LoginInfo.Account;

            return GetServices<IAssessRight>()?.CanUserDo(opUser, opID) == true;
        }
    }


    /// <summary>
    /// 目前使用查询业务逻辑
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Q"></typeparam>
    public abstract class CommBaseBLL<T, Q> : SimpleBaseBLL<T, int, Q>
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


        /// <summary>
        /// 软删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual BaseOpResult SoftDelEntity(int entityID)
        {
            try
            {
                //entity.IsValid();

                var session = NHibernateSessionManager.GetSession();
                var trans = session.BeginTransaction();
                var queryEntity = session.Get<T>(entityID);
                if (null == queryEntity) return new BaseOpResult(QueryResultCode.Failed, "要废弃的记录不存在");
                if (queryEntity.Fstate != 0)
                {
                    queryEntity.Fstate = 0;
                    session.Update(queryEntity);
                    trans.Commit();
                }
            }
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            return BaseOpResult.SucceedInstance;
        }
    }
}
