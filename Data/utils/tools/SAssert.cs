using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.utils
{
    public static class AssertEx
    {
        public static void MustNotNull<T>(this T val,string asMsg = "")
            where T : class
        {
            if (string.IsNullOrEmpty(asMsg)) asMsg = "表达式值异常，必须为非空";
            if (null == val) throw new UserFriendlyException(asMsg);
        }
    }

    public class SAssert
    {
        /// <summary>
        /// val必须非null，否则异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="asMsg"></param>
        public static void MustNotNull<T>(T val,string asMsg = "")
            where T:class
        {
            if (string.IsNullOrEmpty(asMsg)) asMsg = "表达式值异常，必须为非空";
            if (null == val) throw new UserFriendlyException(asMsg);
        }

        /// <summary>
        /// bVal必须为true，否则抛出异常
        /// </summary>
        /// <param name="bVal"></param>
        /// <param name="asMsg"></param>
        public static void MustTrue(bool bVal, string asMsg)
        {
            if (string.IsNullOrEmpty(asMsg)) asMsg = "表达式值异常，必须为真";
            if (!bVal) throw new UserFriendlyException(asMsg);
        }


        /// <summary>
        /// bVal必须为true，否则抛出异常
        /// </summary>
        /// <param name="bVal"></param>
        /// <param name="asMsg"></param>
        public static void MustTrue(bool bVal, Exception ex)
        {
            if (!bVal) throw ex;
        }
    }
}
