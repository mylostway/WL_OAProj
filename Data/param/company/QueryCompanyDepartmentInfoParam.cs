using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public class QueryCompanyDepartmentInfoParam : BaseQueryParam
    {
        public int Fid { get; set; }

        public string DepartmentName { get; set; }
    }
}
