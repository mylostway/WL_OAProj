using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Data.param;

using NHibernate;

namespace BLL.util
{
    public class QueryParamsAnalizer
    {
        public static string ExplainQueryParams<T>(T param, Dictionary<string,string> addValDic)
            where T : IParams
        {
            Type t = typeof(T);

            var properties = t.GetProperties(BindingFlags.Public);

            StringBuilder sbQuery = new StringBuilder();

            foreach(var e in properties)
            {
                var type = e.PropertyType;

                var isNull = false;

                if(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    isNull = true;
                    // 获取真实的定义Type
                    type = type.GetGenericArguments()[0];
                }

                // 属性Type的名称
                var tName = type.Name.ToLower();
                // 属性的名称
                var pName = e.Name;
                // 规则定义，约定属性名称为F + 字段名,所以参数名取去掉F之后的部分
                var subParamName = pName.Substring(1);

                var val = e.GetValue(param);

                if(isNull)
                {
                    if(null != val)
                    {
                        sbQuery.Append(string.Format(" and {0} = :{1} ", pName, subParamName));
                        addValDic.Add(subParamName, val.ToString());
                    }
                }
                else
                {
                    if("string" == tName && !string.IsNullOrEmpty((string)val))
                    {
                        sbQuery.Append(string.Format(" and {0} = :{1} ", pName, subParamName));
                        addValDic.Add(subParamName, val.ToString());
                    }
                    else if("datetime" == tName)
                    {
                        DateTime dt = (DateTime)val;

                        sbQuery.Append(string.Format(" and {0} = :{1} ", pName, subParamName));
                        addValDic.Add(subParamName, dt.ToString("yyyy-MM-dd"));
                    }
                }
            }

            return sbQuery.ToString();
        }


        public static void InputQueryField<T>(T field, Dictionary<string, string> addValDic)
        {

        }
    }
}
