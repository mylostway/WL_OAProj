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
using Data.utils;
using System.Reflection;

namespace BLL.query
{
    public class GoodsInfoBLL : CommBaseBLL<GoodsInfoEntity>
    {
        /*
        /// <summary>
        /// 获取DriverInfo列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public QueryResult<IList<GoodsInfoEntity>> GetGoodsInfoList(QueryGoodsInfoParam param)
        {
            var session = NHibernateUtil.getSession();

            var query2 = session.QueryOver<GoodsInfoEntity>();

            if (null != param.Fid) query2.And(c => c.Fid == param.Fid.Value);
            if (!string.IsNullOrEmpty(param.FChnName)) query2.And(Restrictions.Like("Fchn_name", string.Format("%{0}%", param.FChnName)));
            if(!string.IsNullOrEmpty(param.Fmark)) query2.And(Restrictions.Like("Fmark", string.Format("%{0}%", param.Fmark)));

            int rawRowCont = query2.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query2.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query2.Take(param.Take.Value);

            var retList = query2.List();

            return new QueryResult<IList<GoodsInfoEntity>>(retList, rawRowCont, retList.Count);
        }


        /// <summary>
        /// 增加Entity
        /// </summary>
        /// <param name="entity"></param>
        public void AddGoodsInfo(GoodsInfoEntity entity)
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
        public void AddGoodsInfoList(List<GoodsInfoEntity> entityList)
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


        public override QueryResult<IList<GoodsInfoEntity>> GetEntityList(BaseQueryParam param)
        {
            var queryParam = param as QueryGoodsInfoParam;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateHelper.getSession();

            var query2 = session.QueryOver<GoodsInfoEntity>();

            if (null != queryParam.Fid) query2.And(c => c.Fid == queryParam.Fid.Value);
            if (!string.IsNullOrEmpty(queryParam.FChnName)) query2.And(Restrictions.Like("Fchn_name", string.Format("%{0}%", queryParam.FChnName)));
            if (!string.IsNullOrEmpty(queryParam.Fmark)) query2.And(Restrictions.Like("Fmark", string.Format("%{0}%", queryParam.Fmark)));

            int rawRowCont = query2.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query2.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query2.Take(param.Take.Value);

            var retList = query2.List();

            return new QueryResult<IList<GoodsInfoEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
