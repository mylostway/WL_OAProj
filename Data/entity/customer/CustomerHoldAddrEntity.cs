using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_hold_addr")]
    public class CustomerHoldAddrEntity : BaseEntity<int>, IComparable<CustomerHoldAddrEntity>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int Fcustomer_id { get; set; } = default(int);

        /// <summary>
        /// 货主'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fgoods_owner { get; set; } = "";

        /// <summary>
        /// 货主APP ID'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fowner_app_id { get; set; } = "";

        /// <summary>
        /// 装卸货区域'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fhold_area { get; set; } = "";

        /// <summary>
        /// 地点'
        /// </summary>
        [MaxLength(50)]
        public virtual string Faddr { get; set; } = "";

        /// <summary>
        /// 装卸说明'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fhold_memo { get; set; } = "";

        /// <summary>
        /// 收(发)货单位'
        /// </summary>
        [MaxLength(50)]
        public virtual string Funit { get; set; } = "";

        /// <summary>
        /// 联系人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcontact_man { get; set; } = "";

        /// <summary>
        /// 电话'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone { get; set; } = "";

        /// <summary>
        /// 手机'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmobile { get; set; } = "";

        /// <summary>
        /// 传真'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ffax { get; set; } = "";

        /// <summary>
        /// 记录状态，按位取值，0 - 可用,1 - 是否发短信'
        /// </summary>
        [BitUsageField(2, "错误的记录状态")]
        public virtual int? Fdata_status { get; set; } = 0;

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; } = "";

        /// <summary>
        /// 排序号
        /// </summary>
        [MaxLength(200)]
        public virtual string Forder { get; set; } = "";

        public CustomerHoldAddrEntity() { }

        public CustomerHoldAddrEntity(CustomerHoldAddrEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fcustomer_id = rhs.Fcustomer_id;
            this.Fgoods_owner = rhs.Fgoods_owner;
            this.Fowner_app_id = rhs.Fowner_app_id;
            this.Fhold_area = rhs.Fhold_area;
            this.Faddr = rhs.Faddr;
            this.Fhold_memo = rhs.Fhold_memo;
            this.Funit = rhs.Funit;
            this.Fcontact_man = rhs.Fcontact_man;
            this.Fphone = rhs.Fphone;
            this.Fmobile = rhs.Fmobile;
            this.Ffax = rhs.Ffax;
            this.Fdata_status = rhs.Fdata_status;
            this.Fmemo = rhs.Fmemo;
            this.Forder = rhs.Forder;
        }


        public static bool operator ==(CustomerHoldAddrEntity lhs, CustomerHoldAddrEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fcustomer_id == rhs.Fcustomer_id &&
               lhs.Fgoods_owner == rhs.Fgoods_owner &&
               lhs.Fowner_app_id == rhs.Fowner_app_id &&
               lhs.Fhold_area == rhs.Fhold_area &&
               lhs.Faddr == rhs.Faddr &&
               lhs.Fhold_memo == rhs.Fhold_memo &&
               lhs.Funit == rhs.Funit &&
               lhs.Fcontact_man == rhs.Fcontact_man &&
               lhs.Fphone == rhs.Fphone &&
               lhs.Fmobile == rhs.Fmobile &&
               lhs.Ffax == rhs.Ffax &&
               lhs.Fdata_status == rhs.Fdata_status &&
               lhs.Fmemo == rhs.Fmemo &&
               lhs.Forder == rhs.Forder
           );
        }

        public static bool operator !=(CustomerHoldAddrEntity lhs, CustomerHoldAddrEntity rhs)
        {
            return !(lhs == rhs);
        }

        public virtual int CompareTo(CustomerHoldAddrEntity other)
        {
            if (this == other) return 0;
            return 1;
        }
    }
  
}
