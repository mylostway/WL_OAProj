using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public class QueryRoleInfoParam : BaseQueryParam
    {
        public int? Fid { get; set; }

        public string Name { get; set; }
    }
}
