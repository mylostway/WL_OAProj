using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_other_info")]
    public class CustomerOtherInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int Fcustomer_id { get; set; } = 0;

        /// <summary>
        /// 英文全称'
        /// </summary>
        [MaxLength(50)]
        public virtual string Feng_full_name { get; set; } = "";

        /// <summary>
        /// 英文简称'
        /// </summary>
        [MaxLength(20)]
        public virtual string Feng_for_short { get; set; } = "";

        /// <summary>
        /// 英文地址'
        /// </summary>
        [MaxLength(100)]
        public virtual string Feng_addr { get; set; } = "";

        /// <summary>
        /// 邮箱'
        /// </summary>
        [MaxLength(50)]
        public virtual string Femail { get; set; } = "";

        /// <summary>
        /// 省份'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fprovince { get; set; } = "";

        /// <summary>
        /// 城市'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcity { get; set; } = "";

        /// <summary>
        /// 区域'
        /// </summary>
        [MaxLength(50)]
        public virtual string Farea { get; set; } = "";

        /// <summary>
        /// 网址
        /// </summary>
        [MaxLength(100)]
        public virtual string Fwebsite { get; set; } = "";

        public CustomerOtherInfoEntity() { }

        public CustomerOtherInfoEntity(CustomerOtherInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fcustomer_id = rhs.Fcustomer_id;
            this.Feng_full_name = rhs.Feng_full_name;
            this.Feng_for_short = rhs.Feng_for_short;
            this.Feng_addr = rhs.Feng_addr;
            this.Femail = rhs.Femail;
            this.Fprovince = rhs.Fprovince;
            this.Fcity = rhs.Fcity;
            this.Farea = rhs.Farea;
            this.Fwebsite = rhs.Fwebsite;
        }


        public static bool operator ==(CustomerOtherInfoEntity lhs, CustomerOtherInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fcustomer_id == rhs.Fcustomer_id &&
               lhs.Feng_full_name == rhs.Feng_full_name &&
               lhs.Feng_for_short == rhs.Feng_for_short &&
               lhs.Feng_addr == rhs.Feng_addr &&
               lhs.Femail == rhs.Femail &&
               lhs.Fprovince == rhs.Fprovince &&
               lhs.Fcity == rhs.Fcity &&
               lhs.Farea == rhs.Farea &&
               lhs.Fwebsite == rhs.Fwebsite
           );
        }

        public static bool operator !=(CustomerOtherInfoEntity lhs, CustomerOtherInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
