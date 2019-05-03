using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_assurance_info")]
    public class FreBusinessAssuranceInfoEntity : BaseEntity<int>, IFreBusinessPartInfoEntity
    {
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get; set; } = "";

        /// <summary>
        /// 保险状态，按位取值，从低到高分别为 出险，承保'
        /// </summary>
        public virtual int? Fassurance_state { get; set; } = 0;

        /// <summary>
        /// 保险单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fassurance_no { get; set; } = "";

        /// <summary>
        /// 保费（金额，分）'
        /// </summary>
        public virtual int? Fassurance_fee { get; set; } = 0;

        /// <summary>
        /// 保险公司'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fassurance_company { get; set; } = "";

        /// <summary>
        /// 货值（金额，分）'
        /// </summary>
        public virtual int? Fgoods_val { get; set; } = 0;

        /// <summary>
        /// 保险类型'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fassurance_type { get; set; } = "";

        /// <summary>
        /// 承保信息'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fassurance_info { get; set; } = "";

        /// <summary>
        /// 费率（万分）
        /// </summary>
        public virtual int? Fassurance_rate { get; set; } = 0;

        public FreBusinessAssuranceInfoEntity() { }

        public FreBusinessAssuranceInfoEntity(FreBusinessAssuranceInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Flist_id = rhs.Flist_id;
            this.Fassurance_state = rhs.Fassurance_state;
            this.Fassurance_no = rhs.Fassurance_no;
            this.Fassurance_fee = rhs.Fassurance_fee;
            this.Fassurance_company = rhs.Fassurance_company;
            this.Fgoods_val = rhs.Fgoods_val;
            this.Fassurance_type = rhs.Fassurance_type;
            this.Fassurance_info = rhs.Fassurance_info;
            this.Fassurance_rate = rhs.Fassurance_rate;
        }


        public static bool operator ==(FreBusinessAssuranceInfoEntity lhs, FreBusinessAssuranceInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Flist_id == rhs.Flist_id &&
               lhs.Fassurance_state == rhs.Fassurance_state &&
               lhs.Fassurance_no == rhs.Fassurance_no &&
               lhs.Fassurance_fee == rhs.Fassurance_fee &&
               lhs.Fassurance_company == rhs.Fassurance_company &&
               lhs.Fgoods_val == rhs.Fgoods_val &&
               lhs.Fassurance_type == rhs.Fassurance_type &&
               lhs.Fassurance_info == rhs.Fassurance_info &&
               lhs.Fassurance_rate == rhs.Fassurance_rate
           );
        }

        public static bool operator !=(FreBusinessAssuranceInfoEntity lhs, FreBusinessAssuranceInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }

    
}
