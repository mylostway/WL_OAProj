using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    //[Table("t_customer_contact")]
    public class CustomerContactEntity : BaseEntity<int>
    {
        /// <summary>
        /// 联系人所属公司id'
        /// </summary>
        [Required]
        public virtual int FcustomerId { get; set; }

        /// <summary>
        /// 联系人'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string Fname { get; set; }

        /// <summary>
        /// 部门'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fdepartment { get; set; }

        /// <summary>
        /// 公司电话'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone { get; set; }

        /// <summary>
        /// 公司传真'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ffax { get; set; }

        /// <summary>
        /// 移动电话'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmobile { get; set; }

        /// <summary>
        /// 身份证号码'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcert { get; set; }

        /// <summary>
        /// 性别 0 -- 未知 1 - 男 2 - 女'
        /// </summary>
        [Range((int)SexEnums.None, (int)SexEnums.Female, ErrorMessage = "非法的性别类型")]
        public virtual int Fsex { get; set; }

        /// <summary>
        /// 职务'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fjob { get; set; }

        /// <summary>
        /// QQ号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fqq { get; set; }

        /// <summary>
        /// 微信号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fwx { get; set; }

        /// <summary>
        /// 公司电话2'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone2 { get; set; }

        /// <summary>
        /// 公司电话3'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone3 { get; set; }

        /// <summary>
        /// 公司电话4'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone4 { get; set; }

        /// <summary>
        /// 公司电话5'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fphone5 { get; set; }

        /// <summary>
        /// 记录状态，按位取值，0 - 可用'
        /// </summary>
        [BitUsageField(1)]
        public virtual int FdataStatus { get; set; }

        /// <summary>
        /// 备注'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo { get; set; }

        /// <summary>
        /// 备注2'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo2 { get; set; }

        /// <summary>
        /// 备注3'
        /// </summary>
        [MaxLength(200)]
        public virtual string Fmemo3 { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [MaxLength(200)]
        public virtual string Forder { get; set; }

    }
}
