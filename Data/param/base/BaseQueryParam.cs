using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public class BaseQueryParam : IQueryParam
    {
        public BaseQueryParam() { }

        public int? Skip { get; set; }

        public int? Take { get; set; }
    }
}
