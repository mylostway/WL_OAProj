using System;
using System.Collections.Generic;
using System.Text;

using WL_OA.BLL;

namespace WL_OA
{
    public static class StringBLLEx
    {
        /// <summary>
        /// 格式化到用户ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string ToUserID(this int userID)
        {
            return UserManagerBLL.ToUserID(userID);
        }

        /// <summary>
        /// 格式化到用户ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string ToUserID(this string userID)
        {
            return UserManagerBLL.ToUserID(userID);
        }


        public static bool NullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        
    }
}
