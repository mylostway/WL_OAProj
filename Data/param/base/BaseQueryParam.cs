﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.param
{
    public class BaseQueryParam : IParams
    {
        public int? Skip { get; set; }

        public int? Take { get; set; }
    }
}
