using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum SexEnums : int
    {
        [EnumNames("未知",true)]
        None = 0,
        [EnumNames("男", true)]
        Male,
        [EnumNames("女", true)]
        Female
    }


    /// <summary>
    /// 页面分页数据大小
    /// </summary>
    public enum PageSizeEnums : int
    {
        [EnumNames("10")]
        PS10 = 0,
        [EnumNames("20")]
        PS20,
        [EnumNames("30")]
        PS30,
        [EnumNames("50")]
        PS50,
        [EnumNames("100")]
        PS100,
        [EnumNames("150")]
        PS150,
        [EnumNames("200")]
        PS200,
        [EnumNames("500")]
        PS500,
    }

    /// <summary>
    /// 是/否枚举
    /// </summary>
    public enum YesNoEnums : int
    {
        [EnumNames("否")]
        否 = 0,
        [EnumNames("是")]
        是,
    }

}
