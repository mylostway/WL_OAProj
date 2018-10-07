using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public interface IQueryParam
    {
        int? Skip { get; set; }
        int? Take { get; set; }
    }
}
