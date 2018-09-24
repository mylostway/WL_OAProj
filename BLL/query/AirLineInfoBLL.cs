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
    public partial class AirInfoBLL : CommBaseBLL<AirLineEntity>
    {
        public override QueryResult<AirLineEntity> GetEntityById(int id)
        {
            return base.GetEntityById(id);
        }

        public override QueryResult<IList<AirLineEntity>> GetEntityList(BaseQueryParam param)
        {
            var queryParam = param as QueryAirLineInfoParam;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateHelper.getSession();

            var query2 = session.QueryOver<AirLineEntity>();

            if (null != queryParam.AirLineNo) query2.And(c => c.Fid == queryParam.AirLineNo.Value);
            if (!string.IsNullOrEmpty(queryParam.AirName)) query2.And(Restrictions.Like("Fchn_name", string.Format("%{0}%", queryParam.AirName)));            

            int rawRowCont = query2.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query2.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query2.Take(param.Take.Value);

            var retList = query2.List();

            return new QueryResult<IList<AirLineEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
