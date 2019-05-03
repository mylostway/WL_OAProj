using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.consts;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OA.Data.utils
{
    public static class QueryHelper
    {
        /// <summary>
        /// 修正QueryTake参数，不能大于DEFAULT_PRE_QUERY_MAX_COUNT
        /// </summary>
        /// <param name="param"></param>
        /// <param name="allRowCount"></param>
        /// <returns></returns>
        public static int FixQueryTake(BaseQueryParam param, int allRowCount)
        {
            int rawRowCont = allRowCount;

            if (rawRowCont > RepositorySettings.DEFAULT_PRE_QUERY_MAX_COUNT)
            {
                if (null != param.page && param.page.Value > 0)
                {
                    if (rawRowCont - param.Skip > RepositorySettings.DEFAULT_PRE_QUERY_MAX_COUNT)
                    {
                        param.Take = RepositorySettings.DEFAULT_PRE_QUERY_MAX_COUNT;
                    }
                }
                else
                {
                    param.Take = RepositorySettings.DEFAULT_PRE_QUERY_MAX_COUNT;
                }
                return param.Take.Value;
            }
            else
            {
                param.Take = rawRowCont;
            }
            return rawRowCont;
        }


        /// <summary>
        /// 获取合规的page
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int GetFixedQueryPageIndex(this BaseQueryParam param)
        {
            if (null == param.page || param.page <= 0) return 0;
            if (param.page >= int.MaxValue) return int.MaxValue;
            return param.page.Value;
        }


        /// <summary>
        /// 获取合规的PageSize
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int GetFixedQueryPageSize(this BaseQueryParam param)
        {
            if (null == param.pageSize || param.pageSize < 0) return RepositorySettings.DEFAULT_RET_PAGE_SIZE;
            if (param.pageSize > RepositorySettings.DEFAULT_PRE_QUERY_MAX_COUNT) return RepositorySettings.DEFAULT_PRE_QUERY_MAX_COUNT;
            return param.pageSize.Value;
        }


        /// <summary>
        /// 默认最小时间，1970-01-01
        /// </summary>
        static readonly DateTime MIN_DATE_TIME = DateTime.Parse("1970-01-01");

        /// <summary>
        /// 修正日期，默认间隔为30（一个月），结束日期为当天
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="dayInter"></param>
        /// <returns></returns>
        public static void FixDate(ref DateTime? start, ref DateTime? end, int dayInter = 30)
        {
            if (!end.HasValue)
            {
                end = DateTime.Now;
            }

            if (!start.HasValue)
            {
                if (dayInter < 0)
                {
                    start = MIN_DATE_TIME;
                }
                else
                {
                    start = end.Value.AddDays(dayInter);
                }
            }
        }

        /// <summary>
        /// 软删除的状态值
        /// </summary>
        public const int SOFT_DELETED_FSTATE = 0;

        /// <summary>
        /// 判断数据状态值是否软删除
        /// </summary>
        /// <param name="Fstate"></param>
        /// <returns></returns>
        public static bool IsDataSoftDeleted(int Fstate)
        {
            return Fstate == SOFT_DELETED_FSTATE;
        }

        /// <summary>
        /// 判断数据状态值是否软删除
        /// </summary>
        /// <param name="Fstate"></param>
        /// <returns></returns>
        public static bool IsDataSoftDeleted(this BaseEntity entity)
        {
            return entity.Fstate == SOFT_DELETED_FSTATE;
        }

        /// <summary>
        /// 判断数据状态值是否软删除
        /// </summary>
        /// <param name="Fstate"></param>
        /// <returns></returns>
        public static bool IsDataSoftDeleted<T>(this BaseEntity<T> entity)
        {
            return entity.Fstate == SOFT_DELETED_FSTATE;
        }
    }
}
