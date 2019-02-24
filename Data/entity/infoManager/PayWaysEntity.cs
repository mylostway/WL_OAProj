using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_pay_ways")]
    public class PayWaysEntity : BaseEntity<int>
    {
        /// <summary>
        /// 助记码'
        /// </summary>
        [Required]
        [MaxLength(15)]
        public virtual string Fmark { get; set; }

        /// <summary>
        /// 结算方式名称（中文）'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fchn_Name { get; set; }

        /// <summary>
        /// 结算方式名称（英文）'
        /// </summary>
        [MaxLength(30)]
        public virtual string Feng_Name { get; set; }

        /// <summary>
        /// 标志-可用
        /// </summary>
        public virtual int Fusable { get; set; }

        public PayWaysEntity() { }

        public PayWaysEntity(PayWaysEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fmark = rhs.Fmark;
            this.Fchn_Name = rhs.Fchn_Name;
            this.Feng_Name = rhs.Feng_Name;
            this.Fusable = rhs.Fusable;
        }


        public static bool operator ==(PayWaysEntity lhs, PayWaysEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fmark == rhs.Fmark &&
               lhs.Fchn_Name == rhs.Fchn_Name &&
               lhs.Feng_Name == rhs.Feng_Name &&
               lhs.Fusable == rhs.Fusable
           );
        }

        public static bool operator !=(PayWaysEntity lhs, PayWaysEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
