using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    /// <summary>
    /// 仅进行操作权限检查
    /// </summary>
    public interface IAssessRight
    {
        /// <summary>
        /// 检查用户是否有权限进行XX操作
        /// </summary>
        /// <returns></returns>
        bool CanUserDo(string userAccount,string opID);



    }
}
