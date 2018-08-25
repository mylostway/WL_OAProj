using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using log4net;
using log4net.Repository;

namespace Data.utils
{
    public static class SLogger
    {
        static SLogger()
        {
            var curType = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
            ILoggerRepository repository = LogManager.CreateRepository(DEFAULT_LOGGER_NAME);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(repository, new FileInfo(DEFAULT_CFG_FILE_NAME));
            s_logger = LogManager.GetLogger(DEFAULT_LOGGER_NAME, DEFAULT_LOGGER_NAME);
        }

        const string DEFAULT_CFG_FILE_NAME = "log4net.config";

        const string DEFAULT_LOGGER_NAME = "dlogger";

        static ILog s_logger = null;

        public static void Info(string msg, Exception ex = null)
        {
            s_logger.Info(msg, ex);            
        }

        public static void Warn(string msg, Exception ex = null)
        {
            s_logger.Warn(msg, ex);
        }

        public static void Debug(string msg, Exception ex = null)
        {
            s_logger.Debug(msg, ex);
        }

        public static void Err(string msg,Exception ex = null)
        {
            s_logger.Error(msg, ex);
        }
    }
}
