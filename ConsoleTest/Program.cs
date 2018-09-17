using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Data.entity;
using Data.utils;
using Data.dal;
using Data.param;
using BLL.query;

namespace ConsoleTest
{
    class Program
    {
        static void TestAddEntity()
        {
            string TEST_USER = "test_sys";
            var addList = new List<DriverInfoEntity>();
            addList.Add(new DriverInfoEntity("alexguan", "15002094251", "440682198910155016", "EF738"));
            addList.Add(new DriverInfoEntity("alenguan", "15002094251", "440682198910155016", "EF738"));
            addList.Add(new DriverInfoEntity("brucekuan", "15002094251", "440682198910155016", "EF738"));
            addList.Add(new DriverInfoEntity("ccluan", "15002094251", "440682198910155016", "EF738"));
            addList.Add(new DriverInfoEntity("zzguan", "15002094251", "440682198910155016", "EF738"));
            (new DriverInfoBLL()).AddEntityList(addList);

            var goodList = new List<GoodsInfoEntity>();

            goodList.Add(new GoodsInfoEntity("氧化铝粉", "YHLF"));
            goodList.Add(new GoodsInfoEntity("塑料颗粒", "SLKL"));
            goodList.Add(new GoodsInfoEntity("不锈钢", "BXG"));
            goodList.Add(new GoodsInfoEntity("铁砂", "TS"));
            goodList.Add(new GoodsInfoEntity("灯具", "DJ"));
            goodList.Add(new GoodsInfoEntity("家具", "JJ"));
            (new GoodsInfoBLL()).AddEntityList(goodList);

            var wharfList = new List<WharfInfoEntity>();
            wharfList.Add(new WharfInfoEntity("广东省;佛山市;佛山港;佛山高明", "FSGM", TEST_USER));
            wharfList.Add(new WharfInfoEntity("广东省;佛山市;佛山港;佛山小塘", "FSXT", TEST_USER));
            wharfList.Add(new WharfInfoEntity("广东省;佛山市;佛山港;佛山和乐", "FSHL", TEST_USER));
            wharfList.Add(new WharfInfoEntity("广东省;江门市;开平港;开平水口", "KPSK", TEST_USER));
            wharfList.Add(new WharfInfoEntity("广西省;梧州市;梧州港;梧州赤水", "WZCS", TEST_USER));
            wharfList.Add(new WharfInfoEntity("广西省;梧州市;梧州港;梧州港", "WZG", TEST_USER));
            wharfList.Add(new WharfInfoEntity("广西省;防城港市;防城港;防城港", "FCG", TEST_USER));
            wharfList.Add(new WharfInfoEntity("广西省;贵港市;贵港港;贵港港", "GGG", TEST_USER));
            (new WharfInfoBLL()).AddEntityList(wharfList);

            var airLineList = new List<AirLineEntity>();
            airLineList.Add(new AirLineEntity("南方航空"));
            airLineList.Add(new AirLineEntity("春秋航空"));
            airLineList.Add(new AirLineEntity("中国国航"));
            (new AirInfoBLL()).AddEntityList(airLineList);
        }

        static void TestQueryEntity()
        {            
            var driverInfoList = (new DriverInfoBLL()).GetEntityList(new QueryDriverInfoParams(null,"alexguan"));

            var goodsInfoList = (new GoodsInfoBLL()).GetEntityList(new QueryGoodsInfoParam());

            var wharfInfoList = (new WharfInfoBLL()).GetEntityList(new QueryWharfInfoParam());

            var airlineList = (new AirInfoBLL()).GetEntityList(new QueryAirLineInfoParam());
        }


        static void Main(string[] args)
        {
            TestAddEntity();
            TestQueryEntity();

            Console.Read();
        }
    }
}
