using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace Data.entity
{
    [Table("t_customer_hold_addr")]
    public class CustomerHoldAddrEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int FcustomerId { get; set; }

        /// <summary>
        /// 货主'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string FgoodsOwner { get; set; }

        /// <summary>
        /// 货主APP ID'
        /// </summary>
        [MaxLength(50)]
        public virtual string FownerAppId { get; set; }

        /// <summary>
        /// 装卸货区域'
        /// </summary>
        [MaxLength(50)]
        public virtual string FholdArea { get; set; }

        /// <summary>
        /// 地点'
        /// </summary>
        [MaxLength(50)]
        public virtual string Faddr { get; set; }

        /// <summary>
        /// 装卸说明'
        /// </summary>
        [MaxLength(200)]
        public virtual string FholdMemo { get; set; }

        /// <summary>
        /// 收(发)货单位'
        /// </summary>
        [MaxLength(50)]
        public virtual string Funit { get; set; }

        /// <summary>
        /// 联系人'
        /// </summary>
        [MaxLength(50)]
        public virtual string FcontactMan { get; set; }

        /// <summary>
        /// 电话'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone { get; set; }

        /// <summary>
        /// 手机'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmobile { get; set; }

        /// <summary>
        /// 传真'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ffax { get; set; }

        /// <summary>
        /// 记录状态，按位取值，0 - 可用,1 - 是否发短信'
        /// </summary>
        public virtual int FdataStatus { get; set; }

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [MaxLength(200)]
        public virtual string Forder { get; set; }

    }
}
