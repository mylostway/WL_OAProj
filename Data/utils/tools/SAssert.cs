using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.utils
{
    public class SAssert
    {
        /// <summary>
        /// bVal必须为true，否则抛出异常
        /// </summary>
        /// <param name="bVal"></param>
        /// <param name="asMsg"></param>
        public static void MustTrue(bool bVal, string asMsg)
        {
            if (string.IsNullOrEmpty(asMsg)) asMsg = "表达式值异常，必须为真";
            if (!bVal) throw new Exception(asMsg);
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
