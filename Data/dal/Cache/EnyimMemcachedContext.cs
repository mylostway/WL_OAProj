using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.dal.Cache
{
    // memcache实现，暂时不使用
    //public sealed class EnyimMemcachedContext : ICache
    //{
    //    private IMemcachedClient _memcachedClient;

    //    public EnyimMemcachedContext(IMemcachedClient client)
    //    {
    //        _memcachedClient = client;
    //    }

    //    public override T Get<T>(string key)
    //    {
    //        return _memcachedClient.Get<T>(key);
    //    }

    //    public override bool Set<T>(string key, T t, DateTime expire)
    //    {
    //        return _memcachedClient.Store(StoreMode.Set, key, t, expire);
    //    }

    //    public override bool Remove(string key)
    //    {
    //        return _memcachedClient.Remove(key);
    //    }
    //}
}
