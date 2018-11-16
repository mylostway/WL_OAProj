using System;
using System.Collections.Generic;
using System.Reflection;

namespace WL_OA.Data
{
    public class EnumNamesAttribute : Attribute
    {
        public EnumNamesAttribute(string name = "")
        {
            Name = name;
        }
        public string Name { get; set; }
    }


    public class EnumInfo
    {
        //public EnumInfo() { }

        public EnumInfo(Enum val,string name)
        {
            Value = val;
            Name = name;
        }

        /// <summary>
        /// 枚举值
        /// </summary>
        public Enum Value { get; set; }

        /// <summary>
        /// 枚举名称
        /// </summary>
        public string Name { get; set; }

        //public object Context { get; set; }
    }


    /// <summary>
    /// 枚举配置查找器
    /// </summary>
    public static class EnumHelper
    {
        static Dictionary<string, Dictionary<string, Enum>> s_dicEnumsKeyValPair = new Dictionary<string, Dictionary<string, Enum>>();

        /// <summary>
        /// 获取指定名称的枚举配置
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static Dictionary<string, Enum> GetEnumSettingOnName(string enumName)
        {
            if (string.IsNullOrEmpty(enumName)) return new Dictionary<string, Enum>();
            if (!s_dicEnumsKeyValPair.ContainsKey(enumName))
            {
                // 遇到没有找到enum配置的情况，直接添加一个空列表以返回
                s_dicEnumsKeyValPair.Add(enumName, new Dictionary<string, Enum>());
            }
            return s_dicEnumsKeyValPair[enumName];
        }

        /// <summary>
        /// 获取指定枚举类型的枚举配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumInfo> GetEnumInfoListOnName<T>()
        {
            var type = typeof(T);
            if (!type.IsEnum) return new List<EnumInfo>();
            return GetEnumInfoListOnName(type.Name);
        }

        /// <summary>
        /// 获取指定名称的枚举配置
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static List<EnumInfo> GetEnumInfoListOnName(string enumName)
        {
            var dic = GetEnumSettingOnName(enumName);
            var retList = new List<EnumInfo>();
            if (null == dic || 0 == dic.Count) return retList;
            foreach(var e in dic)
            {
                retList.Add(new EnumInfo(e.Value, e.Key));
            }
            return retList;
        }


        /// <summary>
        /// 获取指定的枚举类型展示列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> GetEnumNamesOnType<T>()
        {
            var retList = new List<string>();
            var type = typeof(T);
            if (!type.IsEnum) return retList;
            var dic = GetEnumSettingOnName(type.Name);
            if (null == dic || 0 == dic.Count) return retList;
            foreach(var e in dic)
            {
                retList.Add(e.Key);
            }
            return retList;
        }


        /// <summary>
        /// 转换枚举名字列表到枚举值列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameList"></param>
        /// <returns></returns>
        public static List<int> ConvertEnumNameListToValOnType<T>(List<string> nameList)
        {
            var retList = new List<int>();
            var type = typeof(T);
            if (!type.IsEnum) return retList;
            var dic = GetEnumSettingOnName(type.Name);
            if (null == dic || 0 == dic.Count) return retList;
            foreach(var e in nameList)
            {
                if (!dic.ContainsKey(e)) continue;
                retList.Add(Convert.ToInt32(dic[e]));
            }
            return retList;
        }


        /// <summary>
        /// 将枚举类的名字转换成对应的约定值
        /// </summary>
        /// <param name="e"></param>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static Enum ConvNameToVal(this Enum e, string enumName)
        {
            var type = e.GetType();
            var typeName = type.Name;
            if (!s_dicEnumsKeyValPair.ContainsKey(typeName)) return null;
            var dic = s_dicEnumsKeyValPair[typeName];
            if (!dic.ContainsKey(enumName)) return null;
            return dic[enumName];
        }


        public static T getVal<T>(object obj)
        {
            return (T)obj;
        }


        /// <summary>
        /// 将枚举类的名字转换成对应的约定值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static T ToEnumVal<T>(this string enumName)
        {
            var type = typeof(T);
            if (!type.IsEnum) return default(T);      
            var retVal = ToEnumVal(enumName, type);
            if (-1 == retVal) return default(T);
            return (T)Enum.ToObject(type, retVal);
        }

        /// <summary>
        /// 将枚举类的名字转换成对应的约定值
        /// </summary>
        /// <param name="e"></param>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static int ToEnumVal(this string enumName, Type enumType)
        {
            var typeName = enumType.Name;
            if (!s_dicEnumsKeyValPair.ContainsKey(typeName)) return -1;
            var dic = s_dicEnumsKeyValPair[typeName];
            if (!dic.ContainsKey(enumName)) return -1;            
            return Convert.ToInt32(dic[enumName]);
        }


        static EnumHelper()
        {
            // 这样查找非常方便，不过效率可能低，因为要遍历整个Assembly的数据
            var assembly = Assembly.GetAssembly(typeof(EnumHelper));

            var allTypes = assembly.GetTypes();

            foreach (var eType in allTypes)
            {
                if (eType.IsEnum)
                {
                    var dic = new Dictionary<string, Enum>();
                    var arrays = eType.GetEnumValues();
                    foreach (var eElem in arrays)
                    {
                        var fieldInfo = eElem.GetType().GetField(eElem.ToString());
                        var attribArray = fieldInfo.GetCustomAttributes(false);
                        if (0 == attribArray.Length)
                        {
                            // 不符合的枚举格式，没有说明属性
                            continue;
                        }
                        var attrib = (EnumNamesAttribute)attribArray[0];
                        if (null == attrib)
                        {
                            // 不符合的枚举格式，没有说明属性
                            continue;
                        }
                        dic.Add(attrib.Name, eElem as Enum);
                    }
                    s_dicEnumsKeyValPair.Add(eType.Name, dic);
                }
            }
        }
    }
}
