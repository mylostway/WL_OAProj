using BLL.util;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;

namespace WL_OA.BLL.query.system
{
    public class CompanySystemInfoBLL : CommBaseBLL<CompanySystemInfoEntity, QueryCompanySystemInfoParam>
    {
        /// <summary>
        /// 获取公司信息列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override QueryResult<IList<CompanySystemInfoEntity>> GetEntityList(QueryCompanySystemInfoParam param)
        {
            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<CompanySystemInfoEntity>();

            query.WhereIfNotEmpty(param.CompanyName, x => x.Fname == param.CompanyName);

            int rawRowCont = query.RowCount();

            if (param.IsAllowPagging)
            {
                var pageIdx = param.GetFixedQueryPageIndex();
                var pageSize = param.GetFixedQueryPageSize();
                if (pageIdx > 1)
                {
                    query.Skip((pageIdx - 1) * pageSize);
                }
                query.Take(pageSize);
            }

            var retList = query.List();

            return new QueryResult<IList<CompanySystemInfoEntity>>(retList, rawRowCont, retList.Count);
        }



    }
}
