using System;
using System.Collections.Generic;
using System.Text;

using WL_OA.Data.param;

namespace WL_OA.Data.dal
{
    interface IDAL<T>
        where T:new()
    {
        /// <summary>
        /// 根据唯一KEY获取数据
        /// </summary>
        /// <param name="priKey"></param>
        /// <returns></returns>
        T Get(string priKey);


        List<T> GetList(BaseQueryParam param);


        bool Add(T entity);


        bool AddList(List<T> entityList);


        bool UpdateEntity(T entity);


        bool DelEntity(T entity);
    }
}
