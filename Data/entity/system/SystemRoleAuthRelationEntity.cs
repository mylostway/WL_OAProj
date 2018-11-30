using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_system_role_auth_relation")]
    public class SystemRoleAuthRelationEntity : BaseEntity<int>
    {
        protected int frole_id = 0;
        /// <summary>
        /// 角色ID'
        /// </summary>
        [Required]
        public virtual int Frole_id { get { return frole_id; } set { frole_id = value; } }

        protected int fauth_id = 0;
        /// <summary>
        /// 授权ID'
        /// </summary>
        [Required]
        public virtual int Fauth_id { get { return fauth_id; } set { fauth_id = value; } }

        public SystemRoleAuthRelationEntity() { }

        public SystemRoleAuthRelationEntity(SystemRoleAuthRelationEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Frole_id = rhs.Frole_id;
            this.Fauth_id = rhs.Fauth_id;
        }
    }
}
