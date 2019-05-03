﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    public static class CollectionEx
    {
        /// <summary>
        /// 集合元素为null或者没元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return (null == collection || 0 == collection.Count);
        }


        /// <summary>
        /// 将Collection转换成带分割符字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static string ToSplitString<T>(this ICollection<T> collection,char splitChar = ',')
        {
            if (collection.IsNullOrEmpty()) return "";
            StringBuilder sb = new StringBuilder();
            foreach(var e in collection)
            {
                sb.Append($"{e.ToString()}{splitChar}");
            }
            // 去掉末尾的分隔符
            if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }


        /// <summary>
        /// 截取原list中的某些部分，自动校验边界，不保证复制全长度
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="nStartIndex"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        public static IList<T> Sub<T>(this IList<T> list, int nStartIndex, int nLen)
        {
            if (list.IsNullOrEmpty()) return new List<T>();
            var retList = new List<T>();
            for (var i = 0; i < nLen; i++)
            {
                if (nStartIndex + i > list.Count) return retList;
                retList.Add(list[nStartIndex + i]);
            }
            return retList;
        }


        /// <summary>
        /// 简单判断两个列表是否相等（仅比较列表，不比较元素）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool IsSimpleEqualTo<T>(this IList<T> lhs, IList<T> rhs)
        {
            if (lhs == null && rhs == null) return true;
            if (lhs == null && rhs != null) return false;
            if (lhs != null && rhs == null) return false;
            if (lhs.Count != rhs.Count) return false;
            return true;
        }


        /// <summary>
        /// 判断两个列表是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool IsEqualTo<T>(this IList<T> lhs, IList<T> rhs)
        {
            if (!IsSimpleEqualTo(lhs, rhs)) return false;
            for (var i = 0; i < lhs.Count; i++)
            {
                if (lhs[i].Equals(rhs[i])) return false;
            }
            return true;
        }
        
    }
}
