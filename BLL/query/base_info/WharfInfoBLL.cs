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

            var query = session.QueryOver<WharfinfoEntity>();

            if (!string.IsNullOrEmpty(queryParam.Area)) query.And(Restrictions.Like("Fposition", string.Format("%{0}%", queryParam.Area)));
            if (!string.IsNullOrEmpty(queryParam.Mark)) query.And(Restrictions.Like("Fmark", string.Format("%{0}%", queryParam.Mark)));
            if (!string.IsNullOrEmpty(queryParam.Alias)) query.And(Restrictions.Like("Falias", string.Format("%{0}%", queryParam.Alias)));
            if (!string.IsNullOrEmpty(queryParam.WharfName)) query.And(Restrictions.Like("Fposition", string.Format("%{0}%", queryParam.WharfName)));

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

            return new QueryResult<IList<WharfinfoEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
