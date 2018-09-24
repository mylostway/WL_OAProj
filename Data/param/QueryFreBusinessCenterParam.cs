using System;
using System.Collections.Generic;
using System.Text;

namespace Data.param
{
    public class QueryFreBusinessCenterParam : BaseQueryParam
    {
        public DateTypeEnums? DateType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ListIDTypeEnums ListIDType { get; set; }

        public string ListID { get; set; }

        public StateEnums State1 { get; set; }

        public StateEnums State2 { get; set; }
    }
}
