using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public class QueryRoleAuthRelationParam : BaseQueryParam
    {
        public int? Fid { get; set; }

        public int? RoleID { get; set; }

        public int? AuthID { get; set; }
    }
}
