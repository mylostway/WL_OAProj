using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;

namespace WL_OA.BLL.query.base_info
{
    public class CompanyAccountBLL : CommBaseBLL<CompanyAccountEntity, QueryCompanyAccountParam>
    {
        public override QueryResult<IList<CompanyAccountEntity>> GetEntityList(QueryCompanyAccountParam param)
        {
            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<CompanyAccountEntity>();
            
            if (!string.IsNullOrEmpty(param.Fbank_name)) query.And(Restrictions.Like("Fbank_name", string.Format("%{0}%", param.Fbank_name)));

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

            return new QueryResult<IList<CompanyAccountEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
