using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            SAssert.MustTrue(!key.NullOrEmpty(),string.Format("获取Request内容的Key不能为空"));

            var val = Request.Query[key];

            if (string.IsNullOrEmpty(val))
            {
                val = Request.Form[TOKEN_KEY];

                if (string.IsNullOrEmpty(val))
                {
                    val = Request.Cookies[TOKEN_KEY];

                    if (string.IsNullOrEmpty(val))
                    {
                        return "";
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
                if (WebSettings.RedirectUrl.NullOrEmpty()) throw new Exception("登录重定向URL为空！");
                Response.Redirect(WebSettings.RedirectUrl);
                return null;
            }

            // 用token获取缓存

            // 如果缓存为空，则也认为没有登录，重新登录

            throw new NotImplementedException();
        }


        public T BLL()            
        {
            var type = typeof(T);

            T ins = new T();

            var context = new SysRequestContext();
            context.LoginInfo = GatherLoginInfo();

            ins.SetRequestContext(context);

            return ins;
        }
    }
}