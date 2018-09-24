using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace Data.entity
{
    /// <summary>
    /// 货代业务信息中心Entity
    /// </summary>
    [Table("t_fre_business_center")]
    public class FreBusinessCenterEntity : BaseEntity<int>
    {
        /// <summary>
        /// 物流动态 - 未知填什么值'
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string FinterflowState { get; set; }

        /// <summary>
        /// 托运人'
        /// </summary>
        [MaxLength(30)]
        public virtual string FconsignMan { get; set; }

        /// <summary>
        /// 起运码头'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string FstartWharf { get; set; }

        /// <summary>
        /// 起运地'
        /// </summary>
        [MaxLength(30)]
        public virtual string FstartPlace { get; set; }

        /// <summary>
        /// 目的地'
        /// </summary>
        [MaxLength(50)]
        public virtual string FtoPlace { get; set; }

        /// <summary>
        /// 目的码头'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string FtoWharf { get; set; }

        /// <summary>
        /// 业务日期'
        /// </summary>
        public virtual DateTime FbusinessDate { get; set; }

        /// <summary>
        /// 业务员'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusinesser { get; set; }

        /// <summary>
        /// 货名'
        /// </summary>
        [Required]
        [MaxLength(60)]
        public virtual string FgoodsName { get; set; }

        /// <summary>
        /// 装货低点'
        /// </summary>
        [Required]
        [MaxLength(60)]
        public virtual string FholdGoodsPlace { get; set; }

        /// <summary>
        /// 装货联系人'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string FholdGoodsPeoplePhone { get; set; }

        /// <summary>
        /// 卸货低点'
        /// </summary>
        [Required]
        [MaxLength(60)]
        public virtual string FputGoodsPlace { get; set; }

        /// <summary>
        /// 卸货联系人'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string FputGoodsPeoplePhone { get; set; }

        /// <summary>
        /// 操作条款'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string FopTerm { get; set; }

        /// <summary>
        /// 运输条款'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string FtransitTerm { get; set; }

        /// <summary>
        /// 付款方式'
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string FpayWay { get; set; }

        /// <summary>
        /// 工单号'
        /// </summary>
        [Required]
        [MaxLength(40)]
        public virtual string FworkOrderNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual int FrecordState { get; set; }

        /// <summary>
        /// 船公司'
        /// </summary>
        [Required]
        [MaxLength(40)]
        public virtual string FshipCompany { get; set; }

        /// <summary>
        /// 干线船名'
        /// </summary>
        [Required]
        [MaxLength(40)]
        public virtual string FshipMainShipName { get; set; }

        /// <summary>
        /// 干线航次'
        /// </summary>
        [Required]
        [MaxLength(40)]
        public virtual string FshipMainLineNo { get; set; }

        /// <summary>
        /// 运单号'
        /// </summary>
        [MaxLength(50)]
        public virtual string FshipTransNo { get; set; }

        /// <summary>
        /// 起始拖车'
        /// </summary>
        [MaxLength(50)]
        public virtual string FstartTrailCar { get; set; }

        /// <summary>
        /// 装货日期'
        /// </summary>
        public virtual DateTime FholdGoodsDate { get; set; }

        /// <summary>
        /// 目的拖车'
        /// </summary>
        [MaxLength(50)]
        public virtual string FtoTrailCar { get; set; }

        /// <summary>
        /// 柜号/封号'
        /// </summary>
        [MaxLength(50)]
        public virtual string FcabinetNo { get; set; }

        /// <summary>
        /// 20`'
        /// </summary>
        public virtual int F20th { get; set; }

        /// <summary>
        /// 40`'
        /// </summary>
        public virtual int F40th { get; set; }

        /// <summary>
        /// 40`hq'
        /// </summary>
        public virtual int F40thHq { get; set; }

        /// <summary>
        /// 装货 - 状态，从低到高分别为： 装货完成(0/1)
        /// </summary>
        public virtual int FholdState { get; set; }

    }
}
