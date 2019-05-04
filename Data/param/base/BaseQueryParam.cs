using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public class BaseQueryParam : IQueryParam
    {
        public BaseQueryParam() : this(10) { }

        public BaseQueryParam(int pSize = 10)
        {
            Skip = 0;
            Take = 10;
            page = 0;
            pageSize = 10;
            IsAllowPagging = true;
        }

        /// <summary>
        /// 跳过记录数
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// 取多少个
        /// </summary>
        public int? Take { get; set; }

        public int? page { get; set; }

        public int? pageSize { get; set; }

        /// <summary>
        /// 是否允许分页
        /// </summary>
        public bool IsAllowPagging { get; set; } = true;
    }
}
