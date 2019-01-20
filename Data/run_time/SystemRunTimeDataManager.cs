using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.entity;

namespace WL_OAProj.Sys
{
    /// <summary>
    /// 系统运行时信息
    /// </summary>
    public sealed class SystemRunTimeDataManager
    {
        private SystemRunTimeDataManager()
        {
            CompanySystemInfo = 
        }

        public static SystemRunTimeDataManager Instance = new SystemRunTimeDataManager();

        /// <summary>
        /// 公司系统基本信息
        /// </summary>
        public CompanySystemInfoEntity CompanySystemInfo { get; set; }
    }
}
