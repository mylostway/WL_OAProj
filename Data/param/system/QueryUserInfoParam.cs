﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public class QueryUserInfoParam : BaseQueryParam
    {
        public int? Fid { get; set; }

        public string Name { get; set; }

        public string Account { get; set; }

        public DateTime CreateTime { get; set; }
    }

}