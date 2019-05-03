using ConsoleTest.Base;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data;
using WL_OA.Data.utils;
using WL_OA.Data.utils.cfg;

namespace ConsoleTest.test_cases
{

    [Config("configs/AppRunConfigs.json")]
    public class AppRunConfigs
    {
        static AppRunConfigs()
        {
            Instance = ConfigHelper.Get<AppRunConfigs>();
        }

        public static AppRunConfigs Instance { get; private set; }

        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerHost { get; set; } = "";

        /// <summary>
        /// 服务器端口
        /// </summary>
        public int ServerPort { get; set; } = 0;


        /// <summary>
        /// 默认超时时间（毫秒）
        /// </summary>
        public int DefaultRequestTimeout { get; set; } = 0;


        /// <summary>
        /// 是否单机测试模式（使用Fake数据源）
        /// </summary>
        public bool IsSingleTestMode { get; set; } = true;

    }

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

            var cfg2 = ConfigHelper.Get<AppRunConfigs>();

            var ret = AppRunConfigs.Instance;

            return true;
        }
    }




    [Config("configs/db_connection.json")]
    public class DbConnectionConfig
    {
        public Dictionary<string, List<DbConnectionInfo>> DbConnectionDic { get; set; } = new Dictionary<string, List<DbConnectionInfo>>();
    }


    public class DbConnectionInfo
    {
        public string DbName { get; set; }

        public string ConnectionString { get; set; }
    }



    [Config("configs/table_db_mapping.json")]
    public class TableDbMappingConfig
    {
        public Dictionary<string, List<TableDbMappingInfo>> TableDbMappingDic { get; set; }
    }



    public class TableDbMappingInfo
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 数据库连接
        /// </summary>
        public string DbConnectionName { get; set; }

        /// <summary>
        /// 数据库类型名称
        /// </summary>
        public string DbType { get; set; }

        /// <summary>
        /// 是否加密
        /// </summary>
        public bool IsEncrypt { get; set; } = false;

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
    }

}
