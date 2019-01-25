using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.dto
{
    /// <summary>
    /// 网络请求统计信息数据
    /// </summary>
    public class WebReqResStatisticsDTO
    {
        public WebReqResStatisticsDTO()
        {
            InTime = DateTime.Now;
        }

        public DateTime InTime { get; set; }

        public DateTime OutTime { get; set; }

        public long Cost { get; set; }

        public string Method { get; set; }

        public string ContentType { get; set; }

        public long? ContentLength { get; set; }

        public string RequestHeader { get; set; }

        public string RequestFullUrl { get; set; }

        public string Cookie { get; set; }

        public string RequestBody { get; set; }

        public string ResponseBody { get; set; }

        public Exception Exception { get; set; }
    }
}
