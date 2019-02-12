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
    public enum DefaultPageSizeEnums : int
    {
        [EnumNames("10", IsSelected = true)]
        PS10 = 10,
        [EnumNames("20")]
        PS20 = 20,
        [EnumNames("30")]
        PS30 = 30,
        [EnumNames("50")]
        PS50 = 50
    }



    /// <summary>
    /// 页面分页数据大小
    /// </summary>
    public enum LargePageSizeEnums : int
    {
        [EnumNames("10", IsSelected = true)]
        PS10 = 10,
        [EnumNames("20")]
        PS20 = 20,
        [EnumNames("30")]
        PS30 = 30,
        [EnumNames("50")]
        PS50 = 50,
        [EnumNames("100")]
        PS100 = 100,
        [EnumNames("150")]
        PS150 = 150,
        [EnumNames("200")]
        PS200 = 200,
        [EnumNames("500")]
        PS500 = 500,
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
