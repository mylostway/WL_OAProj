using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    //[Table("t_customer_other_info")]
    public class CustomerOtherInfoEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int FcustomerId { get; set; }

        /// <summary>
        /// 英文全称'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string FengFullName { get; set; }

        /// <summary>
        /// 英文简称'
        /// </summary>
        [MaxLength(20)]
        public virtual string FengForShort { get; set; }

        /// <summary>
        /// 英文地址'
        /// </summary>
        [MaxLength(100)]
        public virtual string FengAddr { get; set; }

        /// <summary>
        /// 邮箱'
        /// </summary>
        [MaxLength(50)]
        public virtual string Femail { get; set; }

        /// <summary>
        /// 省份'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fprovince { get; set; }

        /// <summary>
        /// 城市'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcity { get; set; }

        /// <summary>
        /// 区域'
        /// </summary>
        [MaxLength(50)]
        public virtual string Farea { get; set; }

        /// <summary>
        /// 网址
        /// </summary>
        [MaxLength(100)]
        public virtual string Fwebsite { get; set; }

    }
}
