using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL_OA.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FakeDataNotGenAttribute : Attribute
    {

    }

    public class FakeDataHelerSettings
    {
        public const int DEFAULT_GEN_DATA_NUM = 37;        
    }
}
