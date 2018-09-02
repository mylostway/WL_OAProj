using System;
using System.Collections.Generic;
using System.Text;

namespace Data.dto
{
    public class QueryResult<T> : BaseQueryResult
        where T : class
    {
        public QueryResult(T result = null, int maxRow = 0, int curRow = 0)
            : base(maxRow, curRow)
        {
            ResultData = result;
        }

        public T ResultData { get; set; }
    }
}
