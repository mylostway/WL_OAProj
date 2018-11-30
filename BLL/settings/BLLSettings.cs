using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.settings
{
    public class BLLSettings
    {
        /// <summary>
        /// 每次最大查询返回记录条数
        /// </summary>
        public const int DEFAULT_PRE_QUERY_MAX_COUNT = 100;

        /// <summary>
        /// 默认token超时（秒，10分钟）
        /// </summary>
        public const int DEFAULT_TOKEN_TIME_OUT_IN_SEC = 10 * 60;
    }
}
