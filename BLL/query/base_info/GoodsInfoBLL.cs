using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

using WL_OA.Data;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using NHibernate.Criterion;
using BLL.settings;
using BLL.util;
using WL_OA.Data.utils;
using System.Reflection;
using WL_OA.Data.dal.Cache;

namespace WL_OA.BLL.query
{
    public class GoodsInfoBLL : CommBaseBLL<GoodsinfoEntity,QueryGoodsInfoParam>
    {
        public override QueryResult<IList<GoodsinfoEntity>> GetEntityList(QueryGoodsInfoParam param)
        {
            var queryParam = param as QueryGoodsInfoParam;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<GoodsinfoEntity>();

            if (null != queryParam.Fid) query.And(c => c.Fid == queryParam.Fid.Value);
            if (!string.IsNullOrEmpty(queryParam.FChnName)) query.And(Restrictions.Like("Fchn_Name", string.Format("%{0}%", queryParam.FChnName)));
            if (!string.IsNullOrEmpty(queryParam.Fmark)) query.And(Restrictions.Like("Fmark", string.Format("%{0}%", queryParam.Fmark)));
            if(null != queryParam.Fusable) query.And(c => c.Fusable == queryParam.Fusable.Value);

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

            return new QueryResult<IList<GoodsinfoEntity>>(retList, rawRowCont, retList.Count);
        }


        const string ALL_GOODS_INFO_CACHE_KEY = "CK_GoodsInfo";


        /// <summary>
        /// 获取所有商品信息（通常用于选择面板）
        /// </summary>
        /// <returns></returns>
        public IList<GoodsinfoEntity> GetAllGoodsInfo()
        {
            IList<GoodsinfoEntity> retList = null;

            if(null != m_cache)
            {
                retList = m_cache.Get<IList<GoodsinfoEntity>>(ALL_GOODS_INFO_CACHE_KEY);
                if(null != retList)
                {
                    return retList;
                }
            }

            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<GoodsinfoEntity>();

            int rawRowCont = query.RowCount();

            query.OrderBy((x) => x.Fmark).Desc();

            retList = query.List();

            if(null != m_cache)
            {
                // 缓存设置失效时间，失效之后有请求调用该接口的会自动刷新缓存，省去很多修改的麻烦
                // 有特殊场景再特殊做，现在没空考虑这么多
                if(!m_cache.Add(ALL_GOODS_INFO_CACHE_KEY, retList, CacheSetting.GetCacheDefaultExpireTimespan()))
                {
                    SLogger.Warn($"缓存记录 - {ALL_GOODS_INFO_CACHE_KEY} 失败");
                }
            }

            return retList;
        }
    }
}
