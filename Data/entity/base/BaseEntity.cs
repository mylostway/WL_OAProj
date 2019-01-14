using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace WL_OA.Data.entity
{
    /// <summary>
    /// 基础Entity
    /// </summary>
    public class BaseEntity : IDataValidator
    {
        public BaseEntity(object id = null)
        {
            Fid = id;
            Fstate = 1;
        }

        /// <summary>
        /// ID
        /// </summary>
        public virtual object Fid { get; set; }

        /// <summary>
        /// 数据状态，1 - 启用，0 - 失效
        /// </summary>
        public virtual short Fstate { get; set; }

        public virtual bool IsValid()
        {
            try
            {
                var validationContext = new ValidationContext(this);
                var results = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(this, validationContext, results, true);

                if (!isValid)
                {
                    throw new UserFriendlyException(results[0].ErrorMessage, ExceptionScope.Parameter);
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message, ExceptionScope.System, ex);
            }
            return true;
        }
    }

    /// <summary>
    /// 基础Entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEntity<T> : IDataValidator
    {
        public BaseEntity(T id = default(T))
        {
            Fid = id;
            Fstate = 1;
        }

        /// <summary>
        /// ID
        /// </summary>
        public virtual T Fid { get; set; }

        /// <summary>
        /// 数据状态，1 - 启用，0 - 失效
        /// </summary>        
        public virtual short Fstate { get; set; }

        /// <summary>
        /// 检测数据合法性
        /// </summary>
        public virtual bool IsValid()
        {
            var validationContext = new ValidationContext(this);
            var results = new List<ValidationResult>();
            try
            {               
                var isValid = Validator.TryValidateObject(this, validationContext, results, false);
                if (!isValid)
                {
                    var strFirstMember = "";
                    foreach(var eMember in results[0].MemberNames)
                    {
                        strFirstMember = eMember;
                        break;
                    }
                    throw new UserFriendlyException($"字段:{strFirstMember}异常，原因:{results[0].ErrorMessage}", ExceptionScope.Parameter);
                }
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message, ExceptionScope.System, ex);
            }

            return true;
        }
    }
}
