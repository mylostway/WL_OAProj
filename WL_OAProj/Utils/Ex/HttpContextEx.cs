using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WL_OAProj
{
    /// <summary>
    /// 为了读取HttpContext.Response实现的Stream封装
    /// </summary>
    public class MemoryWrappedHttpResponseStream : MemoryStream
    {
        private Stream _innerStream;
        public MemoryWrappedHttpResponseStream(Stream innerStream)
        {
            this._innerStream = innerStream ?? throw new ArgumentNullException(nameof(innerStream));
        }
        public override void Flush()
        {
            this._innerStream.Flush();
            base.Flush();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            base.Write(buffer, offset, count);
            this._innerStream.Write(buffer, offset, count);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                this._innerStream.Dispose();
            }
        }

        public override void Close()
        {
            base.Close();
            this._innerStream.Close();
        }
    }


    public static class HttpContextEx
    {
        #region HttpRequest

        public static async Task<string> GetRequestBodyString(this HttpContext httpContext)
        {
            var req = httpContext.Request;
            if (null != req && req.Method.ToLower().IndexOf("post") >= 0)
            {
                // 只保存html,json,text的请求内容
                var contentType = req.ContentType.ToString();
                if ((contentType.Contains("html")
                    || contentType.Contains("json")
                    || contentType.Contains("text"))
                    && req.ContentLength != null
                    && req.ContentLength > 0)
                {
                    return await ReadBodyAsync(req);
                }
            }
            return "";
        }

        private static async Task<string> ReadBodyAsync(HttpRequest request)
        {
            if (request.ContentLength > 0)
            {
                await EnableRewindAsync(request).ConfigureAwait(false);
                var encoding = GetEncodingOnContentType(request.ContentType);
                return await ReadStreamAsync(request.Body, encoding).ConfigureAwait(false);
            }
            return null;
        }

        private static Encoding GetEncodingOnContentType(string contentType)
        {
            var mediaType = string.IsNullOrEmpty(contentType) == null ? default(MediaType) : new MediaType(contentType);
            var encoding = mediaType.Encoding;
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return encoding;
        }

        private static async Task EnableRewindAsync(HttpRequest request)
        {
            if (!request.Body.CanSeek)
            {
                request.EnableBuffering();

                await request.Body.DrainAsync(CancellationToken.None);
                request.Body.Seek(0L, SeekOrigin.Begin);
            }
        }



        #endregion


        #region HttpResponse

        public static async Task<string> GetResponseString(this HttpContext context)
        {
            var res = context.Response;

            EnableReadAsync(res);

            // 调用这个函数的时候应该在Response准备好了之后
            /*
            context.Response.OnCompleted(async o =>
            {
                var c = o as HttpContext;
                if (c != null)
                {
                    var retStr = await ReadBodyAsync(c.Response).ConfigureAwait(false);                    
                }
            }, context);
            */

            return await ReadBodyAsync(res).ConfigureAwait(false);
        }


        private static async Task<string> ReadBodyAsync(HttpResponse response)
        {
            if (response.Body.Length > 0)
            {
                //var position = response.Body.Position;
                response.Body.Seek(0, SeekOrigin.Begin);
                var encoding = GetEncodingOnContentType(response.ContentType);
                var retStr = await ReadStreamAsync(response.Body, encoding, false).ConfigureAwait(false);
                //response.Body.Position = position;
                //读取完成后再重新赋值位置这个过程可能不需要，因为数据流是只写的
                return retStr;
            }
            return null;
        }

        private static void EnableReadAsync(HttpResponse response)
        {
            if (!response.Body.CanRead || !response.Body.CanSeek)
            {
                response.Body = new MemoryWrappedHttpResponseStream(response.Body);
            }
        }

        private static async Task<string> ReadStreamAsync(Stream stream, Encoding encoding)
        {
            using (StreamReader sr = new StreamReader(stream, encoding, true, 1024, true))//这里注意Body部分不能随StreamReader一起释放
            {
                var str = await sr.ReadToEndAsync();
                stream.Seek(0, SeekOrigin.Begin);//内容读取完成后需要将当前位置初始化，否则后面的InputFormatter会无法读取
                return str;
            }
        }

        private static async Task<string> ReadStreamAsync(Stream stream, Encoding encoding, bool forceSeekBeginZero = true)
        {
            using (StreamReader sr = new StreamReader(stream, encoding, true, 1024, true))//这里注意Body部分不能随StreamReader一起释放
            {
                var str = await sr.ReadToEndAsync();
                if (forceSeekBeginZero)
                {
                    stream.Seek(0, SeekOrigin.Begin);//内容读取完成后需要将当前位置初始化，否则后面的InputFormatter会无法读取
                }
                return str;
            }
        }

        #endregion
    }
}
