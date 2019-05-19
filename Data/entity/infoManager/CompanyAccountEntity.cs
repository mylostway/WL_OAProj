using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_company_account")]
    public class CompanyAccountEntity : BaseEntity<int>
    {
        /// <summary>
        /// 公司账号'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Faccount { get; set; } = "";

        /// <summary>
        /// 开户银行（中文）'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fbank_name { get; set; } = "";

        /// <summary>
        /// 开户银行（英文）'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbank_eng_Name { get; set; } = "";

        /// <summary>
        /// 开户名称'
        /// </summary>
        [MaxLength(60)]
        public virtual string Faccount_name { get; set; } = "";

        /// <summary>
        /// 地址'
        /// </summary>
        [MaxLength(300)]
        public virtual string Faddr { get; set; } = "";

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
        /// 凭证默认调用,0 - 否
        /// </summary>
        public virtual int? Fcert_default_use { get; set; } = 0;

        public CompanyAccountEntity() { }

        public CompanyAccountEntity(CompanyAccountEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Faccount = rhs.Faccount;
            this.Fbank_name = rhs.Fbank_name;
            this.Fbank_eng_Name = rhs.Fbank_eng_Name;
            this.Faccount_name = rhs.Faccount_name;
            this.Faddr = rhs.Faddr;
            this.Fmemo = rhs.Fmemo;
            this.Finput_date = rhs.Finput_date;
            this.Finputor = rhs.Finputor;
            this.Fusable = rhs.Fusable;
            this.Fcert_default_use = rhs.Fcert_default_use;
        }


        public static bool operator ==(CompanyAccountEntity lhs, CompanyAccountEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Faccount == rhs.Faccount &&
               lhs.Fbank_name == rhs.Fbank_name &&
               lhs.Fbank_eng_Name == rhs.Fbank_eng_Name &&
               lhs.Faccount_name == rhs.Faccount_name &&
               lhs.Faddr == rhs.Faddr &&
               lhs.Fmemo == rhs.Fmemo &&
               lhs.Finput_date == rhs.Finput_date &&
               lhs.Finputor == rhs.Finputor &&
               lhs.Fusable == rhs.Fusable &&
               lhs.Fcert_default_use == rhs.Fcert_default_use
           );
        }

        public static bool operator !=(CompanyAccountEntity lhs, CompanyAccountEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
