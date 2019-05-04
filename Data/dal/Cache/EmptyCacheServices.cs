using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WL_OA.Data.dal.Cache
{
    public class EmptyCacheServices : ICacheServices
    {
        public bool Add(string key, object value)
        {
            return false;
        }

        public bool Add(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            return false;
        }

        public bool Add(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            return false;
        }

        public Task<bool> AddAsync(string key, object value)
        {
            return Task.FromResult(false);
        }

        public Task<bool> AddAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            return Task.FromResult(false);
        }

        public Task<bool> AddAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            return Task.FromResult(false);
        }

        public bool Exists(string key)
        {
            return false;
        }

        public Task<bool> ExistsAsync(string key)
        {
            return Task.FromResult(false);
        }


        public object Get(string key)
        {
            return false;
        }

        public T Get<T>(string key) where T : class
        {
            return null;
        }

        public IDictionary<string, object> GetAll(IEnumerable<string> keys)
        {
            return null;
        }

        public Task<IDictionary<string, object>> GetAllAsync(IEnumerable<string> keys)
        {
            return null;
        }

        public Task<T> GetAsync<T>(string key) where T : class
        {
            return Task.FromResult<T>(null);
        }

        public Task<object> GetAsync(string key)
        {
            return Task.FromResult<object>(null);
        }

        public bool Remove(string key)
        {
            return false;
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
            return;
        }

        public Task RemoveAllAsync(IEnumerable<string> keys)
        {
            return Task.CompletedTask;
        }

        public Task<bool> RemoveAsync(string key)
        {
            return Task.FromResult(false);
        }

        public bool Replace(string key, object value)
        {
            return false;
        }

        public bool Replace(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            return false;
        }

        public bool Replace(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            return false;
        }

        public Task<bool> ReplaceAsync(string key, object value)
        {
            return Task.FromResult(false);
        }

        public Task<bool> ReplaceAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            return Task.FromResult(false);
        }

        public Task<bool> ReplaceAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            return Task.FromResult(false);
        }

        public bool Set<T>(string key, T t, DateTime expire)
        {
            return false;
        }
    }
}
