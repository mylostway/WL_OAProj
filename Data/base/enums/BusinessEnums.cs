using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WL_OA.Data
{
    public enum CustomManagerSearchDateTypeEnums
    {
        [EnumNames("不限日期", IsSelected = true)]
        None = 0,
        [EnumNames("录入日期")]
        InputDate,
        [EnumNames("审核日期")]
        AduitDate
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
        [EnumNames("录入时间")]
        InputTime,
        [EnumNames("审核时间")]
        AduitTime,
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



    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum PaywayEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("月结")]
        MonthlyBalance = 1,
        [EnumNames("票结")]
        TicketKnot = 2,
        [EnumNames("代收款")]
        TradeCharges = 3,
        [EnumNames("代垫")]
        Advance = 4,
    }



    /// <summary>
    /// 客户ID类型枚举
    /// </summary>
    public enum QueryCustomerInfoIDTypeEnums : int
    {
        [EnumNames("不限条件")]
        None = 0,
        [EnumNames("助记码")]
        Remark,
        [EnumNames("公司简称")]
        Forshot,
        [EnumNames("公司全称")]
        FullName,
        [EnumNames("企业物流号")]
        CompanyLogisticsID,
        [EnumNames("业务员")]
        BusinessMan,
        [EnumNames("付款方式")]
        Payway,
        [EnumNames("客户类型")]
        CustomType,
        [EnumNames("省份")]
        Province,
        [EnumNames("城市")]
        City,
        [EnumNames("区域")]
        Area,
        [EnumNames("部门")]
        Department,
        [EnumNames("公司地址")]
        CompanyAddr,
        [EnumNames("业务联系人")]
        BusinessConcatPeople,
        [EnumNames("业务电话")]
        BusinessPhone,
        [EnumNames("业务手机")]
        BusinessMobile,
        [EnumNames("目的港电话")]
        DstWhartfPhone,
        [EnumNames("备注")]
        Memo,
    }


    /// <summary>
    /// 客户类型枚举
    /// </summary>
    public enum CustomerInfoTypeEnums : int
    {
        [EnumNames("请选择")]
        None = 0,
        [EnumNames("船东")]
        ShipOwner,
        [EnumNames("托运人")]
        Consignor,
        [EnumNames("发货人")]
        Sender,
        [EnumNames("收货人")]
        Receiver,
        [EnumNames("通知人")]
        Notifier,
        [EnumNames("仓库")]
        Cabinet,
        [EnumNames("港口代理")]
        WharfProxy,
        [EnumNames("拖车公司")]
        TrailCompany,
        [EnumNames("海关")]
        CIQ,
        [EnumNames("其他")]
        Other,
        [EnumNames("货代")]
        Freight,
        [EnumNames("客户")]
        Customer,
        [EnumNames("保险")]
        Insure,
        [EnumNames("堆场")]
        YARD,
        [EnumNames("快递")]
        Express,
        [EnumNames("码头")]
        Wharf,
        [EnumNames("船代")]
        CCST,
        [EnumNames("贸易公司")]
        TradeCompany,
        [EnumNames("司机")]
        Driver,
        [EnumNames("船公司")]
        ShipCompany,
        [EnumNames("目的车队")]
        DstFleet,
    }


    /// <summary>
    /// 查询的客户类型枚举
    /// </summary>
    public enum QueryCustomerInfoTypeEnums : int
    {
        [EnumNames("不限")]
        None = 0,
        [EnumNames("船东")]
        ShipOwner,
        [EnumNames("托运人")]
        Consignor,
        [EnumNames("发货人")]
        Sender,
        [EnumNames("收货人")]
        Receiver,
        [EnumNames("通知人")]
        Notifier,
        [EnumNames("仓库")]
        Cabinet,
        [EnumNames("港口代理")]
        WharfProxy,
        [EnumNames("拖车公司")]
        TrailCompany,
        [EnumNames("海关")]
        CIQ,
        [EnumNames("其他")]
        Other,
        [EnumNames("货代")]
        Freight,
        [EnumNames("客户")]
        Customer,
        [EnumNames("保险")]
        Insure,
        [EnumNames("堆场")]
        YARD,
        [EnumNames("快递")]
        Express,
        [EnumNames("码头")]
        Wharf,
        [EnumNames("船代")]
        CCST,
        [EnumNames("贸易公司")]
        TradeCompany,
        [EnumNames("司机")]
        Driver,
        [EnumNames("船公司")]
        ShipCompany,
        [EnumNames("目的车队")]
        DstFleet,
        [EnumNames("白名单车队")]
        Whitelist,
    }


    /// <summary>
    /// 客户状态枚举，按位取值，0 - 可用，1 - 已审核，2 - 共享，3 - 完成，4 - 黑名单，5 - 收短信
    /// </summary>
    public enum CustomerInfoStateEnums:int
    {
        [EnumNames("可用")]
        可用 = 0,
        [EnumNames("已审核")]
        已审核,
        [EnumNames("共享")]
        共享,
        [EnumNames("完成")]
        完成,
        [EnumNames("黑名单")]
        黑名单,
        [EnumNames("收短信")]
        收短信,
    }



    /// <summary>
    /// 查询客户状态枚举
    /// </summary>
    public enum QueryCustomerInfoStateEnums : int
    {
        [EnumNames("不限")]
        None = -1,
        [EnumNames("不可用")]
        Useless,
        [EnumNames("可用")]
        Usable,
        [EnumNames("未审核")]
        UnAduited,
        [EnumNames("已审核")]
        Aduited,
        [EnumNames("共享")]
        Shared,
        [EnumNames("不共享")]
        UnShared,
        [EnumNames("黑名单")]
        BlackList,
        [EnumNames("非黑名单")]
        NotBlackList,
        [EnumNames("收短信")]
        ReceivedShortmsg,
        [EnumNames("不收短信")]
        NotReceivedShortmsg,
    }
}
