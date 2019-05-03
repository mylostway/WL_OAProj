using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_book_space_receiver")]
    public class CustomerBookSpaceReceiverEntity : BaseEntity<int>,IComparable<CustomerBookSpaceReceiverEntity>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int Fcustomer_id { get; set; } = 0;

        /// <summary>
        /// 船公司'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string Fship_company { get; set; } = "";

        /// <summary>
        /// 订舱收货人'
        /// </summary>
        [MaxLength(100)]
        public virtual string Freceiver { get; set; } = "";

        /// <summary>
        /// 联系人'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fcontact { get; set; } = "";

        /// <summary>
        /// 电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fphone { get; set; } = "";

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; } = "";

        public CustomerBookSpaceReceiverEntity() { }

        public CustomerBookSpaceReceiverEntity(CustomerBookSpaceReceiverEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fcustomer_id = rhs.Fcustomer_id;
            this.Fship_company = rhs.Fship_company;
            this.Freceiver = rhs.Freceiver;
            this.Fcontact = rhs.Fcontact;
            this.Fphone = rhs.Fphone;
            this.Fmemo = rhs.Fmemo;
        }


        public static bool operator ==(CustomerBookSpaceReceiverEntity lhs, CustomerBookSpaceReceiverEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fcustomer_id == rhs.Fcustomer_id &&
               lhs.Fship_company == rhs.Fship_company &&
               lhs.Freceiver == rhs.Freceiver &&
               lhs.Fcontact == rhs.Fcontact &&
               lhs.Fphone == rhs.Fphone &&
               lhs.Fmemo == rhs.Fmemo
           );
        }

        public static bool operator !=(CustomerBookSpaceReceiverEntity lhs, CustomerBookSpaceReceiverEntity rhs)
        {
            return !(lhs == rhs);
        }

        public virtual int CompareTo(CustomerBookSpaceReceiverEntity other)
        {
            if (this == other) return 0;
            return 1;
        }
    }
}
