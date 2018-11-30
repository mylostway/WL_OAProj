using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_system_role")]
    public class SystemRoleEntity : BaseEntity<int>
    {
        protected string fname = "";
        /// <summary>
        /// 角色名称'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fname { get { return fname; } set { fname = value; } }

        protected DateTime fcreate_time = DateTime.Now;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public virtual DateTime Fcreate_time { get { return fcreate_time; } set { fcreate_time = value; } }

        public SystemRoleEntity() { }

        public SystemRoleEntity(SystemRoleEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fname = rhs.Fname;
            this.Fcreate_time = rhs.Fcreate_time;
        }
    }
}
