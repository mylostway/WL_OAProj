using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_input_info")]
    public class CustomerInputInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int Fcustomer_id { get; set; } = 0;

        /// <summary>
        /// 录入员'
        /// </summary>
        [MaxLength(50)]
        public virtual string Finputor { get; set; } = "";

        /// <summary>
        /// 录入时间'
        /// </summary>
        public virtual DateTime? Finput_time { get; set; } = default(DateTime?);

        /// <summary>
        /// 所属部门(列表选择)'
        /// </summary>
        [Required]
        [MaxLength(100)]

        public virtual string Fdepartment { get; set; } = "";

        /// <summary>
        /// 审核人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Faduitor { get; set; } = "";

        /// <summary>
        /// 审核时间
        /// </summary>
        public virtual DateTime? Faduit_time { get; set; } = default(DateTime?);

        public CustomerInputInfoEntity() { }

        public CustomerInputInfoEntity(CustomerInputInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Fcustomer_id = rhs.Fcustomer_id;
            this.Finputor = rhs.Finputor;
            this.Finput_time = rhs.Finput_time;
            this.Fdepartment = rhs.Fdepartment;
            this.Faduitor = rhs.Faduitor;
            this.Faduit_time = rhs.Faduit_time;
        }


        public static bool operator ==(CustomerInputInfoEntity lhs, CustomerInputInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Fcustomer_id == rhs.Fcustomer_id &&
               lhs.Finputor == rhs.Finputor &&
               lhs.Finput_time == rhs.Finput_time &&
               lhs.Fdepartment == rhs.Fdepartment &&
               lhs.Faduitor == rhs.Faduitor &&
               lhs.Faduit_time == rhs.Faduit_time
           );
        }

        public static bool operator !=(CustomerInputInfoEntity lhs, CustomerInputInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
