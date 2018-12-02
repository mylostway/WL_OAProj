using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public class QueryUserRoleRelationParam : BaseQueryParam
    {
        public int? Fid { get; set; }

        public int? UserID { get; set; }

        public int? RoleID { get; set; }
    }
}
