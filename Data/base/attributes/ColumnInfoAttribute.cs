using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    /// <summary>
    /// 列附加信息特性（目前客户端有用）
    /// </summary>
    public class ColumnInfoAttribute : Attribute
    {
        public ColumnInfoAttribute(string name, bool isPrimary = false)
        {
            Name = name;
            IsPrimary = isPrimary;
        }


        /// <summary>
        /// 列名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimary { get; set; }
    }
}
