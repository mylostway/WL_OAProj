using ConsoleTest.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.BLL;
using WL_OA.Data.entity.company;
using WL_OA.Data.param;
using Xunit;

namespace ConsoleTest.test_cases
{
    public class TestDepartments
    {
        public TestDepartments()
        {
            m_bll = new CompanyDepartmentBLL();

            // 请求上下文设置
            m_bll.SetRequestContext(TestSetting.TEST_SYS_REQ_CONTEXT);
            // 设置依赖
            m_bll.SetServicesProvider(DIHelper.Instance.GetServicesProvider());
        }

        private CompanyDepartmentBLL m_bll = null;

        const string TEST_DEPARTMENT_NAME = "A测试部门1A";

        const string TEST_DEPARTMENT_COMMENT = "第三方经理123@￥接口为了让";

        [Fact]
        public void TestAddDepartment()
        {
            var testAddInfo = new CompanyDepartmentEntity()
            {
                Fname = TEST_DEPARTMENT_NAME,
                Fcomment = TEST_DEPARTMENT_COMMENT
            };

            var opResult = m_bll.AddDepartmentInfo(testAddInfo);
            Assert.True(opResult.IsSucceed());

            opResult = m_bll.AddDepartmentInfo(testAddInfo);
            Assert.True(!opResult.IsSucceed() && opResult.RetMsg.Contains("已存在"));
        }



        [Fact]
        public void TestQueryDepartment()
        {
            var param = new QueryCompanyDepartmentInfoParam() { DepartmentName = TEST_DEPARTMENT_NAME };
            var queryResult = m_bll.GetEntityList(param);
            Assert.True(queryResult != null && queryResult.ResultCount > 0);

            param = new QueryCompanyDepartmentInfoParam() { DepartmentName = TEST_DEPARTMENT_NAME + "_notExist" };
            queryResult = m_bll.GetEntityList(param);
            Assert.True(queryResult != null && queryResult.ResultCount == 0);
        }



        [Fact]
        public void TestUpdateDepartment()
        {
            var testUpdateInfo = new CompanyDepartmentEntity()
            {
                Fname = TEST_DEPARTMENT_NAME,
                Fcomment = TEST_DEPARTMENT_COMMENT + "_update"
            };

            var opResult = m_bll.UpdateDepartmentInfo(testUpdateInfo);
            Assert.True(opResult.IsSucceed());

            testUpdateInfo = new CompanyDepartmentEntity()
            {
                Fname = TEST_DEPARTMENT_NAME + "_notExist",
                Fcomment = TEST_DEPARTMENT_COMMENT + "_update"
            };

            opResult = m_bll.UpdateDepartmentInfo(testUpdateInfo);
            Assert.True(!opResult.IsSucceed() && opResult.RetMsg.Contains("不存在"));
        }


        [Fact]
        public void TestDelDepartment()
        {
            var testDelInfo = new CompanyDepartmentEntity()
            {
                Fname = TEST_DEPARTMENT_NAME,
            };

            var opResult = m_bll.DelDepartmentInfo(testDelInfo);
            Assert.True(opResult.IsSucceed());
        }
    }
}
