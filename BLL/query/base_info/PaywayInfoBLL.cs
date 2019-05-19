using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.dal;
using WL_OA.Data.dal.Cache;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;

namespace WL_OA.BLL.query
{
    public class PaywayInfoBLL : CommBaseBLL<PayWaysEntity, QueryPaywaysParam>
    {
        public override QueryResult<IList<PayWaysEntity>> GetEntityList(QueryPaywaysParam param)
        {
            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<PayWaysEntity>();
            
            if (!string.IsNullOrEmpty(param.Fname)) query.And(Restrictions.Like("Fchn_Name", string.Format("%{0}%", param.Fname)));
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

            return new QueryResult<IList<PayWaysEntity>>(retList, rawRowCont, retList.Count);
        }


        const string ALL_PAYWAYS_INFO_CACHE_KEY = "CK_GoodsInfo";


        /// <summary>
        /// 获取所有支付方式信息（通常用于选择面板）
        /// </summary>
        /// <returns></returns>
        public IList<PayWaysEntity> GetAllPayways()
        {
            IList<PayWaysEntity> retList = null;
            if (null != m_cache)
            {
                retList = m_cache.Get<IList<PayWaysEntity>>(ALL_PAYWAYS_INFO_CACHE_KEY);
                if (null != retList)
                {
                    return retList;
                }
            }

            var session = NHibernateSessionManager.GetSession();
            var query = session.QueryOver<PayWaysEntity>();
            query.OrderBy((x) => x.Fid).Desc();
            retList = query.List();

            if (null != m_cache)
            {
                // 缓存设置失效时间，失效之后有请求调用该接口的会自动刷新缓存，省去很多修改的麻烦
                // 有特殊场景再特殊做，现在没空考虑这么多
                if (!m_cache.Add(ALL_PAYWAYS_INFO_CACHE_KEY, retList, CacheSetting.GetCacheDefaultExpireTimespan()))
                {
                    SLogger.Warn($"缓存记录 - {ALL_PAYWAYS_INFO_CACHE_KEY} 失败");
                }
            }

            return retList;
        }
    }
}
