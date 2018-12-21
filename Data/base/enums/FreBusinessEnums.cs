using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    /// <summary>
    /// 整柜拼箱
    /// </summary>
    public enum FreBusinessFLTypeEnums : int
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

    /// <summary>
    /// 
    /// </summary>
    public enum FreBusinessSearchTimeTypeEnums : int
    {
        [EnumNames("不限日期")]
        不限日期 = 0,
        [EnumNames("业务日期")]
        业务日期,
        [EnumNames("制单日期")]
        制单日期,
        [EnumNames("提交商务日期")]
        提交商务日期,
        [EnumNames("预到船期")]
        预到船期,
        [EnumNames("中转开船期2")]
        中转开船期2,
        [EnumNames("预开船期")]
        预开船期,
        [EnumNames("预计送货期")]
        预计送货期,
        [EnumNames("装货日期")]
        装货日期,
        [EnumNames("预报船期")]
        预报船期,
        [EnumNames("预计到达")]
        预计到达,
        [EnumNames("中转开船期")]
        中转开船期,
        [EnumNames("中转船到期")]
        中转船到期,
        [EnumNames("扣放货日期")]
        扣放货日期,
        [EnumNames("代收款回收日期")]
        代收款回收日期,
        [EnumNames("代收款回交公司日期")]
        代收款回交公司日期,
        [EnumNames("干线上船日期")]
        干线上船日期,
        [EnumNames("报柜号/配船日期")]
        报柜号_配船日期,
        [EnumNames("核柜时间")]
        核柜时间,
        [EnumNames("送货派车日期")]
        送货派车日期,
        [EnumNames("送货完成日期")]
        送货完成日期,
        [EnumNames("送货回单日期")]
        送货回单日期,
        [EnumNames("送货办单日期")]
        送货办单日期,
        [EnumNames("装货回单日期")]
        装货回单日期,
        [EnumNames("装货派车日期")]
        装货派车日期,
        [EnumNames("装货完成日期")]
        装货完成日期,
        [EnumNames("装货办单日期")]
        装货办单日期,
        [EnumNames("最终船到日期")]
        最终船到日期,
        [EnumNames("运单回传日期")]
        运单回传日期,
        [EnumNames("费用录入日期")]
        费用录入日期,
        [EnumNames("对账日期")]
        对账日期,
        [EnumNames("登帐日期")]
        登帐日期,
        [EnumNames("费用审核日期")]
        费用审核日期,
        [EnumNames("回场日期")]
        回场日期,
        [EnumNames("备注日期1")]
        备注日期1,
        [EnumNames("备注日期2")]
        备注日期2,
        [EnumNames("备注日期3")]
        备注日期3,
        [EnumNames("备注日期4")]
        备注日期4,
        [EnumNames("备注日期5")]
        备注日期5,
        [EnumNames("备注日期6")]
        备注日期6,
        [EnumNames("备注日期7")]
        备注日期7,
        [EnumNames("备注日期8")]
        备注日期8,
        [EnumNames("备注日期9")]
        备注日期9,
        [EnumNames("备注日期10")]
        备注日期10,
        [EnumNames("备注日期11")]
        备注日期11,
        [EnumNames("备注日期12")]
        备注日期12,
        [EnumNames("备注日期13")]
        备注日期13,
        [EnumNames("备注日期14")]
        备注日期14,
        [EnumNames("备注日期15")]
        备注日期15,
        [EnumNames("承保日期")]
        承保日期,
        [EnumNames("备注日期16")]
        备注日期16,
        [EnumNames("备注日期17")]
        备注日期17,
        [EnumNames("备注日期18")]
        备注日期18,
        [EnumNames("备注日期19")]
        备注日期19,
        [EnumNames("备注日期20")]
        备注日期20,
        [EnumNames("预收/付日期")]
        预收_付日期,
        [EnumNames("货柜装货日期")]
        货柜装货日期,
        [EnumNames("头程上船期")]
        头程上船期,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum FreBusinessSearchDtoObjectTypeEnums : int
    {
        [EnumNames("不限条件")]
        不限条件 = 0,
        [EnumNames("托运人")]
        托运人,
        [EnumNames("运单号")]
        运单号,
        [EnumNames("柜号")]
        柜号,
        [EnumNames("工作单号")]
        工作单号,
        [EnumNames("卸货地点")]
        卸货地点,
        [EnumNames("卸货联系人")]
        卸货联系人,
        [EnumNames("装货联系人")]
        装货联系人,
        [EnumNames("业务员")]
        业务员,
        [EnumNames("装货地点")]
        装货地点,
        [EnumNames("录入员")]
        录入员,
        [EnumNames("起运地")]
        起运地,
        [EnumNames("起运码头")]
        起运码头,
        [EnumNames("目的地")]
        目的地,
        [EnumNames("目的码头")]
        目的码头,
        [EnumNames("付款方式")]
        付款方式,
        [EnumNames("货名")]
        货名,
        [EnumNames("操作条款")]
        操作条款,
        [EnumNames("运输条款")]
        运输条款,
        [EnumNames("协助人")]
        协助人,
        [EnumNames("收货单位")]
        收货单位,
        [EnumNames("发货单位")]
        发货单位,
        [EnumNames("装货电话")]
        装货电话,
        [EnumNames("装货手机")]
        装货手机,
        [EnumNames("卸货电话")]
        卸货电话,
        [EnumNames("卸货手机")]
        卸货手机,
        [EnumNames("提交商务人")]
        提交商务人,
        [EnumNames("船公司")]
        船公司,
        [EnumNames("支线船名")]
        支线船名,
        [EnumNames("支线航次")]
        支线航次,
        [EnumNames("三程船名")]
        三程船名,
        [EnumNames("三程航次")]
        三程航次,
        [EnumNames("起始拖车公司")]
        起始拖车公司,
        [EnumNames("目的拖车公司")]
        目的拖车公司,
        [EnumNames("委托单号")]
        委托单号,
        [EnumNames("订舱代理")]
        订舱代理,
        [EnumNames("货主")]
        货主,
        [EnumNames("保险单号")]
        保险单号,
        [EnumNames("保险公司")]
        保险公司,
        [EnumNames("发票号")]
        发票号,
        [EnumNames("对账单号")]
        对账单号,
        [EnumNames("提货单号")]
        提货单号,
        [EnumNames("卸货说明")]
        卸货说明,
        [EnumNames("装货说明")]
        装货说明,
        [EnumNames("操作员")]
        操作员,
        [EnumNames("备注1")]
        备注1,
        [EnumNames("备注2")]
        备注2,
        [EnumNames("备注3")]
        备注3,
        [EnumNames("备注4")]
        备注4,
        [EnumNames("备注5")]
        备注5,
        [EnumNames("备注6")]
        备注6,
        [EnumNames("备注7")]
        备注7,
        [EnumNames("备注8")]
        备注8,
        [EnumNames("备注9")]
        备注9,
        [EnumNames("备注10")]
        备注10,
        [EnumNames("备注11")]
        备注11,
        [EnumNames("备注12")]
        备注12,
        [EnumNames("备注13")]
        备注13,
        [EnumNames("备注14")]
        备注14,
        [EnumNames("备注15")]
        备注15,
        [EnumNames("财务事项")]
        财务事项,
        [EnumNames("特殊事项")]
        特殊事项,
        [EnumNames("已录费用项目")]
        已录费用项目,
        [EnumNames("核算对象")]
        核算对象,
        [EnumNames("初始核算对象")]
        初始核算对象,
        [EnumNames("封号")]
        封号,
        [EnumNames("货柜备注")]
        货柜备注,
        [EnumNames("订舱单号")]
        订舱单号,
        [EnumNames("加密封号")]
        加密封号,
        [EnumNames("加工厂")]
        加工厂,
        [EnumNames("合同号")]
        合同号,
        [EnumNames("起始司机")]
        起始司机,
        [EnumNames("目的司机")]
        目的司机,
        [EnumNames("收款单号")]
        收款单号,
        [EnumNames("船名")]
        船名,
        [EnumNames("航次")]
        航次,
        [EnumNames("备注16")]
        备注16,
        [EnumNames("备注17")]
        备注17,
        [EnumNames("备注18")]
        备注18,
        [EnumNames("备注19")]
        备注19,
        [EnumNames("备注20")]
        备注20,
        [EnumNames(" 登账单号")]
        登账单号,
        [EnumNames("柜型")]
        柜型,
        [EnumNames("未录费用项目")]
        未录费用项目,
        [EnumNames("应收费用项目")]
        应收费用项目,
        [EnumNames("应付费用项目")]
        应付费用项目,
        [EnumNames("应收未录费用项目")]
        应收未录费用项目,
        [EnumNames("应付未录费用项目")]
        应付未录费用项目,
        [EnumNames("航线")]
        航线,
        [EnumNames("保险申请号")]
        保险申请号,
        [EnumNames("协议号")]
        协议号,
        [EnumNames("业务类型")]
        业务类型,
        [EnumNames("部门")]
        部门,
        [EnumNames("业务子类型")]
        业务子类型,
        [EnumNames("干线车拖车公司")]
        干线车拖车公司,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum FreBusinessSearchDtoStatusTypeEnums : int
    {
        [EnumNames("不限状态")]
        不限状态 = 0,
        [EnumNames("未提交商务")]
        未提交商务,
        [EnumNames("已提交商务")]
        已提交商务,
        [EnumNames("已业务单审核")]
        已业务单审核,
        [EnumNames("未业务单审核")]
        未业务单审核,
        [EnumNames("商务退单")]
        商务退单,
        [EnumNames("未取消")]
        未取消,
        [EnumNames("已取消")]
        已取消,
        [EnumNames("可用")]
        可用,
        [EnumNames("不可用")]
        不可用,
        [EnumNames("运单已回传")]
        运单已回传,
        [EnumNames("运单未回传")]
        运单未回传,
        [EnumNames("已最终船到")]
        已最终船到,
        [EnumNames("未最终船到")]
        未最终船到,
        [EnumNames("已装货办单")]
        已装货办单,
        [EnumNames("未装货办单")]
        未装货办单,
        [EnumNames("已装货完成")]
        已装货完成,
        [EnumNames("未装货完成")]
        未装货完成,
        [EnumNames("已装货派车")]
        已装货派车,
        [EnumNames("未装货派车")]
        未装货派车,
        [EnumNames("未装货回单")]
        未装货回单,
        [EnumNames("已装货回单")]
        已装货回单,
        [EnumNames("已送货办单")]
        已送货办单,
        [EnumNames("未送货办单")]
        未送货办单,
        [EnumNames("已送货回单")]
        已送货回单,
        [EnumNames("未送货回单")]
        未送货回单,
        [EnumNames("已送货完成")]
        已送货完成,
        [EnumNames("未送货完成")]
        未送货完成,
        [EnumNames("已送货派车")]
        已送货派车,
        [EnumNames("未送货派车")]
        未送货派车,
        [EnumNames("已核对货柜")]
        已核对货柜,
        [EnumNames("未核对货柜")]
        未核对货柜,
        [EnumNames("已报柜号/配船")]
        已报柜号_配船,
        [EnumNames("未报柜号/配船")]
        未报柜号_配船,
        [EnumNames("套箱")]
        套箱,
        [EnumNames("非套箱")]
        非套箱,
        [EnumNames("有代收款")]
        有代收款,
        [EnumNames("无代收款")]
        无代收款,
        [EnumNames("已回收代收款")]
        已回收代收款,
        [EnumNames("未回收代收款")]
        未回收代收款,
        [EnumNames("已超重")]
        已超重,
        [EnumNames("未超重")]
        未超重,
        [EnumNames("已出险")]
        已出险,
        [EnumNames("未出险")]
        未出险,
        [EnumNames("已保险")]
        已保险,
        [EnumNames("未保险")]
        未保险,
        [EnumNames("已承保")]
        已承保,
        [EnumNames("未承保")]
        未承保,
        [EnumNames("已核销")]
        已核销,
        [EnumNames("未核销")]
        未核销,
        [EnumNames("部分核销")]
        部分核销,
        [EnumNames("已登帐")]
        已登帐,
        [EnumNames("未登帐")]
        未登帐,
        [EnumNames("已费用审核")]
        已费用审核,
        [EnumNames("未费用审核")]
        未费用审核,
        [EnumNames("未订舱")]
        未订舱,
        [EnumNames("已订舱")]
        已订舱,
        [EnumNames("已干线上船")]
        已干线上船,
        [EnumNames("未干线上船")]
        未干线上船,
        [EnumNames("已回交")]
        已回交,
        [EnumNames("未回交")]
        未回交,
        [EnumNames("扣货")]
        扣货,
        [EnumNames("放货")]
        放货,
        [EnumNames("急货")]
        急货,
        [EnumNames("危险品")]
        危险品,
        [EnumNames("已转船")]
        已转船,
        [EnumNames("未转船")]
        未转船,
        [EnumNames("拼箱")]
        拼箱,
        [EnumNames("整柜")]
        整柜,
        [EnumNames("无协助人")]
        无协助人,
        [EnumNames("有协助人")]
        有协助人,
        [EnumNames("承保日期为空")]
        承保日期为空,
        [EnumNames("已取消承保")]
        已取消承保,
    }


    /// <summary>
    /// 
    /// </summary>
    public enum FreBusinessTenderTypeEnums : int
    {
        [EnumNames("不限批量招标")]
        不限批量招标 = 0,
        [EnumNames("装货")]
        装货,
        [EnumNames("送货")]
        送货,
    }


    /// <summary>
    /// 企业类型
    /// </summary>
    public enum FreBusinessCompanyType : int
    {
        [EnumNames("托运人")]
        托运人 = 0,
        [EnumNames("拖车公司")]
        拖车公司,
        [EnumNames("货代")]
        货代,
        [EnumNames("保险")]
        保险,
        [EnumNames("船公司")]
        船公司,
        [EnumNames("船东")]
        船东,
        [EnumNames("发货人")]
        发货人,
        [EnumNames("收货人")]
        收货人,
        [EnumNames("通知人")]
        通知人,
        [EnumNames("仓库")]
        仓库,
        [EnumNames("港口代理")]
        港口代理,
        [EnumNames("海关")]
        海关,
        [EnumNames("客户")]
        客户,
        [EnumNames("堆场")]
        堆场,
        [EnumNames("快递")]
        快递,
        [EnumNames("码头")]
        码头,
        [EnumNames("船代")]
        船代,
        [EnumNames("贸易公司")]
        贸易公司,
        [EnumNames("司机")]
        司机,
        [EnumNames("目的车队")]
        目的车队,
        [EnumNames("其他")]
        其他,
    }

    /// <summary>
    /// 单位枚举
    /// </summary>
    public enum FreBusinessUnitType : int
    {
        [EnumNames("20GP")]
	    E_20GP = 0,
        [EnumNames("40GP")]
        E_40GP,
        [EnumNames("20HQ")]
        E_20HQ,
        [EnumNames("40HQ")]
        E_40HQ,
        [EnumNames("40RF")]
        E_40RF,
        [EnumNames("45GP")]
        E_45GP,
        [EnumNames("CMB")]
        E_CMB,
        [EnumNames("KGS")]
        E_KGS,
        [EnumNames("20TK")]
        E_20TK,
        [EnumNames("升")]
        升,
        [EnumNames("票")]
        票,
        [EnumNames("40HC")]
        E_40HC,
        [EnumNames("吨")]
        吨,
        [EnumNames("20OT")]
        E_20OT,
        [EnumNames("40OT")]
        E_40OT,
        [EnumNames("40RH")]
        E_40RH,
        [EnumNames("托")]
        托,
        [EnumNames("20RF")]
        E_20RF,
        [EnumNames("袋")]
        袋,
        [EnumNames("45HC")]
        E_45HC,
        [EnumNames("20FR")]
        E_20FR,
        [EnumNames("40FR")]
        E_40FR,
        [EnumNames("20HC")]
        E_20HC,
    }


    public enum FreBusinessDateYdcEnums : int
    {
        [EnumNames("请选择...")]
        请选择 = 0,
        [EnumNames("订舱日期")]
        订舱日期,
        [EnumNames("预开日期")]
        预开日期,
        [EnumNames("预到日期")]
        预到日期,
    }


    public enum FreBusinessSpfEnums : int
    {
        [EnumNames("订舱人")]
        订舱人 = 0,
        [EnumNames("发货人")]
        发货人,
        [EnumNames("收货人")]
        收货人,
    }


    public enum InsurancePayWayEnums : int
    {
        [EnumNames("含运费")]
        含运费 = 0,
        [EnumNames("无保险")]
        无保险,
        [EnumNames("现金支付（车队提箱时支付）")]
        现金支付_车队提箱时支付_,
    }


    public enum CoolingRequirementEnums : int
    {
        [EnumNames("无")]
        无 = 0,
        [EnumNames("预冷")]
        预冷,
    }
}
