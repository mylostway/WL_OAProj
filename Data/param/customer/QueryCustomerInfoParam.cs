using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{    
    /// <summary>
    /// 
    /// </summary>
    public class QueryCustomerInfoParam : BaseQueryParam
    {
        /// <summary>
        /// 日期类型
        /// </summary>
        public DateTypeEnums? DateType { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 终止时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 查找ID类型1
        /// </summary>
        public QueryCustomerInfoIDTypeEnums? IDType1 { get; set; }

        /// <summary>
        /// ID1
        /// </summary>
        public string ID1 { get; set; }

        /// <summary>
        /// 查找ID类型2
        /// </summary>
        public QueryCustomerInfoIDTypeEnums? IDType2 { get; set; }

        /// <summary>
        /// ID2
        /// </summary>
        public string ID2 { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        public QueryCustomerInfoTypeEnums? CustomType { get; set; }

        /// <summary>
        /// 客户状态
        /// </summary>
        public QueryCustomerInfoStateEnums? StateType { get; set; }
    }
}
