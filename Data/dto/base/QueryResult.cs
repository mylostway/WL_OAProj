using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.dto
{
    public class QueryResult<T> : BaseQueryResult
        where T : class
    {
        public QueryResult(T result = null, int maxRow = 0, int curRow = 0)
            : base(maxRow, curRow)
        {
            ResultData = result;
        }


        public QueryResult(QueryResultCode resultCode, string msg = "")
            : base(0, 0, resultCode, msg)
        {

        }

        public T ResultData { get; set; }
    }
}
