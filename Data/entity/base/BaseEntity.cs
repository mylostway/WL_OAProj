using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.entity
{
    /// <summary>
    /// 基础Entity
    /// </summary>
    public class BaseEntity
    {
        public BaseEntity(object id = null)
        {
            Fid = id;
            Fstate = 1;
        }

        /// <summary>
        /// ID
        /// </summary>
        [Required]
        public virtual object Fid { get; set; }

        /// <summary>
        /// 数据状态，1 - 启用，0 - 失效
        /// </summary>
        [Required]
        public virtual short Fstate { get; set; }
    }

    /// <summary>
    /// 基础Entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEntity<T>
    {
        public BaseEntity(T id = default(T))
        {
            Fid = id;
            Fstate = 1;
        }

        /// <summary>
        /// ID
        /// </summary>
        [Required]
        public virtual T Fid { get; set; }

        /// <summary>
        /// 数据状态，1 - 启用，0 - 失效
        /// </summary>
        [Required]        
        public virtual short Fstate { get; set; }
    }
}
