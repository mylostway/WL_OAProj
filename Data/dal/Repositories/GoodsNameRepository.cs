using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;

namespace WL_OA.Data.dal.Repositories
{
    public class GoodsNameRepository : Repository<GoodsinfoEntity>
    {
        public QueryResult<IList<GoodsinfoEntity>> GetEntityList(QueryGoodsInfoParam queryParam)
        {
            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var query = DBContext.Query<GoodsinfoEntity>();

            if (null != queryParam.Fid) query = query.Where(c => c.Fid == queryParam.Fid.Value);
            if (!string.IsNullOrEmpty(queryParam.FChnName)) query = query.Where(c => c.Fchn_Name.Contains(queryParam.FChnName));
            if (!string.IsNullOrEmpty(queryParam.Fmark)) query = query.Where(c => c.Fmark.Contains(queryParam.Fmark));

            var rawRowCont = query.Count();

            QueryHelper.FixQueryTake(queryParam, rawRowCont);

            if (null != queryParam.Skip && queryParam.Skip.Value > 0) query.Skip(queryParam.Skip.Value);
            if (null != queryParam.Take && queryParam.Take.Value > 0) query.Take(queryParam.Take.Value);

            var retList = query.ToList();

            return new QueryResult<IList<GoodsinfoEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
