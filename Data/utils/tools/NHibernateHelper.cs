using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Type;

namespace WL_OA.Data.utils.tools
{
    public class NHibernateHelper
    {
        public class NHibernateSqlInjector : EmptyInterceptor
        {
            public override SqlString OnPrepareStatement(SqlString sql)
            {
                System.Diagnostics.Debug.WriteLine("sql语句:" + sql);
                return base.OnPrepareStatement(sql);
            }
        }

    }
}
