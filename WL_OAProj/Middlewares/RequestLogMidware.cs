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
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using WL_OA.Data.utils;
using System.Diagnostics;

namespace WL_OAProj.Middlewares
{

    /// <summary>
    /// 记录请求日志
    /// </summary>
    public class RequestLogMidware
    {
        private RequestDelegate m_nextDelegate;

        public RequestLogMidware(RequestDelegate next)
        {
            m_nextDelegate = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext, IServiceProvider sp)
        {
            var watch = new Stopwatch();
            watch.Start();

            var reqStatisticsInfo = new WebReqResStatisticsDTO();
            var request = httpContext.Request;

            var logger = (ILog)sp.GetService(typeof(ILog));

            reqStatisticsInfo.Method = request.Method;
            reqStatisticsInfo.ContentType = request.ContentType;
            reqStatisticsInfo.RequestHeader = JsonHelper.SerializeTo(request.Headers);
            reqStatisticsInfo.RequestFullUrl = $"{request.PathBase.Value}{request.Path.Value}?{request.QueryString.Value}";
            reqStatisticsInfo.RequestBody = await httpContext.GetRequestBodyString();

            try
            {
                await m_nextDelegate.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                reqStatisticsInfo.Exception = ex;
            }
            finally
            {
                watch.Stop();
                reqStatisticsInfo.ResponseBody = await httpContext.GetResponseBodyString();
                reqStatisticsInfo.Cost = watch.ElapsedMilliseconds;

                var strStatistics = JsonHelper.SerializeTo(reqStatisticsInfo);
                if (null != logger) logger.Info(strStatistics);
                else SLogger.Info(strStatistics);
            }
        }
    }
}
