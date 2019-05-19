using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fee_project")]
    public class FeeProjectEntity : BaseEntity<int>
    {
        /// <summary>
        /// 助记码'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fmark { get; set; } = "";

        /// <summary>
        /// 项目名称'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fproj_name { get; set; } = "";

        /// <summary>
        /// 项目全称（中文）'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fproj_full_name { get; set; } = "";

        /// <summary>
        /// 项目全称（英文）'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fproj_full_eng_name { get; set; } = "";

        /// <summary>
        /// 费用科目'
        /// </summary>
        [MaxLength(100)]
        public virtual string Ffee_subject { get; set; } = "";

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(300)]
        public virtual string Fmemo { get; set; } = "";

        /// <summary>
        /// 录入时间'
        /// </summary>
        public virtual DateTime? Finput_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 录入人'
        /// </summary>
        [MaxLength(100)]
        public virtual string Finputor { get; set; } = "";

        /// <summary>
        /// 是否可用，0 - 是，其他 - 否'
        /// </summary>
        public virtual int? Fusable { get; set; } = 0;

        /// <summary>
        /// 无关,0 - 否
        /// </summary>
        public virtual int? Fnot_concerned { get; set; } = 0;

        public FeeProjectEntity() { }

        public FeeProjectEntity(FeeProjectEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fmark = rhs.Fmark;
            this.Fproj_name = rhs.Fproj_name;
            this.Fproj_full_name = rhs.Fproj_full_name;
            this.Fproj_full_eng_name = rhs.Fproj_full_eng_name;
            this.Ffee_subject = rhs.Ffee_subject;
            this.Fmemo = rhs.Fmemo;
            this.Finput_date = rhs.Finput_date;
            this.Finputor = rhs.Finputor;
            this.Fusable = rhs.Fusable;
            this.Fnot_concerned = rhs.Fnot_concerned;
        }


        public static bool operator ==(FeeProjectEntity lhs, FeeProjectEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fmark == rhs.Fmark &&
               lhs.Fproj_name == rhs.Fproj_name &&
               lhs.Fproj_full_name == rhs.Fproj_full_name &&
               lhs.Fproj_full_eng_name == rhs.Fproj_full_eng_name &&
               lhs.Ffee_subject == rhs.Ffee_subject &&
               lhs.Fmemo == rhs.Fmemo &&
               lhs.Finput_date == rhs.Finput_date &&
               lhs.Finputor == rhs.Finputor &&
               lhs.Fusable == rhs.Fusable &&
               lhs.Fnot_concerned == rhs.Fnot_concerned
           );
        }

        public static bool operator !=(FeeProjectEntity lhs, FeeProjectEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
