using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity.company
{
    [Table("t_company_department")]
    public class CompanyDepartmentEntity : BaseEntity<int>
    {
        protected string fname = "";
        /// <summary>
        /// 部门名称'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fname { get { return fname; } set { fname = value; } }

        protected DateTime fcreate_time = DateTime.Now;
        /// <summary>
        /// 创建时间'
        /// </summary>
        [Required]
        public virtual DateTime Fcreate_time { get { return fcreate_time; } set { fcreate_time = value; } }

        protected string fcomment = "";
        /// <summary>
        /// 备注
        /// </summary>
        [Required]
        [MaxLength(300)]
        public virtual string Fcomment { get { return fcomment; } set { fcomment = value; } }

        public CompanyDepartmentEntity() { }

        public CompanyDepartmentEntity(CompanyDepartmentEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fname = rhs.Fname;
            this.Fcreate_time = rhs.Fcreate_time;
            this.Fcomment = rhs.Fcomment;
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
               lhs.Fcreate_time == rhs.Fcreate_time &&
               lhs.Fcomment == rhs.Fcomment
           );
        }

        public static bool operator !=(CompanyDepartmentEntity lhs, CompanyDepartmentEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
