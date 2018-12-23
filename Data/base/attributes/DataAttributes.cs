using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    public interface IAttributeValidator
    {
        bool IsValid();
    }

    /// <summary>
    /// 按位取值
    /// </summary>
    public class BitUsageFieldAttribute: Attribute
    {
        public BitUsageFieldAttribute(int maxBit,string errMsg = "按位取值字段录入错误")
        {
            MaxBit = maxBit;
            ErrorMsg = errMsg;
        }

        /// <summary>
        /// 最大位下标
        /// </summary>
        public int MaxBit { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }
    }    



    /// <summary>
    /// 字符串是数字形式
    /// </summary>
    public class NumberFormattedStringAttribute : Attribute
    {
        public NumberFormattedStringAttribute() { }
    }


    /// <summary>
    /// email字符串
    /// </summary>
    public class EmailStringAttribute : Attribute { }


    /// <summary>
    /// 证件字符串
    /// </summary>
    public class CertStringAttribute : Attribute { }

    /// <summary>
    /// 手机字符串
    /// </summary>
    public class PhoneStringAttribute : Attribute { }
}
