using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;

using WL_OA.Data.param;
using WL_OA.Data.entity;
using BLL.settings;


namespace BLL.util
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

            if (rawRowCont > QuerySettings.DEFAULT_PRE_QUERY_MAX_COUNT)
            {
                if (null != param.Skip && param.Skip.Value > 0)
                {
                    if (rawRowCont - param.Skip > QuerySettings.DEFAULT_PRE_QUERY_MAX_COUNT)
                    {
                        param.Take = QuerySettings.DEFAULT_PRE_QUERY_MAX_COUNT;                        
                    }
                }
                else
                {
                    param.Take = QuerySettings.DEFAULT_PRE_QUERY_MAX_COUNT;
                }
                return param.Take.Value;
            }
            return rawRowCont;
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
        public static void FixDate(ref DateTime? start,ref DateTime? end,int dayInter = 30)
        {
            if(!end.HasValue)
            {
                end = DateTime.Now;
            }

            if(!start.HasValue)
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
