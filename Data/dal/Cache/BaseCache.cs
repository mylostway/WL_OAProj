using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.dal.Cache
{
    public abstract class BaseCache
    {
        public virtual void CheckKeyNotNull(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new UserFriendlyException("缓存的key不能为空");
        }

        public virtual void CheckValueNotNull(object value)
        {
            if (null == value) throw new UserFriendlyException("缓存的value不能为空");
        }

        

    }
}
