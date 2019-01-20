using BLL.util;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OA.BLL.query.system
{
    public class CompanySystemInfoBLL : CommBaseBLL<CompanySystemInfoEntity, QueryCompanySystemInfoParam>
    {
        public override QueryResult<IList<CompanySystemInfoEntity>> GetEntityList(QueryCompanySystemInfoParam param)
        {
            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<CompanySystemInfoEntity>();

            query.WhereIfNotEmpty(param.CompanyName, x => x.Fname == param.CompanyName);

            int rawRowCont = query.RowCount();

            if (param.IsAllowPagging)
            {
                QueryHelper.FixQueryTake(param, rawRowCont);

                if (null != param.Skip && param.Skip.Value > 0) query.Skip(param.Skip.Value);
                if (null != param.Take && param.Take.Value > 0) query.Take(param.Take.Value);
            }

            var retList = query.List();

            return new QueryResult<IList<CompanySystemInfoEntity>>(retList, rawRowCont, retList.Count);
        }



    }
}
