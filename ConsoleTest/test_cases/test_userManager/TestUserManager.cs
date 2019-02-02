using ConsoleTest.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA;
using WL_OA.BLL;
using WL_OA.Data;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using Xunit;

namespace ConsoleTest.test_cases
{
    public class TestUserManager
    {
        public TestUserManager()
        {
            m_bll = new UserManagerBLL();

            // 请求上下文设置
            m_bll.SetRequestContext(TestSetting.TEST_SYS_REQ_CONTEXT);
            // 设置依赖
            m_bll.SetServicesProvider(DIHelper.Instance.GetServicesProvider());
        }

        private UserManagerBLL m_bll = null;

        const string TEST_ACCOUNT = "test_tmp_account";

        static readonly string TEST_PWD = "123456".ToMD5();

        static readonly string TEST_CHG_PWD = "2345678901".ToMD5();

        public BaseOpResult TestLogin(string passwd = "")
        {
            if (string.IsNullOrEmpty(passwd)) passwd = TEST_PWD;
            var loginInfo = new LoginInfo()
            {
                Account = TEST_ACCOUNT,
                Password = passwd
            };

            loginInfo.IsValid();

            return m_bll.CheckLogin(loginInfo);
        }

        [Fact]
        public void TestAddUser()
        {
            var testAddUser = new SystemUserEntity()
            {
                Fuser_account = TEST_ACCOUNT,
                Fname = "管已开",
                Fphone = "15002094251",
                Femail = "359050096@qq.com",
                Fcert = "440682198910155016",
                Fpassword = TEST_PWD
            };

            var opResult = m_bll.AddUser(testAddUser);
            Assert.True(opResult.IsSucceed());

            opResult = m_bll.AddUser(testAddUser);
            Assert.True(!opResult.IsSucceed() && opResult.RetMsg.Contains("已存在"));
        }



        [Fact]
        public void TestUpdateUser()
        {
            var testAddUser = new SystemUserEntity()
            {
                Fuser_account = TEST_ACCOUNT,
                Fname = "Alen",
                Fphone = "3333331500209425",
                Femail = "359050096@163.com",
                Fcert = "550682198910155016",
                Fpassword = TEST_CHG_PWD
            };

            var opResult = m_bll.UpdateUser(testAddUser);
            Assert.True(opResult.IsSucceed());
        }


        [Fact]
        public void TestDelUser()
        {
            var opResult = m_bll.DelUser(TEST_ACCOUNT);
            Assert.True(opResult.IsSucceed());
        }


        public void Run()
        {
            // 未建立用户时，登录失败
            var opResult = TestLogin();
            Assert.True(!opResult.IsSucceed());
            // 新增测试用户
            TestAddUser();
            opResult = TestLogin();
            // 登录成功
            Assert.True(opResult.IsSucceed());

            // 更新用户信息和用户密码
            TestUpdateUser();            
            opResult = TestLogin();
            // 登录失败
            Assert.True(!opResult.IsSucceed());

            // 新密码测试登录，登录成功
            opResult = TestLogin(TEST_CHG_PWD);            
            Assert.True(opResult.IsSucceed());

            // 删除用户
            TestDelUser();

            // 删除用户，登录失败
            opResult = TestLogin(TEST_CHG_PWD);
            Assert.True(!opResult.IsSucceed());
        }
    }
}
