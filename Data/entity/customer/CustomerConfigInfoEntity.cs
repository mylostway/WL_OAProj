using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_config_info")]
    public class CustomerConfigInfoEntity : BaseEntity<int>, IComparable<CustomerConfigInfoEntity>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int Fcustomer_id { get; set; } = 0;

        /// <summary>
        /// 企业物流号(列表选择)'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcompany_logistics_id { get; set; } = "";

        /// <summary>
        /// 关联企业(列表选择)'
        /// </summary>
        [MaxLength(50)]
        public virtual string Flinked_company { get; set; } = "";

        /// <summary>
        /// 所属船公司(列表选择)'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fbelongs_ship_company { get; set; } = "";

        /// <summary>
        /// 货主APP-ID'
        /// </summary>
        [MaxLength(10)]
        public virtual string Fgoods_owner_app_id { get; set; } = "";

        /// <summary>
        /// 记录状态，按位取值，0 - 是否白名单车队
        /// </summary>
        [BitUsageField(1, "状态值有误")]
        public virtual int? Fdata_status { get; set; } = 0;

        public CustomerConfigInfoEntity() { }

        public CustomerConfigInfoEntity(CustomerConfigInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fcustomer_id = rhs.Fcustomer_id;
            this.Fcompany_logistics_id = rhs.Fcompany_logistics_id;
            this.Flinked_company = rhs.Flinked_company;
            this.Fbelongs_ship_company = rhs.Fbelongs_ship_company;
            this.Fgoods_owner_app_id = rhs.Fgoods_owner_app_id;
            this.Fdata_status = rhs.Fdata_status;
        }


        public static bool operator ==(CustomerConfigInfoEntity lhs, CustomerConfigInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fcustomer_id == rhs.Fcustomer_id &&
               lhs.Fcompany_logistics_id == rhs.Fcompany_logistics_id &&
               lhs.Flinked_company == rhs.Flinked_company &&
               lhs.Fbelongs_ship_company == rhs.Fbelongs_ship_company &&
               lhs.Fgoods_owner_app_id == rhs.Fgoods_owner_app_id &&
               lhs.Fdata_status == rhs.Fdata_status
           );
        }

        public static bool operator !=(CustomerConfigInfoEntity lhs, CustomerConfigInfoEntity rhs)
        {
            return !(lhs == rhs);
        }

        public virtual int CompareTo(CustomerConfigInfoEntity other)
        {
            if (this == other) return 0;
            return 1;
        }
    }
}
