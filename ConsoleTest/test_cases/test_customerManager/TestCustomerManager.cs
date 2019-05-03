using ConsoleTest.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WL_OA.BLL.query;
using WL_OA.Data;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using Xunit;

namespace ConsoleTest.test_cases
{
    public class TestCustomerManager
    {
        const int TEST_ADD_COUNT = 13;

        CustomerManagerBLL m_bll = new CustomerManagerBLL();

        ObservableCollection<AddCustomerInfoDTO> genTestData = null;

        public TestCustomerManager()
        {
            // 请求上下文设置
            m_bll.SetRequestContext(TestSetting.TEST_SYS_REQ_CONTEXT);
            // 设置依赖
            m_bll.SetServicesProvider(DIHelper.Instance.GetServicesProvider());

            genTestData = FakeDataHelper.Instance.CreateFakeDataCollection<AddCustomerInfoDTO>(TEST_ADD_COUNT);
        }

        [Fact]
        public void TestAddCustomerInfo()
        {
            foreach (var e in genTestData)
            {
                var opResult = m_bll.AddEntity(e);
                Assert.True(opResult.IsSucceed());
            }
        }

        [Fact]
        public void TestUpdateCustomerInfo()
        {
            var queryParam = new QueryCustomerInfoParam();
            queryParam.DateType = DateTypeEnums.InputTime;
            queryParam.StartDate = DateTime.Parse("1970-01-01");
            queryParam.EndDate = DateTime.Now;
            var queryResult = m_bll.GetEntityList(queryParam);
            Assert.True(queryResult != null && queryResult.ResultCount > 0);

            var testDTO = queryResult.ResultData[0];

            var testUpdateDTO = m_bll.GetCustomerFullInfo(testDTO.Fid).ResultData;
            Assert.True(testUpdateDTO != null && testUpdateDTO.IsValid());

            testUpdateDTO.CustomerInfo.Fname = $"alex_test_{DateTime.Now.ToString("yyyyMMddHHmm")}";

            testUpdateDTO.CustomerInfo.BankAccountInfoList.Add(new CustomerBankAccountEntity()
            {
                Fcustomer_id = testUpdateDTO.CustomerInfo.Fid,
                Faccount = FakeDataHelper.GenRandomPhone(),
                Fmemo = $"alex_test_{DateTime.Now.ToString("yyyyMMddHHmm")}",
                Fbank_deposit = "XX行XX路支行",
                Fdeposit_name = "Alex关"
            });

            testUpdateDTO.CustomerInfo.BankAccountInfoList.Add(new CustomerBankAccountEntity()
            {
                Fcustomer_id = testUpdateDTO.CustomerInfo.Fid,
                Faccount = FakeDataHelper.GenRandomPhone(),
                Fmemo = $"alex_test_{DateTime.Now.ToString("yyyyMMddHHmm")}",
                Fbank_deposit = "XX行XX路支行2",
                Fdeposit_name = "Alex关2"
            });

            testUpdateDTO.CustomerInfo.BookSpaceReceiverInfoList.Add(new CustomerBookSpaceReceiverEntity()
            {
                Fcustomer_id = testUpdateDTO.CustomerInfo.Fid,
                Fship_company = "test_ship_company",
                Fmemo = $"alex_test_{DateTime.Now.ToString("yyyyMMddHHmm")}",
            });


            testUpdateDTO.CustomerInfo.ContactInfoList.Add(new CustomerContactEntity()
            {
                Fcustomer_id = testUpdateDTO.CustomerInfo.Fid,
                Fname = "new_concat",
                Fsex = 0,
                Fdata_status = 0,
                Fmemo = $"alex_test_{DateTime.Now.ToString("yyyyMMddHHmm")}",                
            });

            testUpdateDTO.CustomerInfo.ContactInfoList.Add(new CustomerContactEntity()
            {
                Fcustomer_id = testUpdateDTO.CustomerInfo.Fid,
                Fname = "new_concat2",
                Fsex = 0,
                Fdata_status = 0,
                Fmemo = $"alex_test_{DateTime.Now.ToString("yyyyMMddHHmm")}",
            });

            testUpdateDTO.CustomerInfo.ContactInfoList[0].Fmemo = $"alex_test_change_memo_0_{DateTime.Now.ToString("yyyyMMddHHmm")}";
            testUpdateDTO.CustomerInfo.ContactInfoList[1].Fmemo = $"alex_test_change_memo_1_{DateTime.Now.ToString("yyyyMMddHHmm")}";

            testUpdateDTO.CustomerInfo.HoldAddrInfoList.Add(new CustomerHoldAddrEntity()
            {
                Fcustomer_id = testUpdateDTO.CustomerInfo.Fid,
                Fgoods_owner = "alex_guan",
                Fmemo = $"alex_test_{DateTime.Now.ToString("yyyyMMddHHmm")}",
            });

            // 测试部分更新API
            var updateResult = m_bll.UpdateEntity(testUpdateDTO);

            Assert.True(updateResult.IsSucceed());
        }



        public void Run()
        {

        }
    }
}
