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
        /// 失败
        /// </summary>
        Failed = -1,

        /// <summary>
        /// 成功
        /// </summary>
        Succeed = 0,

        /// <summary>
        /// 超时
        /// </summary>
        Timeout,

        /// <summary>
        /// 部分操作成功
        /// </summary>
        Partly,
    }


    /// <summary>
    /// 操作结果
    /// </summary>
    public class BaseOpResult
    {
        const string DEFAULT_OP_SUCCEED_MSG = "操作成功";

        const string DEFAULT_OP_FAILED_MSG = "操作失败";

        /// <summary>
        /// 空构造函数必须有(反射用)
        /// </summary>
        public BaseOpResult() : this(QueryResultCode.Succeed, DEFAULT_OP_SUCCEED_MSG) { }

        public BaseOpResult(QueryResultCode resultCode = QueryResultCode.Succeed, string retMsg = DEFAULT_OP_SUCCEED_MSG)
        {
            ResultCode = resultCode;
            RetMsg = retMsg;
        }

        public BaseOpResult(BaseOpResult rhs)
        {
            ResultCode = rhs.ResultCode;
            RetMsg = rhs.RetMsg;
        }

        public virtual bool IsSucceed()
        {
            return ResultCode == QueryResultCode.Succeed;
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


    /// <summary>
    /// 基本查询结果
    /// </summary>
    public class BaseQueryResult : BaseOpResult
    {
        public BaseQueryResult() : this(0, 0, QueryResultCode.Succeed, "") { }

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
    }


}
