using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IAttributeValidator
    {
        bool IsValid();
    }

    /// <summary>
    /// 字符串/buffer最大长度限制
    /// </summary>
    public class MaxLengthAttribute : Attribute
    {
        public MaxLengthAttribute(int maxLen) { MaxLength = maxLen; }

        public int MaxLength = 0;
    }


    /// <summary>
    /// 必须字段（非null和非空值）
    /// </summary>
    public class RequiredAttribute : Attribute
    {
        public RequiredAttribute() { }
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
