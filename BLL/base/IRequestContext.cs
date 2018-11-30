using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data;

namespace WL_OA.BLL
{
    public interface IRequestContext
    {
        SysRequestContext GetRequestContext();

        void SetRequestContext(SysRequestContext context);
    }
}
