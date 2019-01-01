using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    /// <summary>
    /// 错误码域
    /// </summary>
    public enum ExceptionScope
    {
        [EnumNames("系统错误")]
        System = 1,
        [EnumNames("DB错误")]
        DB,
        [EnumNames("逻辑错误")]
        Logic,
        [EnumNames("参数错误")]
        Parameter,

    }

    public class UserFriendlyException : Exception
    {
        public UserFriendlyException() { }

        public UserFriendlyException(string msg, ExceptionScope exceptionScope = ExceptionScope.System, Exception innerException = null, int exceptionCode = -1)
            : base(msg)
        {
            ExceptionScope = exceptionScope;
            ExceptionCode = exceptionCode;
            InnerException = innerException;
        }


        public int ExceptionCode { get; set; } 

        public ExceptionScope ExceptionScope { get; set; }

        public Exception InnerException { get; set; }
    }
}
