using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_company_department")]
    public class CompanyDepartmentEntity : BaseEntity<int>
    {
        /// <summary>
        /// 部门名称'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fname { get; set; } = "";

        /// <summary>
        /// 部门全称'
        /// </summary>
        [MaxLength(60)]
        public virtual string Ffull_name { get; set; } = "";

        /// <summary>
        /// 部门编码'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fmark { get; set; } = "";

        /// <summary>
        /// 部门类型'
        /// </summary>
        public virtual int? Ftype { get; set; } = 0;

        /// <summary>
        /// 部门负责人'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fleader { get; set; } = "";

        /// <summary>
        /// 负责人电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fleader_phone { get; set; } = "";

        /// <summary>
        /// 部门电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fphone { get; set; } = "";

        /// <summary>
        /// 部门传真'
        /// </summary>
        [MaxLength(30)]
        public virtual string Ffax { get; set; } = "";

        /// <summary>
        /// 部门email'
        /// </summary>
        [MaxLength(30)]
        public virtual string Femail { get; set; } = "";

        /// <summary>
        /// 录入人'
        /// </summary>
        [MaxLength(30)]
        public virtual string Finputor { get; set; } = "";

        /// <summary>
        /// 创建时间'
        /// </summary>
        [Required]
        public virtual DateTime Fcreate_time { get; set; } = default(DateTime);

        /// <summary>
        /// 备注'
        /// </summary>
        [Required]
        [MaxLength(300)]
        public virtual string Fcomment { get; set; } = "";

        /// <summary>
        /// 隶属部门ID，0为不属于任何部门
        /// </summary>
        public virtual int? Fparent_department_id { get; set; } = 0;

        public CompanyDepartmentEntity() { }

        public CompanyDepartmentEntity(CompanyDepartmentEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fname = rhs.Fname;
            this.Ffull_name = rhs.Ffull_name;
            this.Fmark = rhs.Fmark;
            this.Ftype = rhs.Ftype;
            this.Fleader = rhs.Fleader;
            this.Fleader_phone = rhs.Fleader_phone;
            this.Fphone = rhs.Fphone;
            this.Ffax = rhs.Ffax;
            this.Femail = rhs.Femail;
            this.Finputor = rhs.Finputor;
            this.Fcreate_time = rhs.Fcreate_time;
            this.Fcomment = rhs.Fcomment;
            this.Fparent_department_id = rhs.Fparent_department_id;
        }


        public static bool operator ==(CompanyDepartmentEntity lhs, CompanyDepartmentEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fname == rhs.Fname &&
               lhs.Ffull_name == rhs.Ffull_name &&
               lhs.Fmark == rhs.Fmark &&
               lhs.Ftype == rhs.Ftype &&
               lhs.Fleader == rhs.Fleader &&
               lhs.Fleader_phone == rhs.Fleader_phone &&
               lhs.Fphone == rhs.Fphone &&
               lhs.Ffax == rhs.Ffax &&
               lhs.Femail == rhs.Femail &&
               lhs.Finputor == rhs.Finputor &&
               lhs.Fcreate_time == rhs.Fcreate_time &&
               lhs.Fcomment == rhs.Fcomment &&
               lhs.Fparent_department_id == rhs.Fparent_department_id
           );
        }

        public static bool operator !=(CompanyDepartmentEntity lhs, CompanyDepartmentEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
