using System;
using System.Collections.Generic;
using System.Text;

namespace Data.entity
{
    /// <summary>
    /// 用户自定义数据
    /// </summary>
    public class UserDefineDataEntity : AuditEntity
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Memo { get; set; }

        public int Type { get; set; }
    }
}
