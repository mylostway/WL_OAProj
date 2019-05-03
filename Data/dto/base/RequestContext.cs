using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    /// <summary>
    /// 请求上下文
    /// </summary>
    public class SysRequestContext
    {
        /// <summary>
        /// 登录信息
        /// </summary>
        public LoginInfo LoginInfo { get; set; } = new LoginInfo();


        public static readonly SysRequestContext TestInstance = new SysRequestContext()
        {
            LoginInfo = new LoginInfo("system", CryptHelper.ToMD5("system"), "测试管理员")
        };
    }
}
