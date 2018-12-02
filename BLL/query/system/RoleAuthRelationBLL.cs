using BLL.util;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OA.BLL.query
{
    public class RoleAuthRelationBLL : CommBaseBLL<SystemRoleAuthRelationEntity, QueryRoleAuthRelationParam>
    {
        public override QueryResult<IList<SystemRoleAuthRelationEntity>> GetEntityList(QueryRoleAuthRelationParam param)
        {
            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<SystemRoleAuthRelationEntity>();

            query.WhereifNotNull(param.Fid, x => x.Fid == param.Fid);
            query.WhereifNotNull(param.RoleID, x => x.Frole_id == param.RoleID);
            query.WhereifNotNull(param.AuthID, x => x.Fauth_id == param.AuthID);

            int rawRowCont = query.RowCount();

            if (param.IsAllowPagging)
            {
                QueryHelper.FixQueryTake(param, rawRowCont);

                if (null != param.Skip && param.Skip.Value > 0) query.Skip(param.Skip.Value);
                if (null != param.Take && param.Take.Value > 0) query.Take(param.Take.Value);
            }

            var retList = query.List();

            return new QueryResult<IList<SystemRoleAuthRelationEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
