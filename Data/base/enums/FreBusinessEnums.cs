using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    /// <summary>
    /// 整柜拼箱
    /// </summary>
    public enum FreBusinessTypeEnums : int
    {
        [EnumNames("请选择")]
        None = 0,
        [EnumNames("整柜", true)]
        FC,
        [EnumNames("拼箱")]
        LCL,
    }

    /// <summary>
    /// 传输条款/操作条款
    /// </summary>
    public enum FreBusinessTransportTermsEnums : int
    {
        [EnumNames("站/站")]
        St_St = 1,
        [EnumNames("站/堆场")]
        St_Sg,
        [EnumNames("站/门")]
        St_Gate,
        [EnumNames("堆场/站")]
        Sg_St,
        [EnumNames("堆场/堆场", true)]
        Sg_Sg,
        [EnumNames("堆场/门")]
        Sg_Gate,
        [EnumNames("门/堆场")]
        Gate_Sg,
        [EnumNames("门/门")]
        Gate_Gate,
        [EnumNames("门/站")]
        Gate_St,
        [EnumNames("假门/假门")]
        FGate_Fgate,
        [EnumNames("假门/堆场")]
        Fgate_Sg,
        [EnumNames("堆场/假门")]
        Sg_Fgate,
        [EnumNames("假门/门")]
        Fgate_gate,
        [EnumNames("门/假门")]
        Gate_Fgate,
    }

    /// <summary>
    /// 付款方式
    /// </summary>
    public enum FreBusinessPaymentTypeEnums : int
    {
        [EnumNames("请选择", true)]
        None = 0,
        [EnumNames("月结")]
        MonthlyBalance,
        [EnumNames("票结")]
        TicketKnot,
        [EnumNames("代收款")]
        TradeCharges,
        [EnumNames("代垫")]
        Advance,
    }

    /// <summary>
    /// 出车预约
    /// </summary>
    public enum FreBusinessReserveCarEnums : int
    {
        [EnumNames("请选择",true)]
        None = 0,
        [EnumNames("已电话预约")]
        Phoned,
        [EnumNames("请电话预约")]
        Phoning,
        [EnumNames("等通知")]
        WaitingNotify,
    }

    /// <summary>
    /// 装货优先级
    /// </summary>
    public enum FreBusinessLoadingLevelEnums : int
    {
        [EnumNames("请选择", true)]
        None = 0,
        [EnumNames("普通处理")]
        CommonHandle,
        [EnumNames("工程货")]
        ProjectGoods,
        [EnumNames("急货")]
        Hurry,
        [EnumNames("超级快装")]
        Urgent,
    }

    /// <summary>
    /// 扣放货
    /// </summary>
    public enum FreBusinessDetainReleaseEnums : int
    {
        [EnumNames("请选择")]
        None = 0,
        [EnumNames("扣货",true)]
        Hold,
        [EnumNames("放货")]
        Release,
    }


    /// <summary>
    /// 配送优先级
    /// </summary>
    public enum FreBusinessDeliveryLevelEnums : int
    {
        [EnumNames("请选择",true)]
        None = 0,
        [EnumNames("普通安排")]
        Common,
        [EnumNames("加急配送")]
        Hurry,
        [EnumNames("优先配送")]
        Prior,
        [EnumNames("特殊处理")]
        Special,
    }


    /// <summary>
    /// 保险类型
    /// </summary>
    public enum FreBusinessInsurTypeEnums : int
    {
        [EnumNames("请选择")]
        None = 0,
        [EnumNames("综合险")]
        Colligate,
        [EnumNames("基本险")]
        Basic,
    }


    /// <summary>
    /// 业务类型
    /// </summary>
    public enum FreBusinessBusinessTypeEnums : int
    {
        [EnumNames("请选择")]
        None = 0,
        [EnumNames("拖车")]
        Trail,
        [EnumNames("货代",true)]
        Freight,
    }


    /// <summary>
    /// 驳船信息
    /// </summary>
    public enum FreBusinessBargeInformationEnums : int
    {
        [EnumNames("无", true)]
        None = 0,
        [EnumNames("始驳+干线")]
        Initial_Mainline,
        [EnumNames("干线+达驳")]
        Mainline_Refutation,
        [EnumNames("始驳+干线+达驳")]
        Initial_Mainline_Refutation,
        [EnumNames("智能跟踪识别")]
        Intelligence,
    }
}
