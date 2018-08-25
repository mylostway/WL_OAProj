using System;
using System.Collections.Generic;
using System.Text;

namespace Data.dto
{
    /// <summary>
    /// 基本查询结果
    /// </summary>
    public class BaseQueryResult
    {
        public BaseQueryResult(int resultCode = 0,int maxResultCount = 0,int resultCount = 0,string retMsg = "")
        {
            ResultCode = resultCode;
            RetMsg = retMsg;
            MaxResultCount = maxResultCount;
            ResultCount = resultCount;
        }

        /// <summary>
        /// 这次查询最大记录数
        /// </summary>
        public int MaxResultCount { get; set; }

        /// <summary>
        /// 返回查询最大记录数
        /// </summary>
        public int ResultCount { get; set; }

        /// <summary>
        /// 查询结果返回码
        /// </summary>
        public int ResultCode { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        public string RetMsg { get; set; }
    }
}
