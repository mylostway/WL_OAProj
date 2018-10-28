using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WL_OA.Data;
using WL_OA.Data.dto;
using WL_OA.NET;

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
            //m_logger?.Log();
            m_logger?.LogError(ex.Message, null);

            var rsp = new BaseOpResult(QueryResultCode.Failed, ex.Message);
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(JsonHelper.SerializeTo(rsp));
        }


        public async void DefaultExceptionHandler(HttpContext context,Exception ex)
        {
            //m_logger?.Log();
            m_logger?.LogError(ex.Message, null);

            var rsp = new BaseOpResult(QueryResultCode.Failed, ex.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(JsonHelper.SerializeTo(rsp));
        }
    }
}
