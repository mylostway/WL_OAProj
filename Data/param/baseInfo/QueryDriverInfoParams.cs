using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    /// <summary>
    /// 查询司机信息的参数
    /// </summary>
    public class QueryDriverInfoParams : BaseQueryParam
    {
        public QueryDriverInfoParams() { }

        public QueryDriverInfoParams(int? id = null, string name = "")
        {
            this.Fid = id;
            this.Fname = name;
        }

        public int? Fid { get; set; }

        public string Fname { get; set; }

        public string Fphone { get; set; }

        public string Fcert { get; set; }

        public short? FworkState { get; set; }

        public string FdriverNo { get; set; }
    }
}
