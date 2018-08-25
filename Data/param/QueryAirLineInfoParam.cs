using System;
using System.Collections.Generic;
using System.Text;

namespace Data.param
{
    public class QueryAirLineInfoParam : BaseQueryParam
    {
        public QueryAirLineInfoParam(int? airLineNo = null,string airName = "")
        {
            AirLineNo = airLineNo;
            AirName = airName;
        }

        /// <summary>
        /// 航线编号
        /// </summary>
        public int? AirLineNo { get; set; }

        /// <summary>
        /// 航线名
        /// </summary>
        public string AirName { get; set; }
    }
}
