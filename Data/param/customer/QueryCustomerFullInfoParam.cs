using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    public class QueryCustomerFullInfoParam 
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        [Required]
        public int CustomerID { get; set; }

        /// <summary>
        /// 客户信息子面板，跳过记录数
        /// </summary>
        public int ChildInfoListSkip { get; set; } = 0;

        /// <summary>
        /// 客户信息子面板，查询条数(一般而言会比较小记录的，15足够差完整了)
        /// </summary>
        public int ChildInfoListTake { get; set; } = 15;
    }
}
