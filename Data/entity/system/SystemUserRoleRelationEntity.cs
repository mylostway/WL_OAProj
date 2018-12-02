using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_system_user_role_relation")]
    public class SystemUserRoleRelationEntity : BaseEntity<int>
    {
        protected int frole_id = 0;
        /// <summary>
        /// 角色ID'
        /// </summary>
        [Required]
        public virtual int Frole_id { get { return frole_id; } set { frole_id = value; } }

        protected int fuser_id = 0;
        /// <summary>
        /// 用户ID'
        /// </summary>
        [Required]        
        public virtual int Fuser_id { get { return fuser_id; } set { fuser_id = value; } }

        public SystemUserRoleRelationEntity() { }

        public SystemUserRoleRelationEntity(SystemUserRoleRelationEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Frole_id = rhs.Frole_id;
            this.Fuser_id = rhs.Fuser_id;
        }
    }
}
