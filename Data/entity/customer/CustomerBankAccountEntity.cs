using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_bank_account")]
    public class CustomerBankAccountEntity : BaseEntity<int>,IComparable<CustomerBankAccountEntity>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int Fcustomer_id { get; set; } = 0;

        /// <summary>
        /// 开户行'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fbank_deposit { get; set; } = "";

        /// <summary>
        /// 账号'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Faccount { get; set; } = "";

        /// <summary>
        /// 开户名'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fdeposit_name { get; set; } = "";

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; } = "";

        public CustomerBankAccountEntity() { }

        public CustomerBankAccountEntity(CustomerBankAccountEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fcustomer_id = rhs.Fcustomer_id;
            this.Fbank_deposit = rhs.Fbank_deposit;
            this.Faccount = rhs.Faccount;
            this.Fdeposit_name = rhs.Fdeposit_name;
            this.Fmemo = rhs.Fmemo;
        }


        public static bool operator ==(CustomerBankAccountEntity lhs, CustomerBankAccountEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fcustomer_id == rhs.Fcustomer_id &&
               lhs.Fbank_deposit == rhs.Fbank_deposit &&
               lhs.Faccount == rhs.Faccount &&
               lhs.Fdeposit_name == rhs.Fdeposit_name &&
               lhs.Fmemo == rhs.Fmemo
           );
        }

        public static bool operator !=(CustomerBankAccountEntity lhs, CustomerBankAccountEntity rhs)
        {
            return !(lhs == rhs);
        }

        public virtual int CompareTo(CustomerBankAccountEntity other)
        {
            if (other == this) return 0;
            return 1;
        }
    }
}
