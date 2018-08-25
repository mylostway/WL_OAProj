using System;
using System.Collections.Generic;
using System.Text;

using Data;
using Data.entity;
using Data.param;
using Data.dal;
using Data.dto;
using NHibernate.Criterion;
using BLL.settings;
using BLL.util;

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
            var session = NHibernateUtil.getSession();

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
        public void AddEntity(T entity)
        {
            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();
            session.Save(entity);
            trans.Commit();
        }


        /// <summary>
        /// 增加一个列表
        /// </summary>
        /// <param name="entityList"></param>
        public void AddEntityList(List<T> entityList)
        {
            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();
            foreach (var e in entityList)
            {
                session.Save(e);
            }
            trans.Commit();
        }


        /// <summary>
        /// 更新DriverInfo
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateEntity(T entity)
        {
            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();
            session.Update(entity);
            trans.Commit();
        }


        /// <summary>
        /// 删除Entity
        /// </summary>
        /// <param name="entity"></param>
        public void DelEntity(T entity)
        {
            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();
            session.Delete(entity);
            trans.Commit();
        }

        
    }


    public abstract class CommBaseBLL<T> : BaseBLL<T,int>
        where T : BaseEntity<int>,new()
    {
        /// <summary>
        /// 删除Entity
        /// </summary>
        /// <param name="entity"></param>
        public void DelEntity(int entityID)
        {
            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();
            var entity = (new T());
            entity.Fid = entityID;
            session.Delete(entity);
            trans.Commit();
        }
    }
}
