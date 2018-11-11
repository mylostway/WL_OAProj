using ConsoleTest.Base;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data;
using WL_OA.Data.utils;
using WL_OA.Data.utils.cfg;

namespace ConsoleTest.test_cases
{
    /// <summary>
    /// 配置子结构
    /// </summary>
    public class ChildConfigStruct
    {
        public string CldStr1 { get; set; }

        public string CldStr2 { get; set; }

        public int Cldint1 { get; set; }
    }

    /// <summary>
    /// 测试配置读取/转换的逻辑用例
    /// </summary>
    [Config("configs/TestConfig.json")]
    public class TestConfig : ITest
    {
        public string CfgVal_Str1 { get; set; }

        public string CfgVal_Str2 { get; set; }

        public int CfgVal_Int1 { get; set; }

        public int? CfgVal_Int2 { get; set; } = 1;

        public int? CfgVal_Int3 { get; set; } = 90;

        public string CfgVal_Str3 { get; set; }

        public double CfgVal_double1 { get; set; }

        public bool CfgVal_bool1 { get; set; }

        public bool CfgVal_bool2 { get; set; }

        public DateTime CfgVal_Date1 { get; set; }

        public ChildConfigStruct CfgVal_Struct1 { get; set; }

        public bool RunTest()
        {
            var cfg = ConfigHelper.Get<TestConfig>();

            SAssert.MustTrue(!string.IsNullOrEmpty(cfg.CfgVal_Str1),"");
            SAssert.MustTrue(string.IsNullOrEmpty(cfg.CfgVal_Str2), "");
            SAssert.MustTrue(!string.IsNullOrEmpty(cfg.CfgVal_Str3), "");

            SAssert.MustTrue(cfg.CfgVal_Int1 == 101, "");
            SAssert.MustTrue(cfg.CfgVal_Int2 == 1, "");
            SAssert.MustTrue(cfg.CfgVal_Int3 == 77, "");
            SAssert.MustTrue(cfg.CfgVal_double1 == 101.11, "");
            SAssert.MustTrue(cfg.CfgVal_bool1, "");
            SAssert.MustTrue(cfg.CfgVal_bool2 == false, "");

            SAssert.MustTrue(cfg.CfgVal_Struct1.CldStr1 == "cld_str1", "");
            SAssert.MustTrue(cfg.CfgVal_Struct1.CldStr2 == "cld_str2", "");
            SAssert.MustTrue(cfg.CfgVal_Struct1.Cldint1 == 1, "");

            return true;
        }
    }



}
