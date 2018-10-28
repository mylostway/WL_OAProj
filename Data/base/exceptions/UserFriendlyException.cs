using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException() { }

        public UserFriendlyException(string msg) : base(msg) { }


    }
}
