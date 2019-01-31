using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    public sealed class DefaultAssessRight : IAssessRight
    {
        private DefaultAssessRight() { }

        public static DefaultAssessRight Instance = new DefaultAssessRight();

        public bool CanUserDo(string userAccount, string opID)
        {
            return true;
        }
    }
}
