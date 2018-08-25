using System;
using System.Collections.Generic;
using System.Text;

namespace Data.utils
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
            if (!bVal)
                throw new Exception(asMsg);
        }

    }
}
