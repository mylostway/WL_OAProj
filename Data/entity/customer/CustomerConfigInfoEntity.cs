using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    [Table("t_customer_config_info")]
    public class CustomerConfigInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int FcustomerId { get; set; }

        /// <summary>
        /// 企业物流号(列表选择)'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string FcompanyLogisticsId { get; set; }

        /// <summary>
        /// 关联企业(列表选择)'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string FlinkedCompany { get; set; }

        /// <summary>
        /// 所属船公司(列表选择)'
        /// </summary>
        [MaxLength(100)]
        public virtual string FbelongsShipCompany { get; set; }

        /// <summary>
        /// 货主APP-ID'
        /// </summary>
        [MaxLength(10)]
        public virtual string FgoodsOwnerAppId { get; set; }

        /// <summary>
        /// 记录状态，按位取值，0 - 是否白名单车队
        /// </summary>
        public virtual int FdataStatus { get; set; }

    }
}
