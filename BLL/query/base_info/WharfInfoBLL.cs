using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using NHibernate.Criterion;
using BLL.settings;
using BLL.util;
using System.Reflection;
using WL_OA.Data.utils;

namespace WL_OA.BLL.query
{
    public class WharfInfoBLL : CommBaseBLL<WharfinfoEntity, QueryWharfInfoParam>
    {        
        public override QueryResult<IList<WharfinfoEntity>> GetEntityList(QueryWharfInfoParam param)
        {
            var queryParam = param as QueryWharfInfoParam;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateSessionManager.GetSession();

            var query2 = session.QueryOver<WharfinfoEntity>();

            if (!string.IsNullOrEmpty(queryParam.Area)) query2.And(Restrictions.Like("Fposition", string.Format("%{0}%", queryParam.Area)));
            if (!string.IsNullOrEmpty(queryParam.Mark)) query2.And(Restrictions.Like("Fmark", string.Format("%{0}%", queryParam.Mark)));
            if (!string.IsNullOrEmpty(queryParam.Alias)) query2.And(Restrictions.Like("Falias", string.Format("%{0}%", queryParam.Alias)));
            if (!string.IsNullOrEmpty(queryParam.WharfName)) query2.And(Restrictions.Like("Fposition", string.Format("%{0}%", queryParam.WharfName)));

            int rawRowCont = query2.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query2.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query2.Take(param.Take.Value);

            var retList = query2.List();

            return new QueryResult<IList<WharfinfoEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
