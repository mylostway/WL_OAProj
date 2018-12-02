using System;
using System.Collections.Generic;
using System.Text;
using WL_OA;
using WL_OA.BLL;
using WL_OA.Data;

namespace ConsoleTest.test_cases
{
    public class TestUserManager
    {
        public void TestLogin()
        {
            var loginInfo = new LoginInfo()
            {
                Account = "admin",
                Password = "admin".ToMD5()
            };

            (new UserManagerBLL()).CheckLogin(loginInfo);
        }


        public void Run()
        {
            TestLogin();
        }
    }
}
