using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

using Data;
using Data.entity;
using Data.param;
using Data.dal;
using Data.dto;
using Data.utils;
using BLL.settings;
using BLL.util;

using NHibernate.Criterion;

namespace BLL.query
{
    public partial class DriverInfoBLL : CommBaseBLL<DriverInfoEntity>
    {
        /*
        /// <summary>
        /// 获取DriverInfo列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public QueryResult<IList<DriverInfoEntity>> GetDriverInfoList(QueryDriverInfoParams param)
        {
            var session = NHibernateUtil.getSession();

            var query2 = session.QueryOver<DriverInfoEntity>();

            if (null != param.Fid) query2.And(c => c.Fid == param.Fid.Value);
            if (!string.IsNullOrEmpty(param.FName)) query2.And(Restrictions.Like("Fname", string.Format("%{0}%", param.FName)));
            if (!string.IsNullOrEmpty(param.Fphone)) query2.And(c => c.Fphone1 == param.Fphone);
            if (!string.IsNullOrEmpty(param.Fcert)) query2.And(c => c.FcertID == param.Fcert);
            if (!string.IsNullOrEmpty(param.FdriverNo)) query2.And(c => c.FDriverNo == param.FdriverNo);
            if (null != param.FworkState) query2.And(c => c.FworkState == param.FworkState.Value);

            int rawRowCont = query2.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query2.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query2.Take(param.Take.Value);

            var retList = query2.List();      

            return new QueryResult<IList<DriverInfoEntity>>(retList, rawRowCont, retList.Count);
        }


        /// <summary>
        /// 增加DriverInfo
        /// </summary>
        /// <param name="entity"></param>
        public void AddDriverInfo(DriverInfoEntity entity)
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
        public void AddDriverInfoList(List<DriverInfoEntity> entityList)
        {
            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();            
            foreach(var e in entityList)
            {
                session.Save(e);
            }
            trans.Commit();
        }


        /// <summary>
        /// 更新DriverInfo
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateDriverInfo(DriverInfoEntity entity)
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
        public void DelDriverInfo(int entityID)
        {
            SAssert.MustTrue((0 > entityID), string.Format("非法的EntityID={0},Method={1}", entityID, MethodBase.GetCurrentMethod().Name));

            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();
            session.Delete(new DriverInfoEntity(entityID));
            trans.Commit();
        }


        /// <summary>
        /// 软删除数据
        /// </summary>
        /// <param name="entityID"></param>
        public void SoftDelDriverInfo(int entityID)
        {
            var session = NHibernateUtil.getSession();
            var trans = session.BeginTransaction();

            var delEntity = session.Get<DriverInfoEntity>(entityID, NHibernate.LockMode.Write);

            SAssert.MustTrue((null != delEntity), string.Format("没有找到要修改的Entity,ID={0},Method={1}",entityID,MethodBase.GetCurrentMethod().Name));

            if (QueryHelper.IsDataSoftDeleted(delEntity.Fstate))
            {
                // 已经是软删除状态
                return;
            }

            delEntity.Fstate = QueryHelper.SOFT_DELETED_FSTATE;

            session.Update(delEntity);

            trans.Commit();
        }
        */

        public override QueryResult<IList<DriverInfoEntity>> GetEntityList(BaseQueryParam param)
        {
            var queryParam = param as QueryDriverInfoParams;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateHelper.getSession();
            
            var query2 = session.QueryOver<DriverInfoEntity>();

            if (null != queryParam.Fid) query2.And(c => c.Fid == queryParam.Fid.Value);
            if (!string.IsNullOrEmpty(queryParam.FName)) query2.And(Restrictions.Like("Fname", string.Format("%{0}%", queryParam.FName)));
            if (!string.IsNullOrEmpty(queryParam.Fphone)) query2.And(c => c.Fphone1 == queryParam.Fphone);
            if (!string.IsNullOrEmpty(queryParam.Fcert)) query2.And(c => c.FcertID == queryParam.Fcert);
            if (!string.IsNullOrEmpty(queryParam.FdriverNo)) query2.And(c => c.FDriverNo == queryParam.FdriverNo);
            if (null != queryParam.FworkState) query2.And(c => c.FworkState == queryParam.FworkState.Value);

            int rawRowCont = query2.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query2.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query2.Take(param.Take.Value);

            var retList = query2.List();

            return new QueryResult<IList<DriverInfoEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
