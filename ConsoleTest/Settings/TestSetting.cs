using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data;

namespace ConsoleTest
{
    public class TestSetting
    {
        private TestSetting() { }

        /// <summary>
        /// 测试专用请求上下文
        /// </summary>
        public static readonly SysRequestContext TEST_SYS_REQ_CONTEXT = new SysRequestContext() {
            LoginInfo = new LoginInfo("test_account","test_password")
        };
    }
}
