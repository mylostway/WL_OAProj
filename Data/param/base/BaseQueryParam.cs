using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public class BaseQueryParam : IQueryParam
    {
        public BaseQueryParam() { }

        /// <summary>
        /// 跳过记录数
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// 取多少个
        /// </summary>
        public int? Take { get; set; }

        /// <summary>
        /// 是否允许分页
        /// </summary>
        public bool IsAllowPagging { get; set; }
    }
}
