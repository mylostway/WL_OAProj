using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using WL_OA.Data;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using NHibernate.Criterion;
using BLL.settings;
using BLL.util;
using WL_OA.Data.utils;
using System.Reflection;

namespace WL_OA.BLL.query
{
    public partial class AirLineInfoBLL : CommBaseBLL<AirwayEntity, QueryAirLineInfoParam>
    {
        public override QueryResult<AirwayEntity> GetEntityById(int id)
        {
            return base.GetEntityById(id);
        }

        public override QueryResult<IList<AirwayEntity>> GetEntityList(QueryAirLineInfoParam param)
        {
            var queryParam = param;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateSessionManager.GetSession();

            var query2 = session.QueryOver<AirwayEntity>();

            if (null != param.AirLineNo) query2.And(c => c.Fid == queryParam.AirLineNo.Value);
            if (!string.IsNullOrEmpty(queryParam.AirName)) query2.And(Restrictions.Like("Fchn_name", string.Format("%{0}%", queryParam.AirName)));            

            int rawRowCont = query2.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query2.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query2.Take(param.Take.Value);

            var retList = query2.List();

            return new QueryResult<IList<AirwayEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
