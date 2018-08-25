using System;
using System.Collections.Generic;
using System.Text;

namespace Data.param
{
    public class QueryWharfInfoParam : BaseQueryParam
    {
        public QueryWharfInfoParam(string mark = "",string area = "",string alias = "",string wharfName = "")
        {
            Mark = mark;
            Area = area;
            Alias = alias;
            WharfName = WharfName;
        }

        /// <summary>
        /// 助记码
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 码头名
        /// </summary>
        public string WharfName { get; set; }
    }
}
