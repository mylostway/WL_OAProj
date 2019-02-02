using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_company_system_info")]
    public class CompanySystemInfoEntity : BaseEntity<int>
    {
        protected string fname = "";
        /// <summary>
        /// 公司名称'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fname { get { return fname; } set { fname = value; } }

        protected string fsys_name = "";
        /// <summary>
        /// 公司系统名称 - 通常取公司名称拼音，用作各业务前缀'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fsys_name { get { return fsys_name; } set { fsys_name = value; } }

        protected DateTime freg_time = DateTime.Now;
        /// <summary>
        /// 注册时间'
        /// </summary>
        public virtual DateTime Freg_time { get { return freg_time; } set { freg_time = value; } }

        protected string faddr = "";
        /// <summary>
        /// 公司地址'
        /// </summary>
        [MaxLength(300)]
        public virtual string Faddr { get { return faddr; } set { faddr = value; } }

        protected string fcontact_way1 = "";
        /// <summary>
        /// 联系方式1'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fcontact_way1 { get { return fcontact_way1; } set { fcontact_way1 = value; } }

        protected string fcontact_way2 = "";
        /// <summary>
        /// 联系方式2'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fcontact_way2 { get { return fcontact_way2; } set { fcontact_way2 = value; } }

        protected string fcorporate = "";
        /// <summary>
        /// 法人'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fcorporate { get { return fcorporate; } set { fcorporate = value; } }

        protected string fmemo = "";
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(300)]
        public virtual string Fmemo { get { return fmemo; } set { fmemo = value; } }

        public CompanySystemInfoEntity() { }

        public CompanySystemInfoEntity(CompanySystemInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fname = rhs.Fname;
            this.Fsys_name = rhs.Fsys_name;
            this.Freg_time = rhs.Freg_time;
            this.Faddr = rhs.Faddr;
            this.Fcontact_way1 = rhs.Fcontact_way1;
            this.Fcontact_way2 = rhs.Fcontact_way2;
            this.Fcorporate = rhs.Fcorporate;
            this.Fmemo = rhs.Fmemo;
        }
    }
}
