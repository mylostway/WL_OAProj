using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.entity;

namespace WL_OA.Data.run_time
{
    /// <summary>
    /// 系统运行时信息
    /// </summary>
    public sealed class SystemRunTimeDataManager
    {
        private SystemRunTimeDataManager()
        {

        }

        public static SystemRunTimeDataManager Instance = new SystemRunTimeDataManager();

        

        /// <summary>
        /// 公司系统基本信息
        /// </summary>
        public CompanySystemInfoEntity CompanySystemInfo { get; set; }
    }
}
