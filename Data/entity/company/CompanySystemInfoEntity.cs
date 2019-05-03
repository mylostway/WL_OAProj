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
        /// <summary>
        /// 公司名称'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fname { get; set; } = "";

        /// <summary>
        /// 公司系统名称 - 通常取公司名称拼音，用作各业务前缀'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fsys_name { get; set; } = "";

        /// <summary>
        /// 注册时间'
        /// </summary>
        public virtual DateTime? Freg_time { get; set; } = default(DateTime?);

        /// <summary>
        /// 公司地址'
        /// </summary>
        [MaxLength(300)]
        public virtual string Faddr { get; set; } = "";

        /// <summary>
        /// 联系方式1'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fcontact_way1 { get; set; } = "";

        /// <summary>
        /// 联系方式2'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fcontact_way2 { get; set; } = "";

        /// <summary>
        /// 法人'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fcorporate { get; set; } = "";

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(300)]
        public virtual string Fmemo { get; set; } = "";

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


        public static bool operator ==(CompanySystemInfoEntity lhs, CompanySystemInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fname == rhs.Fname &&
               lhs.Fsys_name == rhs.Fsys_name &&
               lhs.Freg_time == rhs.Freg_time &&
               lhs.Faddr == rhs.Faddr &&
               lhs.Fcontact_way1 == rhs.Fcontact_way1 &&
               lhs.Fcontact_way2 == rhs.Fcontact_way2 &&
               lhs.Fcorporate == rhs.Fcorporate &&
               lhs.Fmemo == rhs.Fmemo
           );
        }

        public static bool operator !=(CompanySystemInfoEntity lhs, CompanySystemInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
