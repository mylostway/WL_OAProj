using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_book_space_receiver")]
    public class CustomerBookSpaceReceiverEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int FcustomerId { get; set; }

        /// <summary>
        /// 船公司'
        /// </summary>
        [Required]
        [MaxLength(100)]
        public virtual string FshipCompany { get; set; }

        /// <summary>
        /// 订舱收货人'
        /// </summary>
        [MaxLength(100)]
        public virtual string Freceiver { get; set; }

        /// <summary>
        /// 联系人'
        /// </summary>
        [MaxLength(100)]
        public virtual string Fcontact { get; set; }

        /// <summary>
        /// 电话'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fphone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; }

    }
}
