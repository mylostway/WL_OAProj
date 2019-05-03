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
using WL_OA.Data.entity;

namespace ConsoleTest.test_cases
{
    public class TestFreBusiness
    {
        const int TEST_ADD_COUNT = 13;

        FreBusinessCenterBLL m_bll = new FreBusinessCenterBLL();

        ObservableCollection<FreBussinessOpCenterDTO> genTestData = null;

        public TestFreBusiness()
        {
            // 请求上下文设置
            m_bll.SetRequestContext(TestSetting.TEST_SYS_REQ_CONTEXT);
            // 设置依赖
            m_bll.SetServicesProvider(DIHelper.Instance.GetServicesProvider());

            genTestData = FakeDataHelper.Instance.CreateFakeDataCollection<FreBussinessOpCenterDTO>(TEST_ADD_COUNT);

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
                var opResult = m_bll.AddEntity(e);
                Assert.True(opResult.IsSucceed());
            }
        }


        [Fact]
        public void TestUpdateFreBusinessInfo()
        {
            var queryParam = new QueryFreBusinessCenterParam();
            queryParam.DateType = DateTypeEnums.BookedShipStartDate;
            queryParam.StartDate = DateTime.Parse("1970-01-01");
            queryParam.EndDate = DateTime.Now;
            var queryResult = m_bll.GetFreBusinessOpCenterList(queryParam);
            Assert.True(queryResult != null && queryResult.ResultCount > 0);

            var testFreBusinessDTO = queryResult.ResultData[0];

            var testUpdateOrderInfo = testFreBusinessDTO.OrderInfo;

            testUpdateOrderInfo.Fto_place = "update_to_test_place2";
            testUpdateOrderInfo.Fbusiness_date = DateTime.Now;

            // 测试部分更新API
            var updateResult = m_bll.UpdateFreBusinessPartInfo(testUpdateOrderInfo);

            Assert.True(updateResult.IsSucceed());

            // 测试 更新数据筛选 + 整体更新API
            var toUpdateDTO = new FreBussinessOpCenterDTO(testFreBusinessDTO);

            testFreBusinessDTO.FixUpdateResult(toUpdateDTO);

            // 和原对象没改动，这里toUpdateDTO 应该为nullOrEmpty
            Assert.True(toUpdateDTO.IsNullOrEmpty());
            
            toUpdateDTO = new FreBussinessOpCenterDTO(testFreBusinessDTO);
            toUpdateDTO.AssuranceInfo.Fgoods_val += 1;
            testFreBusinessDTO.FixUpdateResult(toUpdateDTO);

            // 和原对象只改动了AssuranceInfo的值，只有AssuranceInfo不为null
            Assert.True(!toUpdateDTO.IsNullOrEmpty() && toUpdateDTO.AssuranceInfo != null);

            updateResult = m_bll.UpdateFreBusinessDTO(toUpdateDTO);

            Assert.True(updateResult.IsSucceed());

            toUpdateDTO.AssuranceInfo = null;

            // 只有AssuranceInfo不为null
            Assert.True(toUpdateDTO.IsNullOrEmpty());


            // 测试几部分信息更新
            toUpdateDTO = new FreBussinessOpCenterDTO(testFreBusinessDTO);

            // 修改OrderInfo
            toUpdateDTO.OrderInfo.Fbusinesser += "_fT";
            toUpdateDTO.OrderInfo.Fbusiness_date = DateTime.Now;

            // 修改其中几个ContainsInfo
            toUpdateDTO.ContainsInfoList[0].Fback_date = DateTime.Now;
            toUpdateDTO.ContainsInfoList[1].Fback_date = DateTime.Now;
            // 增加ContainsInfo
            toUpdateDTO.ContainsInfoList.Add(FakeDataHelper.Instance.GenData<FreBusinessContainsInfoEntity>());

            // 修改SeaTransportInfo
            toUpdateDTO.SeaTransportInfo.Ffirst_ship_get_date = DateTime.Now;

            testFreBusinessDTO.FixUpdateResult(toUpdateDTO);

            Assert.True(!toUpdateDTO.IsNullOrEmpty() 
                && toUpdateDTO.OrderInfo != null
                && toUpdateDTO.SeaTransportInfo != null
                && toUpdateDTO.ContainsInfoList.Count == 3);

            updateResult = m_bll.UpdateFreBusinessDTO(toUpdateDTO);

            Assert.True(updateResult.IsSucceed());
        }



        [Fact]
        public void TestDelFreBusinessRecord()
        {
            var queryParam = new QueryFreBusinessCenterParam();
            queryParam.DateType = DateTypeEnums.BookedShipStartDate;
            queryParam.StartDate = DateTime.Parse("1970-01-01");
            queryParam.EndDate = DateTime.Now;
            var queryResult = m_bll.GetFreBusinessOpCenterList(queryParam);
            Assert.True(queryResult != null && queryResult.ResultCount > 0);

            var testFreBusinessDTO = queryResult.ResultData[0];

            //busBLL.Del(testFreBusinessDTO.OrderInfo.Flist_id);

            m_bll.Del(testFreBusinessDTO.OrderInfo.Flist_id, false);
        }


        [Fact]
        public void TestQueryFreBusinessInfo()
        {
            var queryParam = new QueryFreBusinessCenterParam();
            var queryResult = m_bll.GetFreBusinessOpCenterList(queryParam);
            Assert.True(queryResult != null && queryResult.ResultCount > 0);

            // 只用下定船期时间查
            queryParam.DateType = DateTypeEnums.BookedShipStartDate;
            DateTime dtMin = DateTime.Parse("1970-01-01"), dtMax = DateTime.Now;
            foreach(var e in genTestData)
            {
                foreach(var eC in e.ContainsInfoList)
                {
                    if (eC.Fbook_date != null && eC.Fbook_date > dtMax) dtMax = eC.Fback_date.Value;
                    if (eC.Fbook_date != null && eC.Fbook_date < dtMin) dtMin = eC.Fbook_date.Value;
                }
            }
            queryParam.StartDate = dtMin;
            queryParam.EndDate = dtMax;
            queryResult = m_bll.GetFreBusinessOpCenterList(queryParam);
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
            queryResult = m_bll.GetFreBusinessOpCenterList(queryParam);
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
            queryResult = m_bll.GetFreBusinessOpCenterList(queryParam);


            // 单查一个柜号
            queryParam.StartDate = null;
            queryParam.EndDate = null;
            queryParam.ListIDType = ListIDTypeEnums.CabinetNo;
            var testContainInfo = genTestData[3].ContainsInfoList[0];
            queryParam.ListID = "3142518381";//testContainInfo.Fcabinet_no;
            queryResult = m_bll.GetFreBusinessOpCenterList(queryParam);
            Assert.NotNull(queryResult.ResultData);

            // 单查一个船运号
            queryParam.ListIDType = ListIDTypeEnums.ShipNo;
            var testSeaInfo = genTestData[11].SeaTransportInfo;
            queryParam.ListID = testSeaInfo.Fship_no;
            queryResult = m_bll.GetFreBusinessOpCenterList(queryParam);
        }




    }
}
