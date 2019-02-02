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
        protected string flist_id = "";
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get { return flist_id; } set { flist_id = value; } }

        protected int fassurance_state = 0;
        /// <summary>
        /// 保险状态，按位取值，从低到高分别为 出险，承保'
        /// </summary>
        public virtual int Fassurance_state { get { return fassurance_state; } set { fassurance_state = value; } }

        protected string fassurance_no = "";
        /// <summary>
        /// 保险单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fassurance_no { get { return fassurance_no; } set { fassurance_no = value; } }

        protected int fassurance_fee = 0;
        /// <summary>
        /// 保费（金额，分）'
        /// </summary>
        public virtual int Fassurance_fee { get { return fassurance_fee; } set { fassurance_fee = value; } }

        protected string fassurance_company = "";
        /// <summary>
        /// 保险公司'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fassurance_company { get { return fassurance_company; } set { fassurance_company = value; } }

        protected int fgoods_val = 0;
        /// <summary>
        /// 货值（金额，分）'
        /// </summary>
        public virtual int Fgoods_val { get { return fgoods_val; } set { fgoods_val = value; } }

        protected int fassurance_type = 0;
        /// <summary>
        /// 保险类型'
        /// </summary>
        [Range((int)FreBusinessInsurTypeEnums.None, (int)FreBusinessInsurTypeEnums.Basic, ErrorMessage = "非法的保险类型")]
        public virtual int Fassurance_type { get { return fassurance_type; } set { fassurance_type = value; } }

        protected string fassurance_info = "";
        /// <summary>
        /// 承保信息'
        /// </summary>
        [MaxLength(32)]
        public virtual string Fassurance_info { get { return fassurance_info; } set { fassurance_info = value; } }

        protected int fassurance_rate = 0;
        /// <summary>
        /// 费率（万分）
        /// </summary>
        public virtual int Fassurance_rate { get { return fassurance_rate; } set { fassurance_rate = value; } }

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
