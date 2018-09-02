using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using Data;
using Data.entity;
using Data.param;
using Data.dal;
using Data.dto;
using NHibernate.Criterion;
using BLL.settings;
using BLL.util;
using System.Reflection;
using Data.utils;

namespace BLL.query
{
    public class WharfInfoBLL : CommBaseBLL<WharfInfoEntity>
    {
        /*
        /// <summary>
        /// 获取WharfInfo列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public QueryResult<IList<WharfInfoEntity>> GetWharfInfoList(QueryWharfInfoParam param)
        {
            var session = NHibernateUtil.getSession();

            var query2 = session.QueryOver<WharfInfoEntity>();
            
            if (!string.IsNullOrEmpty(param.Area)) query2.And(Restrictions.Like("Fposition", string.Format("%{0}%", param.Area)));
            if (!string.IsNullOrEmpty(param.Mark)) query2.And(Restrictions.Like("Fmark", string.Format("%{0}%", param.Mark)));
            if (!string.IsNullOrEmpty(param.Alias)) query2.And(Restrictions.Like("Falias", string.Format("%{0}%", param.Alias)));
            if (!string.IsNullOrEmpty(param.WharfName)) query2.And(Restrictions.Like("Fposition", string.Format("%{0}%", param.WharfName)));

            int rawRowCont = query2.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query2.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query2.Take(param.Take.Value);

            var retList = query2.List();

            return new QueryResult<IList<WharfInfoEntity>>(retList, rawRowCont, retList.Count);
        }


        /// <summary>
        /// 增加Entity
        /// </summary>
        /// <param name="entity"></param>
        public void AddWharfInfo(WharfInfoEntity entity)
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
        public void AddWharfInfoList(List<WharfInfoEntity> entityList)
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
        public void UpdateDriverInfo(GoodsInfoEntity entity)
        {
            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();
            session.Update(entity);
            trans.Commit();
        }


        /// <summary>
        /// 删除DriverInfo
        /// </summary>
        /// <param name="entity"></param>
        public void DelDriverInfo(GoodsInfoEntity entity)
        {
            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();
            session.Delete(entity);
            trans.Commit();
        }

        /// <summary>
        /// 删除DriverInfo
        /// </summary>
        /// <param name="entity"></param>
        public void DelDriverInfo(int entityID)
        {
            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();
            session.Delete(new GoodsInfoEntity(entityID));
            trans.Commit();
        }
        */

        public override QueryResult<IList<WharfInfoEntity>> GetEntityList(BaseQueryParam param)
        {
            var queryParam = param as QueryWharfInfoParam;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateUtil.getSession();

            var query2 = session.QueryOver<WharfInfoEntity>();

            if (!string.IsNullOrEmpty(queryParam.Area)) query2.And(Restrictions.Like("Fposition", string.Format("%{0}%", queryParam.Area)));
            if (!string.IsNullOrEmpty(queryParam.Mark)) query2.And(Restrictions.Like("Fmark", string.Format("%{0}%", queryParam.Mark)));
            if (!string.IsNullOrEmpty(queryParam.Alias)) query2.And(Restrictions.Like("Falias", string.Format("%{0}%", queryParam.Alias)));
            if (!string.IsNullOrEmpty(queryParam.WharfName)) query2.And(Restrictions.Like("Fposition", string.Format("%{0}%", queryParam.WharfName)));

            int rawRowCont = query2.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query2.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query2.Take(param.Take.Value);

            var retList = query2.List();

            return new QueryResult<IList<WharfInfoEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
