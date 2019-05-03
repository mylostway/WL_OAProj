using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.utils;
using BLL.settings;
using BLL.util;

using NHibernate.Criterion;

namespace WL_OA.BLL.query
{
    public partial class DriverInfoBLL : CommBaseBLL<DriverinfoEntity,QueryDriverInfoParams>
    {
        public override QueryResult<IList<DriverinfoEntity>> GetEntityList(QueryDriverInfoParams param)
        {
            var queryParam = param as QueryDriverInfoParams;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<DriverinfoEntity>();

            if (null != queryParam.Fid) query.And(c => c.Fid == queryParam.Fid.Value);
            if (!string.IsNullOrEmpty(queryParam.Fname)) query.And(Restrictions.Like("Fname", string.Format("%{0}%", queryParam.Fname)));
            if (!string.IsNullOrEmpty(queryParam.Fphone)) query.And(c => c.Fphone1 == queryParam.Fphone);
            if (!string.IsNullOrEmpty(queryParam.Fcert)) query.And(c => c.FcertID == queryParam.Fcert);
            if (!string.IsNullOrEmpty(queryParam.FdriverNo)) query.And(c => c.FdriverCardNo == queryParam.FdriverNo);
            if (null != queryParam.FworkState) query.And(c => c.FworkState == queryParam.FworkState.Value);

            int rawRowCont = query.RowCount();

            query.OrderBy((x) => x.Fid).Desc();

            var pageIdx = param.GetFixedQueryPageIndex();
            var pageSize = param.GetFixedQueryPageSize();
            if (pageIdx > 1)
            {
                query.Skip((pageIdx - 1) * pageSize);
            }
            query.Take(pageSize);

            var retList = query.List();

            return new QueryResult<IList<DriverinfoEntity>>(retList, rawRowCont, retList.Count);
        }



        /*
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


    }
}
