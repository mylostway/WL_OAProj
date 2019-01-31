using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

using Xunit;

using WL_OA.Data;
using WL_OA.BLL;
using WL_OA.Data.dto;
using WL_OA.Data.param;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ConsoleTest.Utils;

namespace ConsoleTest.test_cases
{
    public class TestFreBusiness
    {
        const int TEST_ADD_COUNT = 13;

        FreBusinessCenterBLL busBLL = new FreBusinessCenterBLL();

        ObservableCollection<FreBussinessOpCenterDTO> genTestData = null;

        public TestFreBusiness()
        {
            busBLL.SetRequestContext(TestSetting.TEST_SYS_REQ_CONTEXT);
            genTestData = FakeDataHelper.Instance.CreateFakeDataCollection<FreBussinessOpCenterDTO>(TEST_ADD_COUNT);

            // 设置依赖
            busBLL.SetServicesProvider(DIHelper.Instance.GetServicesProvider());

            //foreach(var e in genTestData)
            //{
            //    var listID = busBLL.GenWorkListID("1001");
            //    e.LinkListID(listID);
            //}
        }

        [Fact]
        public void TestAddFreBusinessInfo()
        {
            foreach(var e in genTestData)
            {
                busBLL.AddEntity(e);
            }
        }


        [Fact]
        public void TestUpdateFreBusinessInfo()
        {
            var queryParam = new QueryFreBusinessCenterParam();
            queryParam.DateType = DateTypeEnums.BookedShipStartDate;
            queryParam.StartDate = DateTime.Parse("1970-01-01");
            queryParam.EndDate = DateTime.Now;
            var queryResult = busBLL.GetFreBusinessOpCenterList(queryParam);
            Assert.True(queryResult != null && queryResult.ResultCount > 0);

            var testFreBusinessDTO = queryResult.ResultData[0];
            var testUpdateOrderInfo = testFreBusinessDTO.OrderInfo;

            testUpdateOrderInfo.Fto_place = "update_to_test_place2";
            testUpdateOrderInfo.Fbusiness_date = DateTime.Now;

            busBLL.UpdateFreBusinessPartInfo(testUpdateOrderInfo);
        }



        [Fact]
        public void TestDelFreBusinessRecord()
        {
            var queryParam = new QueryFreBusinessCenterParam();
            queryParam.DateType = DateTypeEnums.BookedShipStartDate;
            queryParam.StartDate = DateTime.Parse("1970-01-01");
            queryParam.EndDate = DateTime.Now;
            var queryResult = busBLL.GetFreBusinessOpCenterList(queryParam);
            Assert.True(queryResult != null && queryResult.ResultCount > 0);

            var testFreBusinessDTO = queryResult.ResultData[0];

            //busBLL.Del(testFreBusinessDTO.OrderInfo.Flist_id);

            busBLL.Del(testFreBusinessDTO.OrderInfo.Flist_id, false);
        }


        [Fact]
        public void TestQueryFreBusinessInfo()
        {
            var queryParam = new QueryFreBusinessCenterParam();
            var queryResult = busBLL.GetFreBusinessOpCenterList(queryParam);
            Assert.True(queryResult != null && queryResult.ResultCount > 0);

            // 只用下定船期时间查
            queryParam.DateType = DateTypeEnums.BookedShipStartDate;
            DateTime dtMin = DateTime.Parse("1970-01-01"), dtMax = DateTime.Now;
            foreach(var e in genTestData)
            {
                foreach(var eC in e.ContainsInfoList)
                {
                    if (eC.Fbook_date > dtMax) dtMax = eC.Fback_date;
                    if (eC.Fbook_date < dtMin) dtMin = eC.Fbook_date;
                }
            }
            queryParam.StartDate = dtMin;
            queryParam.EndDate = dtMax;
            queryResult = busBLL.GetFreBusinessOpCenterList(queryParam);
            Assert.True(queryResult != null && queryResult.ResultCount > 0);


            // 只用预期到达时间查
            queryParam.DateType = DateTypeEnums.WantedReachDate;
            dtMin = DateTime.Parse("1970-01-01");
            dtMax = DateTime.Now;
            foreach (var e in genTestData)
            {
                if (e.SeaTransportInfo.Fpredit_reach_date > dtMax) dtMax = e.SeaTransportInfo.Fpredit_reach_date.Value;
                if (e.SeaTransportInfo.Fpredit_reach_date < dtMin) dtMin = e.SeaTransportInfo.Fpredit_reach_date.Value;
            }
            queryParam.StartDate = dtMin;
            queryParam.EndDate = dtMax;
            queryResult = busBLL.GetFreBusinessOpCenterList(queryParam);
            Assert.True(queryResult != null && queryResult.ResultCount > 0);


            // 海运时间和交易工单一起查
            queryParam.DateType = DateTypeEnums.WantedReachDate;
            dtMin = DateTime.Parse("1970-01-01");
            dtMax = DateTime.Now;
            foreach (var e in genTestData)
            {
                if (e.SeaTransportInfo.Fpredit_reach_date > dtMax) dtMax = e.SeaTransportInfo.Fpredit_reach_date.Value;
                if (e.SeaTransportInfo.Fpredit_reach_date < dtMin) dtMin = e.SeaTransportInfo.Fpredit_reach_date.Value;
            }
            queryParam.StartDate = dtMin;
            queryParam.EndDate = dtMax;
            queryParam.ListID = genTestData[1].OrderInfo.Flist_id;
            queryResult = busBLL.GetFreBusinessOpCenterList(queryParam);


            // 单查一个柜号
            queryParam.StartDate = null;
            queryParam.EndDate = null;
            queryParam.ListIDType = ListIDTypeEnums.CabinetNo;
            var testContainInfo = genTestData[3].ContainsInfoList[0];
            queryParam.ListID = "3142518381";//testContainInfo.Fcabinet_no;
            queryResult = busBLL.GetFreBusinessOpCenterList(queryParam);
            Assert.NotNull(queryResult.ResultData);

            // 单查一个船运号
            queryParam.ListIDType = ListIDTypeEnums.ShipNo;
            var testSeaInfo = genTestData[11].SeaTransportInfo;
            queryParam.ListID = testSeaInfo.Fship_no;
            queryResult = busBLL.GetFreBusinessOpCenterList(queryParam);
        }




    }
}
