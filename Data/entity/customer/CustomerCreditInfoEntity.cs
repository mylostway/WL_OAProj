using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_credit_info")]
    public class CustomerCreditInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int Fcustomer_id { get; set; } = 0;

        /// <summary>
        /// 资信额度'
        /// </summary>
        public virtual int? Fcredit_limit { get; set; } = 0;

        /// <summary>
        /// 额度说明'
        /// </summary>
        [MaxLength(100)]
        public virtual string Flimit_memo { get; set; } = "";

        /// <summary>
        /// 数期'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fexponential { get; set; } = "";

        /// <summary>
        /// 币种'
        /// </summary>
        [MaxLength(10)]
        public virtual string Fcurrency { get; set; } = "";

        /// <summary>
        /// 评估类别'
        /// </summary>
        [MaxLength(30)]
        public virtual string Festimate_type { get; set; } = "";

        /// <summary>
        /// 付款评估'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fpay_estimate { get; set; } = "";

        /// <summary>
        /// 等级评估'
        /// </summary>
        [MaxLength(30)]
        public virtual string Flevel_estimate { get; set; } = "";

        /// <summary>
        /// 银行名称'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbank_name { get; set; } = "";

        /// <summary>
        /// 银行账号
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbank_account { get; set; } = "";

        public CustomerCreditInfoEntity() { }

        public CustomerCreditInfoEntity(CustomerCreditInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fcustomer_id = rhs.Fcustomer_id;
            this.Fcredit_limit = rhs.Fcredit_limit;
            this.Flimit_memo = rhs.Flimit_memo;
            this.Fexponential = rhs.Fexponential;
            this.Fcurrency = rhs.Fcurrency;
            this.Festimate_type = rhs.Festimate_type;
            this.Fpay_estimate = rhs.Fpay_estimate;
            this.Flevel_estimate = rhs.Flevel_estimate;
            this.Fbank_name = rhs.Fbank_name;
            this.Fbank_account = rhs.Fbank_account;
        }


        public static bool operator ==(CustomerCreditInfoEntity lhs, CustomerCreditInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fcustomer_id == rhs.Fcustomer_id &&
               lhs.Fcredit_limit == rhs.Fcredit_limit &&
               lhs.Flimit_memo == rhs.Flimit_memo &&
               lhs.Fexponential == rhs.Fexponential &&
               lhs.Fcurrency == rhs.Fcurrency &&
               lhs.Festimate_type == rhs.Festimate_type &&
               lhs.Fpay_estimate == rhs.Fpay_estimate &&
               lhs.Flevel_estimate == rhs.Flevel_estimate &&
               lhs.Fbank_name == rhs.Fbank_name &&
               lhs.Fbank_account == rhs.Fbank_account
           );
        }

        public static bool operator !=(CustomerCreditInfoEntity lhs, CustomerCreditInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
