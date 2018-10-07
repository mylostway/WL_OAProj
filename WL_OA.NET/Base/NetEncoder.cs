using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.NET
{
    public class NetEncoder
    {
        private static Encoding s_defaultEncoding = Encoding.UTF8;

        /// <summary>
        /// 解码buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bytesCount"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static string Decode(byte[] buffer,int bytesCount = -1,int startIndex = 0)
        {
            if (-1 == bytesCount) bytesCount = buffer.Length;
            return s_defaultEncoding.GetString(buffer, startIndex, bytesCount);
        }

        /// <summary>
        /// 编码buffer
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] Encode(string str)
        {            
            return s_defaultEncoding.GetBytes(str);
        }
    }
}
