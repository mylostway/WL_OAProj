using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_system_user")]
    public class SystemUserEntity : BaseEntity<int>
    {
        /// <summary>
        /// 用户账号'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fuser_account { get; set; } = "";

        /// <summary>
        /// 用户姓名'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fname { get; set; } = "";

        /// <summary>
        /// 注册来源'
        /// </summary>
        public virtual int? Fsource { get; set; } = 0;

        /// <summary>
        /// 用户联系手机'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fphone { get; set; } = "";

        /// <summary>
        /// 用户email'
        /// </summary>
        [MaxLength(30)]
        public virtual string Femail { get; set; } = "";

        /// <summary>
        /// 用户所属部门ID'
        /// </summary>
        public virtual int? Fdepartment_id { get; set; } = 0;

        /// <summary>
        /// 性别,1 - 男 2 - 女'
        /// </summary>
        public virtual int? Fsex { get; set; } = 0;

        /// <summary>
        /// 证件'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fcert { get; set; } = "";

        /// <summary>
        /// 创建时间'
        /// </summary>
        public virtual DateTime Fcreate_time { get; set; } = default(DateTime);

        /// <summary>
        /// 密码MD5'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fpassword { get; set; } = "";

        /// <summary>
        /// 认证状态 0 - 未认证 1 - 已认证'
        /// </summary>
        public virtual int? Fcheck_state { get; set; } = 0;

        /// <summary>
        /// 安全设备Id
        /// </summary>
        [MaxLength(50)]
        public virtual string Fsafe_dev_id { get; set; } = "";


        /// <summary>
        /// 创建用户的人
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcreate_user { get; set; } = "";

        public SystemUserEntity() { }

        public SystemUserEntity(SystemUserEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fuser_account = rhs.Fuser_account;
            this.Fname = rhs.Fname;
            this.Fsource = rhs.Fsource;
            this.Fphone = rhs.Fphone;
            this.Femail = rhs.Femail;
            this.Fdepartment_id = rhs.Fdepartment_id;
            this.Fsex = rhs.Fsex;
            this.Fcert = rhs.Fcert;
            this.Fcreate_time = rhs.Fcreate_time;
            this.Fpassword = rhs.Fpassword;
            this.Fcheck_state = rhs.Fcheck_state;
            this.Fsafe_dev_id = rhs.Fsafe_dev_id;
            this.Fcreate_user = rhs.Fcreate_user;
        }


        public static bool operator ==(SystemUserEntity lhs, SystemUserEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fuser_account == rhs.Fuser_account &&
               lhs.Fname == rhs.Fname &&
               lhs.Fsource == rhs.Fsource &&
               lhs.Fphone == rhs.Fphone &&
               lhs.Femail == rhs.Femail &&
               lhs.Fdepartment_id == rhs.Fdepartment_id &&
               lhs.Fsex == rhs.Fsex &&
               lhs.Fcert == rhs.Fcert &&
               lhs.Fcreate_time == rhs.Fcreate_time &&
               lhs.Fpassword == rhs.Fpassword &&
               lhs.Fcheck_state == rhs.Fcheck_state &&
               lhs.Fsafe_dev_id == rhs.Fsafe_dev_id &&
               lhs.Fcreate_user == rhs.Fcreate_user
           );
        }

        public static bool operator !=(SystemUserEntity lhs, SystemUserEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
