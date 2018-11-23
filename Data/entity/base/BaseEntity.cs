using System;
using System.Collections.Generic;
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

        public bool IsValid()
        {
            //throw new NotImplementedException();
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
        public bool IsValid()
        {
            //throw new NotImplementedException();
            return true;
        }
    }
}
