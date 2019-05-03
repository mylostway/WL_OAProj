using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WL_OA.Data;
using WL_OA.Data.utils.cfg;

namespace WL_OAProj.Sys.Config
{
    [Config("configs/AppRunConfigs.json")]
    public class AppRunConfigs
    {
        static AppRunConfigs()
        {
            Instance = ConfigHelper.Get<AppRunConfigs>();
        }

        public static AppRunConfigs Instance { get; private set; }

        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerHost { get; set; } = "";

        /// <summary>
        /// 服务器端口
        /// </summary>
        public int ServerPort { get; set; } = 0;


        /// <summary>
        /// 默认超时时间（毫秒）
        /// </summary>
        public int DefaultRequestTimeout { get; set; } = 0;


        /// <summary>
        /// 是否单机测试模式（使用Fake数据源）
        /// </summary>
        public bool IsSingleTestMode { get; set; } = true;
        
    }
}
