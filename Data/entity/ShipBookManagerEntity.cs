using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace WL_OA.Data.entity
{
    /// <summary>
    /// 预定舱管理Entity
    /// </summary>
    [Table("t_ship_book_manager")]
    public class ShipBookManagerEntity : BaseEntity<int>
    {
        /// <summary>
        /// 船公司'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string FshipCompany { get; set; }

        /// <summary>
        /// 船名'
        /// </summary>
        [MaxLength(30)]
        public virtual string FshipName { get; set; }

        /// <summary>
        /// 航次'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string FshipTNo { get; set; }

        /// <summary>
        /// 起运港'
        /// </summary>
        [MaxLength(30)]
        public virtual string FshipStartWharf { get; set; }

        /// <summary>
        /// 目的港'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string FshipToWharf { get; set; }

        /// <summary>
        /// 运单号'
        /// </summary>
        [MaxLength(50)]
        public virtual string FshipTransNo { get; set; }

        /// <summary>
        /// 订舱日期'
        /// </summary>
        public virtual DateTime FshipBookDate { get; set; }

        /// <summary>
        /// 预开船期'
        /// </summary>
        public virtual DateTime FshipScheduleDate { get; set; }

        /// <summary>
        /// 柜型'
        /// </summary>
        [MaxLength(30)]
        public virtual string FshipCabinetType { get; set; }

        /// <summary>
        /// 柜量'
        /// </summary>
        public virtual int FshipCabinetAmt { get; set; }

        /// <summary>
        /// 取消数量'
        /// </summary>
        public virtual int FshipCancelAmt { get; set; }

        /// <summary>
        /// 已用数量'
        /// </summary>
        public virtual int FshipUsedAmt { get; set; }

        /// <summary>
        /// 启用'
        /// </summary>
        public virtual int FshipIsUsed { get; set; }

        /// <summary>
        /// 订舱委托单号'
        /// </summary>
        [MaxLength(50)]
        public virtual string FshipDelegateTransNo { get; set; }

        /// <summary>
        /// 收货单位'
        /// </summary>
        [MaxLength(30)]
        public virtual string FshipTakeUnit { get; set; }

        /// <summary>
        /// 订舱代理'
        /// </summary>
        [MaxLength(30)]
        public virtual string FshipBookProxy { get; set; }

        /// <summary>
        /// 单柜成本'
        /// </summary>
        [MaxLength(30)]
        public virtual string FshipPerCost { get; set; }

        /// <summary>
        /// 业务员'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusinesser { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(100)]
        public virtual string Fmemo { get; set; }

    }
}
