using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public class BaseRequest
    {
        public BaseRequest(string reqMethod)
        {
            RequestMethod = reqMethod;
        }

        public string RequestMethod { get; set; }
    }
}
