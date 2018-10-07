using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.BLL.query;
using WL_OA.Data;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace ConsoleTest.test_cases
{
    public class SimpleTestCase
    {
        public static void TestAddEntity()
        {
            string TEST_USER = "test_sys";
            var addList = new List<DriverinfoEntity>();
            addList.Add(new DriverinfoEntity("alexguan", "15002094251", "440682198910155016", "EF738"));
            addList.Add(new DriverinfoEntity("alenguan", "15002094251", "440682198910155016", "EF738"));
            addList.Add(new DriverinfoEntity("brucekuan", "15002094251", "440682198910155016", "EF738"));
            addList.Add(new DriverinfoEntity("ccluan", "15002094251", "440682198910155016", "EF738"));
            addList.Add(new DriverinfoEntity("zzguan", "15002094251", "440682198910155016", "EF738"));
            (new DriverInfoBLL()).AddEntityList(addList);

            var goodList = new List<GoodsinfoEntity>();

            goodList.Add(new GoodsinfoEntity("氧化铝粉", "YHLF"));
            goodList.Add(new GoodsinfoEntity("塑料颗粒", "SLKL"));
            goodList.Add(new GoodsinfoEntity("不锈钢", "BXG"));
            goodList.Add(new GoodsinfoEntity("铁砂", "TS"));
            goodList.Add(new GoodsinfoEntity("灯具", "DJ"));
            goodList.Add(new GoodsinfoEntity("家具", "JJ"));
            (new GoodsInfoBLL()).AddEntityList(goodList);

            var wharfList = new List<WharfinfoEntity>();
            wharfList.Add(new WharfinfoEntity("广东省;佛山市;佛山港;佛山高明", "FSGM", TEST_USER));
            wharfList.Add(new WharfinfoEntity("广东省;佛山市;佛山港;佛山小塘", "FSXT", TEST_USER));
            wharfList.Add(new WharfinfoEntity("广东省;佛山市;佛山港;佛山和乐", "FSHL", TEST_USER));
            wharfList.Add(new WharfinfoEntity("广东省;江门市;开平港;开平水口", "KPSK", TEST_USER));
            wharfList.Add(new WharfinfoEntity("广西省;梧州市;梧州港;梧州赤水", "WZCS", TEST_USER));
            wharfList.Add(new WharfinfoEntity("广西省;梧州市;梧州港;梧州港", "WZG", TEST_USER));
            wharfList.Add(new WharfinfoEntity("广西省;防城港市;防城港;防城港", "FCG", TEST_USER));
            wharfList.Add(new WharfinfoEntity("广西省;贵港市;贵港港;贵港港", "GGG", TEST_USER));
            (new WharfInfoBLL()).AddEntityList(wharfList);

            var airLineList = new List<AirwayEntity>();
            airLineList.Add(new AirwayEntity("南方航空"));
            airLineList.Add(new AirwayEntity("春秋航空"));
            airLineList.Add(new AirwayEntity("中国国航"));
            (new AirLineInfoBLL()).AddEntityList(airLineList);
        }

        public static void TestQueryEntity()
        {
            var val = "".ToEnumVal(typeof(PaywayEnums));

            var val2 = "票结".ToEnumVal(typeof(PaywayEnums));

            var driverInfoList = (new DriverInfoBLL()).GetEntityList(new QueryDriverInfoParams(null, "alexguan"));

            var goodsInfoList = (new GoodsInfoBLL()).GetEntityList(new QueryGoodsInfoParam());

            var wharfInfoList = (new WharfInfoBLL()).GetEntityList(new QueryWharfInfoParam());

            var airlineList = (new AirLineInfoBLL()).GetEntityList(new QueryAirLineInfoParam());

            var customInfoList = (new CustomerManagerBLL()).GetEntityList(new QueryCustomerInfoParam());
        }
    }
}
