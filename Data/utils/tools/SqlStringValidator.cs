using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Security.Application;

namespace Data.utils.tools
{
    /// <summary>
    /// SQL字符串验证类
    /// </summary>
    public static class SqlStringValidator
    {
        /// <summary>
        /// 修正有敏感字符的字符串值
        /// </summary>
        /// <returns></returns>
        public static string FixVal(string strVal)
        {
            return strVal.AntiSqlInject().AntiXssInject();     
        }


        /// <summary>
        /// 反sql注入
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        public static string AntiSqlInject(this string strVal)
        {
            // 目前使用了参数化sql，根本上杜绝了，所以暂不实现
            return strVal;
        }


        /// <summary>
        /// 反XSS注入
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        public static string AntiXssInject(this string strVal)
        {
            strVal = AntiXss.JavaScriptEncode(strVal);
            return AntiXss.HtmlEncode(strVal);
        }

    }
}
