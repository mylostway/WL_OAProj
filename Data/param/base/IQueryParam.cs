using System;
using System.Collections.Generic;
using System.Text;

namespace Data.param
{
    public interface IQueryParam
    {
        int? Skip { get; set; }
        int? Take { get; set; }
    }
}
