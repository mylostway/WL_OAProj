using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class StringEx
    {
        public static string ToYesNoStr(this bool val)
        {
            return val ? "是" : "否";
        }
    }
}
