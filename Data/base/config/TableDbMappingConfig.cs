using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.utils.cfg;

namespace WL_OA.Data.config
{
    [Config("configs/table_db_mapping.json")]
    public class TableDbMappingConfig
    {
        protected TableDbMappingConfig() { }

        public Dictionary<string,List<TableDbMappingInfo>> TableDbMappingDic { get; set; }

        public static TableDbMappingConfig Instance = ConfigHelper.Get<TableDbMappingConfig>();

        /// <summary>
        /// 获取数据表对应的数据库配置
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<TableDbMappingInfo> GetTableDbConfig(string tableName)
        {
            if (Instance.TableDbMappingDic.ContainsKey(tableName)) return Instance.TableDbMappingDic[tableName];
            return null;
        }


        /// <summary>
        /// 根据表名获取数据库默认连接串
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string GetDefaultDbConnectionStringOnTableName(string tableName)
        {
            if (!Instance.TableDbMappingDic.ContainsKey(tableName)) throw new UserFriendlyException($"未找到{tableName}的数据库连接配置");
            var dbConName = Instance.TableDbMappingDic[tableName][0].DbConnectionName;
            return DbConnectionConfig.GetDefaultDbConnectionStringOnName(dbConName);
        }
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
