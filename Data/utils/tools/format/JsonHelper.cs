using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace WL_OA.Data
{
    /// <summary>
    /// JSON工具类
    /// </summary>
    public class JsonHelper
    {
        public static object DeserializeTo(string jsonStr)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings.NullValueHandling = NullValueHandling.Ignore;

            return JsonConvert.DeserializeObject(jsonStr);
        }


        public static object DeserializeTo(string jsonStr,Type t)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings.NullValueHandling = NullValueHandling.Ignore;

            return JsonConvert.DeserializeObject(jsonStr, t, settings);
        }

        public static T DeserializeTo<T>(string jsonStr)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings.NullValueHandling = NullValueHandling.Ignore;

            return JsonConvert.DeserializeObject<T>(jsonStr);
        }


        public static string SerializeTo(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings.NullValueHandling = NullValueHandling.Ignore;

            return JsonConvert.SerializeObject(obj,Formatting.None, settings);
        }
    }


    /// <summary>
    /// JSON相关扩展类
    /// </summary>
    public static class JsonEx
    {
        /// <summary>
        /// 转换到JSON字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonHelper.SerializeTo(obj);
        }
    }
}
