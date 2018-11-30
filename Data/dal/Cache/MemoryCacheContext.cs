using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Caching.Memory;

namespace WL_OA.Data.dal.Cache
{
    public class MemoryCacheContext : ICacheContext
    {
        private IMemoryCache _objCache;

        public MemoryCacheContext(IMemoryCache objCache)
        {
            _objCache = objCache;
        }

        public virtual T Get<T>(string key)
        {
            return _objCache.Get<T>(key);
        }

        public virtual bool Set<T>(string key, T t, DateTime expire)
        {
            var obj = Get<T>(key);
            if (obj != null)
            {
                Remove(key);
            }

            _objCache.Set(key, t, new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(expire));   //绝对过期时间

            return true;
        }

        public virtual bool Remove(string key)
        {
            _objCache.Remove(key);
            return true;
        }
    }
}
