using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace Data.utils.tools
{
    /// <summary>
    /// 字段值格式验证
    /// </summary>
    public static class FieldValueValidator
    {
        /// <summary>
        /// 验证对象是否有效
        /// </summary>
        /// <param name="obj">要验证的对象</param>
        /// <param name="validationResults"></param>
        /// <returns></returns>
        public static bool IsValid(this object obj, Collection<ValidationResult> validationResults)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj, null, null), validationResults, true);
        }


        /// <summary>
        /// 验证对象是否有效
        /// </summary>
        /// <param name="obj">要验证的对象</param>
        /// <returns></returns>
        public static bool IsValid(this object obj)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj, null, null), new Collection<ValidationResult>(), true);
        }
    }
}
