using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.enums
{
    /// <summary>
    /// 经营报表 查询ID类型
    /// </summary>
    public enum OperatingReportSearchIDTypeEnum : int
    {
        [EnumNames("业务员")]
        BusinessMan = 1,
        [EnumNames("操作员(跟单)")]
        OpUser,
    }



}
