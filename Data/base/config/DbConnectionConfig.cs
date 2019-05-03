using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.utils.cfg;

namespace WL_OA.Data.config
{
    [Config("configs/db_connection.json")]
    public class DbConnectionConfig
    {
        protected DbConnectionConfig() { }

        public Dictionary<string,List<DbConnectionInfo>> DbConnectionDic { get; set; }

        public static DbConnectionConfig Instance = ConfigHelper.Get<DbConnectionConfig>();

        /// <summary>
        /// 根据连接名获取默认连接
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetDefaultDbConnectionStringOnName(string name)
        {
            if (!Instance.DbConnectionDic.ContainsKey(name)) throw new UserFriendlyException($"没找到{name}的数据库连接配置");
            return Instance.DbConnectionDic[name][0].ConnectionString;
        }
    }


    public class DbConnectionInfo
    {
        public string DbName { get; set; }

        public string ConnectionString { get; set; }
    }
}
