using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace WL_OA.NET
{
    /// <summary>
    /// 通讯协议结构体
    /// </summary>
    public class SimpleProtocolStruct
    {
        public SimpleProtocolStruct() { }

        public SimpleProtocolStruct(string requestMethod, string requestUser,
            string requestParam, string responseData = "", string sessionID = "")
        {
            RequestMethod = requestMethod;
            SessionID = sessionID;
            RequestUser = requestUser;
            RequestParam = requestParam;
            ResponseData = responseData;
        }

        /// <summary>
        /// 请求方法
        /// </summary>
        public string RequestMethod { get; set; }

        /// <summary>
        /// 请求sessionID
        /// </summary>
        public string SessionID { get; set; }

        /// <summary>
        /// 请求用户
        /// </summary>
        public string RequestUser { get; set; }

        /// <summary>
        /// 请求ID，提供异步支持（全局唯一）
        /// </summary>
        public string RequestID { get; set; }

        /// <summary>
        /// 请求参数（JSON格式）
        /// </summary>
        public string RequestParam { get; set; }

        /// <summary>
        /// 应答数据
        /// </summary>
        public string ResponseData { get; set; }


        /// <summary>
        /// 设置应答数据（可以选择清空RequestParam，为了节省流量）
        /// </summary>
        /// <param name="responseData"></param>
        /// <param name="isClearRequestData">是否清空RequestParam，为了节省流量</param>
        public void SetToResponse(string responseData, bool isClearRequestData = false)
        {
            ResponseData = responseData;
            if (isClearRequestData)
            {
                RequestParam = "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return SimpleProtocol.Encode(this);
        }


        public byte[] ToBytes()
        {
            return NetEncoder.Encode(SimpleProtocol.Encode(this));
        }


        public static SimpleProtocolStruct TimeoutResponseStructInstance = new SimpleProtocolStruct("", "", "", NetHandleResult.TimeoutResponseStrInstance, "");
        public static SimpleProtocolStruct FailedResponseStructInstance = new SimpleProtocolStruct("", "", "", NetHandleResult.FailedResponseStrInstance, "");
        public static SimpleProtocolStruct NotPermittedResponseStructInstance = new SimpleProtocolStruct("", "", "", NetHandleResult.NotPermittedResponseStrInstance, "");
        public static SimpleProtocolStruct ErrorFormatResponseInstance = new SimpleProtocolStruct("", "", "", NetHandleResult.ErrorFormatResponseStrInstance, "");
    }

    /// <summary>
    /// 通讯协议
    /// </summary>
    public class SimpleProtocol
    {
        private SimpleProtocol() { }

        public static SimpleProtocolStruct Decode(byte[] requestBuffer,int bufLen = -1)
        {
            return Decode(NetEncoder.Decode(requestBuffer, bufLen));
        }

        public static SimpleProtocolStruct Decode(string requestStr)
        {
            return JsonHelper.DeserializeTo<SimpleProtocolStruct>(requestStr);
        }

        public static string Encode(object obj)
        {
            return JsonHelper.SerializeTo(obj);
        }
    }
}
