﻿using System;
using System.Collections.Generic;
using System.Text;

using WL_OA.Data.utils;
using WL_OA.Data;

using ConsoleTest.Base;

namespace ConsoleTest.test_cases
{
    /// <summary>
    /// 枚举功能测试用例
    /// </summary>
    public class EnumUnitTest : ITest
    {
        public bool RunTest()
        {
            SAssert.MustTrue("托运人".ToEnumVal<QueryCustomerInfoTypeEnums>() == QueryCustomerInfoTypeEnums.Consignor, "");
            SAssert.MustTrue("BusinessDate".ToEnumVal<DateTypeEnums>() != DateTypeEnums.BusinessDate,"");
            return true;
        }
    }
}
