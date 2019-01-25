using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    public static class CommonEx
    {
        /*
        /// <summary>
        /// 将HttpContext请求内容格式化输出
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<string> GetRequestBodyString(this HttpContext httpContext)
        {
            // FIXME：待测试
            var retStr = "";
            var req = httpContext.Request;            
            if(null != req && req.Method.ToLower().IndexOf("post") >= 0)
            {
                if (!req.Body.CanRead) return "";
                // 只保存html,json,text的请求内容
                var contentType = req.ContentType.ToString();
                if ((contentType.Contains("html") 
                    || contentType.Contains("json") 
                    || contentType.Contains("text"))
                    && req.ContentLength != null 
                    && req.ContentLength > 0)
                {
                    var memBuff = new MemoryStream((int)req.ContentLength);
                    await req.Body.CopyToAsync(memBuff);
                    using (StreamReader sr = new StreamReader(memBuff))
                    {
                        retStr = await sr.ReadToEndAsync();
                    }

                    memBuff.Position = 0;
                    req.Body = memBuff;
                }
                else
                {
                    // 非可视请求（二进制），暂不记录
                }
            }
            return retStr;
        }



        /// <summary>
        /// 将HttpContext应答内容格式化输出
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<string> GetResponseBodyString(this HttpContext httpContext)
        {
            // FIXME：待测试
            var retStr = "";
            var res = httpContext.Response;
            if (null == res || null == res.Body) return "";

            
            
            // 只保存html,json,text的请求内容
            var contentType = res.ContentType.ToString();
            if ((contentType.Contains("html")
                || contentType.Contains("json")
                || contentType.Contains("text"))
                && res.ContentLength != null 
                && res.ContentLength > 0)
            {
                var memBuff = new MemoryStream((int)res.ContentLength);
                await res.Body.CopyToAsync(memBuff);                
                using (var sr = new StreamReader(memBuff))
                {
                    retStr = await sr.ReadToEndAsync();
                }

                memBuff.Position = 0;
                res.Body = memBuff;
            }
            return retStr;
        }
        */
    }
}
