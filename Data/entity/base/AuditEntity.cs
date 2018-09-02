using System;
using System.Collections.Generic;
using System.Text;

namespace Data.entity
{
    /// <summary>
    /// 审计Entity
    /// </summary>
    public class AuditEntity : BaseEntity
    {
        public AuditEntity()
        {
            FInputTime = DateTime.Now;
            FlastModifyTime = null;
        }

        /// <summary>
        /// 录入人
        /// </summary>
        public virtual String FInputUser { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public virtual DateTime FInputTime { get; set; }

        /// <summary>
        /// 最后一次更新人
        /// </summary>
        public virtual String FlastModifyUser { get; set; }

        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public virtual DateTime? FlastModifyTime { get; set; }
    }

    /// <summary>
    /// 审计Entity
    /// </summary>
    public class AuditEntity<T> : BaseEntity<T>
    {
        public AuditEntity()
        {
            FInputTime = DateTime.Now;
            FlastModifyTime = null;
        }

        /// <summary>
        /// 录入人
        /// </summary>
        public virtual String FInputUser { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public virtual DateTime FInputTime { get; set; }

        /// <summary>
        /// 最后一次更新人
        /// </summary>
        public virtual String FlastModifyUser { get; set; }

        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public virtual DateTime? FlastModifyTime { get; set; }
    }
}
