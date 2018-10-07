using System;
using System.Collections.Generic;
using System.Text;

using System.Net;

namespace WL_OA.NET
{
    public delegate NetHandleResult NetHandler(SimpleProtocolStruct request,IPEndPoint endPoint);

    //public delegate NetHandleResult JsonNetHandler(string jsonStr, IPEndPoint endPoint);

    public enum NetHandleResultCode
    {
        /// <summary>
        /// 系统错误，导致失败
        /// </summary>
        Failed = -1,
        Succeed = 0,

        /// <summary>
        /// （请求）错误格式
        /// </summary>
        ErrorFormat,
        /// <summary>
        /// 无权限
        /// </summary>
        NotPermitted,
        /// <summary>
        /// 超时
        /// </summary>
        Timeout,
    }


    public class WLOARequestException : Exception
    {
        public WLOARequestException(NetHandleResultCode resultCode = NetHandleResultCode.Failed,
            string resultMsg = "", Exception innerException = null)
            : base(resultMsg, innerException)
        {
            ResultCode = resultCode;
        }

        public NetHandleResultCode ResultCode { get; set; }
    }


    public class NetHandleResult
    {
        public NetHandleResult() { }

        public NetHandleResult(object retData)
        {
            RetObject = retData;
        }

        public NetHandleResult(NetHandleResultCode resultCode, string resultMsg = "")
        {
            ResultCode = resultCode;
            ResultMsg = resultMsg;
        }

        public NetHandleResultCode ResultCode { get; set; } = NetHandleResultCode.Succeed;

        public string ResultMsg { get; set; } = "";

        public object RetObject { get; set; } = null;

        public override string ToString()
        {
            return string.Format("NetHandleResult ResultCode={0}|ResultMsg={1}|RetObject={2}", ResultCode, ResultMsg, RetObject);
        }

        public static NetHandleResult TimeoutResponseInstance { get; private set; } = new NetHandleResult(NetHandleResultCode.Timeout, "请求超时");
        public static NetHandleResult FailedResponseInstance { get; private set; } = new NetHandleResult(NetHandleResultCode.Failed, "请求失败");
        public static NetHandleResult NotPermittedResponseInstance { get; private set; } = new NetHandleResult(NetHandleResultCode.NotPermitted, "无访问权限");
        public static NetHandleResult ErrorFormatResponseInstance { get; private set; } = new NetHandleResult(NetHandleResultCode.ErrorFormat, "错误请求参数");

        public static readonly string TimeoutResponseStrInstance = JsonHelper.SerializeTo(TimeoutResponseInstance);
        public static readonly string FailedResponseStrInstance = JsonHelper.SerializeTo(FailedResponseInstance);
        public static readonly string NotPermittedResponseStrInstance = JsonHelper.SerializeTo(NotPermittedResponseInstance);
        public static readonly string ErrorFormatResponseStrInstance = JsonHelper.SerializeTo(ErrorFormatResponseInstance);
    }

    public class NetBase
    {
        //public const int MAX_UDP_BUF_SIZE = 1400;
        public const int MAX_UDP_BUF_SIZE = 1024 * 10;

        public const string DEFAULT_IP = "127.0.0.1";

        public const int DEFAULT_PORT = 9091;
    }
}
