using BLL.util;
using System;
using System.Collections.Generic;
using System.Text;

using WL_OA.Data;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OA.BLL
{
    public partial class RoleManagerBLL : CommBaseBLL<SystemRoleEntity, QueryRoleInfoParam>
    {
        public override QueryResult<IList<SystemRoleEntity>> GetEntityList(QueryRoleInfoParam param)
        {
            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<SystemRoleEntity>();

            query.WhereIfNotNull(param.Fid, x => x.Fid == param.Fid);
            query.WhereIfNotEmpty(param.Name, x => x.Fname == param.Name);            

            int rawRowCont = query.RowCount();

            if (param.IsAllowPagging)
            {
                QueryHelper.FixQueryTake(param, rawRowCont);

                if (null != param.Skip && param.Skip.Value > 0) query.Skip(param.Skip.Value);
                if (null != param.Take && param.Take.Value > 0) query.Take(param.Take.Value);
            }

            var retList = query.List();

            return new QueryResult<IList<SystemRoleEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
