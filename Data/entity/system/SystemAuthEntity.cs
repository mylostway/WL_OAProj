using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_system_auth")]
    public class SystemAuthEntity : BaseEntity<int>
    {
        protected string fname = "";
        /// <summary>
        /// 授权名称'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fname { get { return fname; } set { fname = value; } }

        protected string fmemo = "";
        /// <summary>
        /// 备注
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fmemo { get { return fmemo; } set { fmemo = value; } }

        public SystemAuthEntity() { }

        public SystemAuthEntity(SystemAuthEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fname = rhs.Fname;
            this.Fmemo = rhs.Fmemo;
        }
    }
}
