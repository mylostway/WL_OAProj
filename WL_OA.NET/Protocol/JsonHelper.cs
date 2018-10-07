﻿using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace WL_OA.NET
{
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
}
