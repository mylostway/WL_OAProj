using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WL_OA;
using WL_OA.BLL;
using WL_OA.BLL.query;
using WL_OA.Data;
using WL_OA.Data.entity;
using WL_OA.Data.utils;
using WL_OAProj.Settings;

namespace WL_OAProj.Controllers
{    
    public class BaseController<T> : Controller
        where T : IRequestContext, new()
    {
        const int MAX_TRY_TIMES = 5;

        const string TOKEN_KEY = "token";

        /// <summary>
        /// 从Request中获取指定key的值，顺序是 querystring -> form -> cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValFromRequest(string key)
        {
            SAssert.MustTrue(!key.NullOrEmpty(), string.Format("获取Request内容的Key不能为空"));

            var val = Request.Query[key];

            if (string.IsNullOrEmpty(val))
            {
                if (Request.ContentType.ToLower().IndexOf("html") >= 0)
                {
                    // 只有是html的请求才能获取form的值
                    val = Request.Form[key];
                }

                if (string.IsNullOrEmpty(val))
                {
                    val = Request.Cookies[key];

                    if (string.IsNullOrEmpty(val))
                    {
                        val = Request.Headers[key];

                        if (string.IsNullOrEmpty(val))
                        {
                            return "";
                        }
                    }
                }
            }

            return val;
        }
        

        /// <summary>
        /// 集合请求的信息，生成LoginInfo
        /// </summary>
        /// <returns></returns>
        public LoginInfo GatherLoginInfo()
        {
            var token = GetValFromRequest(TOKEN_KEY);

            if (string.IsNullOrEmpty(token))
            {
                // 没有登录，重定向到登录页面
                if (WebSettings.RedirectUrl.NullOrEmpty()) throw new UserFriendlyException("登录重定向URL为空！", ExceptionScope.Logic);
                Response.Redirect(WebSettings.RedirectUrl);
                return null;
            }

            // 用token获取缓存
            var loginInfo = (new UserManagerBLL()).GetLoginInfo(token);

            if(null == loginInfo)
            {
                Response.Redirect(WebSettings.RedirectUrl);
                return null;
            }

            return loginInfo;
        }


        public T BLL()            
        {
            var type = typeof(T);

            T ins = new T();

            // 暂时没有登录信息
            var context = new SysRequestContext();
            //context.LoginInfo = GatherLoginInfo();

            ins.SetRequestContext(context);

            return ins;
        }
    }
}