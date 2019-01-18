using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WL_OA.Data;
using WL_OA.Data.dto;
using WL_OA.Data.utils;

namespace WL_OAProj.Middlewares
{
    /// <summary>
    /// 全局异常处理中间件
    /// </summary>
    public class ExceptionHandlerMidware
    {
        RequestDelegate m_next = null;

        ILogger m_logger = null;

        public ExceptionHandlerMidware(RequestDelegate next)
        {
            m_next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {                
                await m_next.Invoke(context);
            }
            catch(UserFriendlyException ex)
            {
                UserFriendlyExceptionHandler(context, ex);
            }
            catch(Exception ex)
            {
                DefaultExceptionHandler(context,ex);
            }
        }



        public async void UserFriendlyExceptionHandler(HttpContext context, UserFriendlyException ex)
        {
            if (null != m_logger) m_logger.LogError(ex.ToString(), null);
            else SLogger.Fatal($"发生已知逻辑异常，未捕获处理", ex);

            var rsp = new BaseOpResult(QueryResultCode.Failed, ex.Message);
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(JsonHelper.SerializeTo(rsp));
        }


        public async void DefaultExceptionHandler(HttpContext context, Exception ex)
        {
            if (null != m_logger) m_logger.LogError(ex.ToString(), null);
            else SLogger.Fatal($"发生未知系统异常，未捕获处理", ex);

            var rsp = new BaseOpResult(QueryResultCode.Failed, ex.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(JsonHelper.SerializeTo(rsp));
        }
    }
}
