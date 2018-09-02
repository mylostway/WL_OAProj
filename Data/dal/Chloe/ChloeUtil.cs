using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Infrastructure;
using Chloe.MySql;

using Data.dal.Chloe;
using Data.utils.cfg;

namespace Data.dal
{
    public class ChloeUtil
    {
        public static IDbContext DbContext { get; private set; }

        private static readonly string CFG_FILE_NAME = "chloe.cfg.xml";

        static ChloeUtil()
        {
            DbContext = new MySqlContext(new MySqlConnectionFactory(ConfigHelper.GetOnKey("")));
        }

    }
}
