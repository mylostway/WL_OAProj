using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.consts
{
    public class SystemSettings
    {
        /// <summary>
        /// 如果是单机版，则这里固定写死这个公司名称，用作系统运行时逻辑
        /// </summary>
        public const string UseCompanyName = "广东坤天科技";

        /// <summary>
        /// 单机版时，取这个常量作为公司业务前缀
        /// </summary>
        public const string COMPANY_APP_PREFIX = "gdktkj";
    }
}
