using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class EnumNamesAttribute : Attribute
    {
        public EnumNamesAttribute(string name = "")
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public enum DateTypeEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("业务日期")]
        BusinessDate,
        [EnumNames("制单日期")]
        MakeListDate,
        [EnumNames("提交商务日期")]
        CommitBusinessDate,
        [EnumNames("预到船期")]
        BookedShipReachDate,
        [EnumNames("中转开船期")]
        TransferShipDate,
        [EnumNames("预开船期")]
        BookedShipStartDate,
        [EnumNames("预计送货期")]
        WantedSendGoodsDate,
        [EnumNames("装货日期")]
        HoldGoodsDate,
        [EnumNames("预计到达期")]
        WantedReachDate,
    }


    /// <summary>
    /// 单号类型枚举
    /// </summary>
    public enum ListIDTypeEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("运单号")]
        ShipNo,
        [EnumNames("柜号")]
        CabinetNo,
        [EnumNames("工作单号")]
        WorkNo,
    }


    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum StateEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("可用")]
        Usable,

        [EnumNames("未提交商务")]
        NotCommitBusiness,
        [EnumNames("已提交商务")]
        CommitedBusiness,
        [EnumNames("已业务单审核")]
        BusinessAudited,
        [EnumNames("未业务单审核")]
        BusinessNotAudit,
    }
}
