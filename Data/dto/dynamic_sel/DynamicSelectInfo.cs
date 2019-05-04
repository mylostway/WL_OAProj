using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.dto
{
    public class DynamicSelectInfo
    {
        public IList<DSStruct> cols { get; set; }

        public object tableData { get; set; }
    }


    public class DSStruct
    {
        public string label { get; set; }

        public string prop { get; set; }

        public string type { get; set; } = "normal";

        public bool isKeyCol { get; set; } = false;
    }
}
