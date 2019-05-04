using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.dal.Cache
{
    public class CacheSetting
    {
        const double DEFAULT_CACHE_TIMEOUT_SPAN_IN_MINUTE = 3;


        /// <summary>
        /// 默认绝对超时时间（当前时间后移X分钟）
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetCacheDefaultExpireTimespan()
        {
            return TimeSpan.FromMinutes(DEFAULT_CACHE_TIMEOUT_SPAN_IN_MINUTE);
        }
    }
}
