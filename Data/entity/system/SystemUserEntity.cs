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
        protected string fuser_account = "";
        /// <summary>
        /// 用户ID，用户注册的账号
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fuser_account { get { return fuser_account; } set { fuser_account = value; } }

        protected string fname = "";
        /// <summary>
        /// 用户名'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fname { get { return fname; } set { fname = value; } }

        protected string fphone = "";
        /// <summary>
        /// 用户联系手机'
        /// </summary>
        [MaxLength(10)]
        public virtual string Fphone { get { return fphone; } set { fphone = value; } }

        protected string femail = "";
        /// <summary>
        /// 用户email'
        /// </summary>
        [MaxLength(30)]
        public virtual string Femail { get { return femail; } set { femail = value; } }

        protected int fdepartment_id = 0;
        /// <summary>
        /// 用户所属部门ID'
        /// </summary>
        public virtual int Fdepartment_id { get { return fdepartment_id; } set { fdepartment_id = value; } }

        protected int fsex = 0;
        /// <summary>
        /// 性别'
        /// </summary>
        public virtual int Fsex { get { return fsex; } set { fsex = value; } }

        protected string fcert = "";
        /// <summary>
        /// 证件'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fcert { get { return fcert; } set { fcert = value; } }

        protected DateTime fcreate_time = DateTime.Now;
        /// <summary>
        /// 创建时间'
        /// </summary>
        [Required]
        public virtual DateTime Fcreate_time { get { return fcreate_time; } set { fcreate_time = value; } }

        protected string fpassword = "";
        /// <summary>
        /// 密码MD5'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fpassword { get { return fpassword; } set { fpassword = value; } }

        public SystemUserEntity() { }

        public SystemUserEntity(SystemUserEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fuser_account = rhs.Fuser_account;
            this.Fname = rhs.Fname;
            this.Fphone = rhs.Fphone;
            this.Femail = rhs.Femail;
            this.Fdepartment_id = rhs.Fdepartment_id;
            this.Fsex = rhs.Fsex;
            this.Fcert = rhs.Fcert;
            this.Fcreate_time = rhs.Fcreate_time;
            this.Fpassword = rhs.Fpassword;
        }
    }
}
