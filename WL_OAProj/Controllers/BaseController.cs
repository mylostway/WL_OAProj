using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WL_OA.BLL.query;

namespace WL_OAProj.Controllers
{
    
    public class BaseController<T> : Controller
        where T : class,new()
    {
        private static ConcurrentDictionary<Type, T> s_bllDic = new ConcurrentDictionary<Type, T>();

        const int MAX_TRY_TIMES = 5;

        public T BLL()            
        {
            var type = typeof(T);

            T ins = null;

            var bGetResult = s_bllDic.TryGetValue(type, out ins);

            if (!bGetResult
                || (bGetResult && null == ins))
            {
                ins = new T();
                s_bllDic.AddOrUpdate(type, ins, (x, t) =>
                {
                    return ins;
                });
            }

            return ins;
        }
    }
}