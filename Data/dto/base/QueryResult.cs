using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.dto
{
    public class QueryResult<T> : BaseQueryResult
        where T : class
    {
        public QueryResult()
            : this(null, 0, 0)
        { }

        public QueryResult(T result, int maxRow = 0, int curRow = 1)
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



    public static class QueryResultEx
    {
        public static bool IsSucceed<T>(this QueryResult<T> result)
            where T : class
        {
            return (null != result 
                && result.ResultCode == QueryResultCode.Succeed 
                && result.ResultCount > 0);
        }
    }
}
