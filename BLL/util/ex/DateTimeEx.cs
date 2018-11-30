using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.BLL
{
    public static class DateTimeEx
    {
        /// <summary>
        /// 日期格式化为yyyyMMddHHmmss
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToDateSecondStr(this DateTime dt)
        {
            return dt.ToString("yyyyMMddHHmmss");
        }


        

    }
}
