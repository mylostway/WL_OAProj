using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace WL_OA.Data.dal.Cache
{
    public class MemoryCacheServices : BaseCache, ICacheServices
    {
        private IMemoryCache _cache;

        public MemoryCacheServices(IMemoryCache objCache)
        {
            _cache = objCache;
        }

        public virtual T Get<T>(string key)
            where T : class
        {
            CheckKeyNotNull(key);
            if (null == _cache) return default(T);
            return _cache.Get<T>(key);
        }

        public virtual bool Remove(string key)
        {
            // 缓存没启用
            if (null == _cache) return false;
            CheckKeyNotNull(key);

            _cache.Remove(key);
            return !Exists(key);
        }

        public bool Add(string key, object value)
        {
            CheckKeyNotNull(key);
            CheckValueNotNull(value);

            _cache.Set(key, value);
            return Exists(key);
        }

        public Task<bool> AddAsync(string key, object value)
        {
            CheckKeyNotNull(key);
            CheckValueNotNull(value);

            _cache.Set(key, value);
            return ExistsAsync(key);
        }

        public bool Add(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            CheckKeyNotNull(key);
            CheckValueNotNull(value);

            _cache.Set(key, value,
                    new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(expiresSliding)
                    .SetAbsoluteExpiration(expiressAbsoulte));

            return Exists(key);
        }

        public Task<bool> AddAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            CheckKeyNotNull(key);
            CheckValueNotNull(value);

            _cache.Set(key, value,
                new MemoryCacheEntryOptions().SetSlidingExpiration(expiresSliding).SetAbsoluteExpiration(expiressAbsoulte));

            return ExistsAsync(key);
        }

        public bool Add(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            CheckKeyNotNull(key);
            CheckValueNotNull(value);

            if (isSliding)
                _cache.Set(key, value,new MemoryCacheEntryOptions().SetSlidingExpiration(expiresIn));
            else
                _cache.Set(key, value,new MemoryCacheEntryOptions().SetAbsoluteExpiration(expiresIn));

            return Exists(key);
        }

        public Task<bool> AddAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            CheckKeyNotNull(key);
            CheckValueNotNull(value);

            if (isSliding)
                _cache.Set(key, value, new MemoryCacheEntryOptions().SetSlidingExpiration(expiresIn));
            else
                _cache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(expiresIn));

            return ExistsAsync(key);
        }

        public Task<bool> RemoveAsync(string key)
        {
            CheckKeyNotNull(key);

            _cache.Remove(key);
            return ExistsAsync(key);
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAllAsync(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key) where T : class
        {
            CheckKeyNotNull(key);
            if (null == _cache) return null;
            var retObj = _cache.Get<T>(key);
            return Task.FromResult(retObj);
        }

        public object Get(string key)
        {
            CheckKeyNotNull(key);
            if (null == _cache) return null;
            return _cache.Get(key);
        }

        public Task<object> GetAsync(string key)
        {
            CheckKeyNotNull(key);
            if (null == _cache) return null;
            var retObj = _cache.Get(key);
            return Task.FromResult(retObj);
        }

        public IDictionary<string, object> GetAll(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, object>> GetAllAsync(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public bool Replace(string key, object value)
        {
            CheckKeyNotNull(key);
            CheckValueNotNull(value);

            if (Exists(key))
                if (!Remove(key)) return false;

            return Add(key, value);
        }

        public Task<bool> ReplaceAsync(string key, object value)
        {
            throw new NotImplementedException();
        }

        public bool Replace(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReplaceAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            throw new NotImplementedException();
        }

        public bool Replace(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            CheckKeyNotNull(key);
            CheckValueNotNull(value);

            if (Exists(key))
                if (!Remove(key)) return false;

            return Add(key, value, expiresIn, isSliding);
        }

        public Task<bool> ReplaceAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string key)
        {
            CheckKeyNotNull(key);
            object cached;
            return _cache.TryGetValue(key, out cached);
        }

        public Task<bool> ExistsAsync(string key)
        {
            CheckKeyNotNull(key);
            object cached;            
            var ret = _cache.TryGetValue(key, out cached);
            return Task.FromResult(ret);
        }

        public void Dispose()
        {
            if (_cache != null)
                _cache.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
