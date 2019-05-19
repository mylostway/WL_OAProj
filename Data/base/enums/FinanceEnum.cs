using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    /// <summary>
    /// 核销状态枚举
    /// </summary>
    public enum CVStateEnum
    {
        [EnumNames("已核销")]
        Done = 1,
        [EnumNames("部分核销")]
        Partly,
        [EnumNames("未核销")]
        None,
    }

    /// <summary>
    /// 凭证类别枚举
    /// </summary>
    public enum ProofTypeEnum
    {
        [EnumNames("收")]
        Recv = 1,
        [EnumNames("付")]
        Pay,
    }



    /// <summary>
    /// 凭证字枚举
    /// </summary>
    public enum ProofWordEnum
    {
        [EnumNames("现金")]
        Money = 1,
        [EnumNames("银行")]
        Bank,
        [EnumNames("代收付")]
        RecvOrPay,
        [EnumNames("支票")]
        Check,
        [EnumNames("汇票")]
        Draft,
    }



    /// <summary>
    /// 凭证查询ID类型枚举
    /// </summary>
    public enum ProofIDSearchTypeEnum
    {
        [EnumNames("凭证号")]
        ProofID = 1,
        [EnumNames("操作员")]
        Operator,
        [EnumNames("摘要")]
        Memo,
        [EnumNames("金额")]
        Amount,
        [EnumNames("参考号")]
        Refer,
        [EnumNames("核算对象")]
        CheckTarget,
        [EnumNames("账号")]
        BankAccount,
        [EnumNames("银行")]
        Bank,
        [EnumNames("开户名称")]
        Account,
    }



    /// <summary>
    /// 凭证类别枚举
    /// </summary>
    public enum FeeCVSearchFeeTypeEnum
    {
        [EnumNames("应收")]
        Recv = 1,
        [EnumNames("应付")]
        Pay,
    }



    /// <summary>
    /// 凭证类别枚举
    /// </summary>
    public enum FeeCVSearchStateEnum
    {
        [EnumNames("未核销")]
        NotCV = 1,
        [EnumNames("已对账")]
        Checked,
        [EnumNames("有关")]
        Related,
        [EnumNames("无关")]
        NotRelated,
    }

}
