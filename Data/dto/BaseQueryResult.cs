using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.dto
{
    /// <summary>
    /// DB查询结果代号
    /// </summary>
    public enum QueryResultCode : int
    {
        /// <summary>
        /// 
        /// </summary>
        Failed = -1,

        /// <summary>
        /// 
        /// </summary>
        Succeed = 0,

        /// <summary>
        /// 
        /// </summary>
        Timeout,
    }

    /// <summary>
    /// 基本查询结果
    /// </summary>
    public class BaseQueryResult
    {
        public BaseQueryResult(int maxResultCount = 0,int resultCount = 0, 
            QueryResultCode resultCode = QueryResultCode.Succeed, string retMsg = "")
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
        public QueryResultCode ResultCode { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        public string RetMsg { get; set; }
    }


    /// <summary>
    /// 操作结果
    /// </summary>
    public class BaseOpResult
    {
        public BaseOpResult(QueryResultCode resultCode = QueryResultCode.Succeed, string retMsg = "")
        {
            ResultCode = resultCode;
            RetMsg = retMsg;
        }

        public BaseOpResult(BaseOpResult rhs)
        {
            ResultCode = rhs.ResultCode;
            RetMsg = rhs.RetMsg;
        }

        /// <summary>
        /// 查询结果返回码
        /// </summary>
        public QueryResultCode ResultCode { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        public string RetMsg { get; set; }


        private static BaseOpResult s_succeedInstance = new BaseOpResult();

        /// <summary>
        /// 操作成功应答实例
        /// </summary>
        public static BaseOpResult SucceedInstance
        {
            get
            {
                return new BaseOpResult(s_succeedInstance);
            }
        }
    }
}
