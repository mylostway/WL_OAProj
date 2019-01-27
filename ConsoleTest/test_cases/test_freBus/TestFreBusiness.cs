using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using WL_OA.Data;
using WL_OA.BLL;
using WL_OA.Data.dto;
using System.Collections.ObjectModel;
using WL_OA.Data.param;

namespace ConsoleTest.test_cases
{
    public class TestFreBusiness
    {
        const int TEST_ADD_COUNT = 13;

        FreBusinessCenterBLL busBLL = new FreBusinessCenterBLL();

        ObservableCollection<FreBussinessOpCenterDTO> genTestData = null;

        public TestFreBusiness()
        {
            genTestData = FakeDataHelper.Instance.CreateFakeDataCollection<FreBussinessOpCenterDTO>(TEST_ADD_COUNT);
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
        public void TestQueryFreBusinessInfo()
        {
            var queryParam = new QueryFreBusinessCenterParam();
            

            var queryResult = busBLL.GetFreBusinessOpCenterList(queryParam);
        }
    }
}
