using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace Data.entity
{
    /// <summary>
    /// 航线信息
    /// </summary>
    [Table("t_fre_business_center")]
    public class FreBusinessOpCenterEntity : BaseEntity<int>
    {
        /// <summary>
        /// 物流动态 - 未知填什么值'
        /// </summary>
        public string FinterflowState { get; set; }

        /// <summary>
        /// 托运人'
        /// </summary>
        public string FconsignMan { get; set; }

        /// <summary>
        /// 起运码头'
        /// </summary>
        public string FstartWharf { get; set; }

        /// <summary>
        /// 起运地'
        /// </summary>
        public string FstartPlace { get; set; }

        /// <summary>
        /// 目的地'
        /// </summary>
        public string FtoPlace { get; set; }

        /// <summary>
        /// 目的码头'
        /// </summary>
        public string FtoWharf { get; set; }

        /// <summary>
        /// 业务日期'
        /// </summary>
        public DateTime FbusinessDate { get; set; }

        /// <summary>
        /// 业务员'
        /// </summary>
        public string Fbusinesser { get; set; }

        /// <summary>
        /// 货名'
        /// </summary>
        public string FgoodsName { get; set; }

        /// <summary>
        /// 装货低点'
        /// </summary>
        public string FholdGoodsPlace { get; set; }

        /// <summary>
        /// 装货联系人'
        /// </summary>
        public string FholdGoodsPeoplePhone { get; set; }

        /// <summary>
        /// 卸货低点'
        /// </summary>
        public string FputGoodsPlace { get; set; }

        /// <summary>
        /// 卸货联系人'
        /// </summary>
        public string FputGoodsPeoplePhone { get; set; }

        /// <summary>
        /// 操作条款'
        /// </summary>
        public string FopTerm { get; set; }

        /// <summary>
        /// 运输条款'
        /// </summary>
        public string FtransitTerm { get; set; }

        /// <summary>
        /// 付款方式'
        /// </summary>
        public string FpayWay { get; set; }

        /// <summary>
        /// 工单号'
        /// </summary>
        public string FworkOrderNo { get; set; }

        /// <summary>
        /// 记录单状态 - 按位记录 从低到高分别为：最终船到(0/1),送货派车,装货派车,干线上船,报柜号/配船,运单回传,送货完成(0/1)
        /// </summary>
        public int FrecordState { get; set; }

        /// <summary>
        /// 船公司'
        /// </summary>
        public string FshipCompany { get; set; }

        /// <summary>
        /// 干线船名'
        /// </summary>
        public string FshipMainShipName { get; set; }

        /// <summary>
        /// 干线航次'
        /// </summary>
        public string FshipMainLineNo { get; set; }

        /// <summary>
        /// 运单号'
        /// </summary>
        public string FshipTransNo { get; set; }

        /// <summary>
        /// 起始拖车',
        /// </summary>
        public string FstartTrailCar { get; set; }

        /// <summary>
        /// 装货日期'
        /// </summary>
        public DateTime FholdGoodsDate { get; set; }

        /// <summary>
        /// 目的拖车'
        /// </summary>
        public string FtoTrailCar { get; set; }

        /// <summary>
        /// 柜号/封号'
        /// </summary>
        public string FcabinetNo { get; set; }

        /// <summary>
        /// 20`'
        /// </summary>
        public int F20th { get; set; }

        /// <summary>
        /// 40`'
        /// </summary>
        public int F40th { get; set; }

        /// <summary>
        /// 40`hq'
        /// </summary>
        public int F40thHq { get; set; }

        /// <summary>
        /// 装货 - 状态，从低到高分别为： 装货完成(0/1)
        /// </summary>
        public int FholdState { get; set; }

    }
}
