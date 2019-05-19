using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;

namespace WL_OA.BLL.query
{
    public class FeeProjectBLL : CommBaseBLL<FeeProjectEntity, QueryFeeProjectParam>
    {
        public override QueryResult<IList<FeeProjectEntity>> GetEntityList(QueryFeeProjectParam param)
        {
            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<FeeProjectEntity>();

            if (!string.IsNullOrEmpty(param.ProjName)) query.And(Restrictions.Like("Fproj_name", string.Format("%{0}%", param.ProjName)));
            if (!string.IsNullOrEmpty(param.Fmark)) query.And(Restrictions.Like("Fmark", string.Format("%{0}%", param.Fmark)));

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

            return new QueryResult<IList<FeeProjectEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
