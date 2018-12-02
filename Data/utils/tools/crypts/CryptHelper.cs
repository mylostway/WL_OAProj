using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Cryptography;

namespace WL_OA
{
    public static class CryptHelper
    {
        /// <summary>
        /// 字符串转MD5
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToMD5(this string str,Encoding encoding = null)
        {
            if (null == encoding) encoding = Encoding.Default;

            var provider = new MD5CryptoServiceProvider();
            byte[] hashBytes = encoding.GetBytes(str);
            var computeHashBytes = provider.ComputeHash(hashBytes);
            return BitConverter.ToString(computeHashBytes).Replace("-", "");            
        }


        /// <summary>
        /// 生成请求Ticket
        /// </summary>
        /// <returns></returns>
        public static string GenRequestTicket()
        {
            throw new NotFiniteNumberException();            
        }
    }
}
