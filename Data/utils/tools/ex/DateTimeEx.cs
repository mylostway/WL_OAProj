using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class DateTimeEx
    {
        /// <summary>
        /// 转换成xx天 hh:mm:ss字符串
        /// </summary>
        /// <param name="tSpan"></param>
        /// <returns></returns>
        public static string ToCostStr(this TimeSpan tSpan)
        {
            var day = tSpan.Days;
            var hour = tSpan.Hours;
            var min = tSpan.Minutes;
            var second = tSpan.Seconds;

            var sb = new StringBuilder();

            if (day > 0) sb.Append($"{day}天 ");
            sb.Append($"{hour}：");
            sb.Append($"{min}：");
            sb.Append($"{second}");

            return sb.ToString();
        }
    }
}
