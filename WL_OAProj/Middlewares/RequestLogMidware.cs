using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WL_OA.Data;
using WL_OA.Data.dto;
using Microsoft.AspNetCore.Builder;
using log4net;

namespace WL_OAProj.Middlewares
{
    /// <summary>
    /// 记录请求日志
    /// </summary>
    public static class RequestLogMidwareEx
    {
        static RequestLogMidwareEx() { }

        public static void Register(this IApplicationBuilder app)
        {
            app.Run(new RequestDelegate(async context =>
            {
                var logger = (ILog)app.ApplicationServices.GetService(typeof(ILog));

                logger?.Info(context.Request.ToString());
            }));
        }
    }    
}
