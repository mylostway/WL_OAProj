using System;
using System.Collections.Generic;
using System.Text;

using Chloe;
using Chloe.Annotations;

namespace Data.entity
{
    [Table("t_ship_book_manager")]
    public class ShipBookManagerEntity : BaseEntity<int>
    {
        /// <summary>
        /// 船公司'
        /// </summary>
        public string FshipCompany { get; set; }

        /// <summary>
        /// 船名'
        /// </summary>
        public string FshipName { get; set; }

        /// <summary>
        /// 航次'
        /// </summary>
        public string FshipTNo { get; set; }

        /// <summary>
        /// 起运港'
        /// </summary>
        public string FshipStartWharf { get; set; }

        /// <summary>
        /// 目的港'
        /// </summary>
        public string FshipToWharf { get; set; }

        /// <summary>
        /// 运单号'
        /// </summary>
        public string FshipTransNo { get; set; }

        /// <summary>
        /// 订舱日期'
        /// </summary>
        public DateTime FshipBookDate { get; set; }

        /// <summary>
        /// 预开船期'
        /// </summary>
        public DateTime FshipScheduleDate { get; set; }

        /// <summary>
        /// 柜型'
        /// </summary>
        public string FshipCabinetType { get; set; }

        /// <summary>
        /// 柜量'
        /// </summary>
        public int FshipCabinetAmt { get; set; }

        /// <summary>
        /// 取消数量'
        /// </summary>
        public int FshipCancelAmt { get; set; }

        /// <summary>
        /// 已用数量'
        /// </summary>
        public int FshipUsedAmt { get; set; }

        /// <summary>
        /// 启用'
        /// </summary>
        public int FshipIsUsed { get; set; }

        /// <summary>
        /// 订舱委托单号'
        /// </summary>
        public string FshipDelegateTransNo { get; set; }

        /// <summary>
        /// 收货单位'
        /// </summary>
        public string FshipTakeUnit { get; set; }

        /// <summary>
        /// 订舱代理'
        /// </summary>
        public string FshipBookProxy { get; set; }

        /// <summary>
        /// 单柜成本'
        /// </summary>
        public string FshipPerCost { get; set; }

        /// <summary>
        /// 业务员'
        /// </summary>
        public string Fbusinesser { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Fmemo { get; set; }

    }
}
