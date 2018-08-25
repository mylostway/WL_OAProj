using System;
using System.Collections.Generic;
using System.Text;

namespace Data.entity
{
    /// <summary>
    /// 数据合法性自校验接口
    /// </summary>
    interface IDataValidator
    {
        /// <summary>
        /// 数据是否合法
        /// </summary>
        /// <returns></returns>
        bool IsValid();
    }
}
