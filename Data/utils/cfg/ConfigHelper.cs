using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Microsoft.Extensions.Configuration;

namespace WL_OA.Data.utils.cfg
{
    public class ConfigHelper
    {
        private const String DEFAULT_CFG_FILE_NAME = "appsettings.json";

        private static Dictionary<string, IConfiguration> ConfigurationDic
            = new Dictionary<string, IConfiguration>();

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetOnKey(string key, string cfgFileName = DEFAULT_CFG_FILE_NAME)
        {
            IConfiguration configuartion = null;

            if (!ConfigurationDic.ContainsKey(cfgFileName))
            {
                string cfgFilePath = string.Format("{0}/{1}", Directory.GetCurrentDirectory(), cfgFileName);

                SAssert.MustTrue(File.Exists(cfgFilePath), string.Format("配置文件:{0}不存在", cfgFilePath));

                configuartion = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(cfgFileName).Build();

                ConfigurationDic.Add(cfgFileName, configuartion);
            }
            else
            {
                configuartion = ConfigurationDic[cfgFileName];
            }

            return configuartion[key];
        }
    }
}
