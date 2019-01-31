using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

using WL_OA.Data.entity;
using WL_OA.Data.utils;
using WL_OA.Data.dal;
using WL_OA.Data.param;
using WL_OA.BLL.query;
using WL_OA.Data;
using WL_OA.NET;

using ConsoleTest.test_cases;

using Newtonsoft.Json;
using log4net.Config;
using log4net;

namespace ConsoleTest
{
    class Program
    {
        static Program()
        {
            // 初始化日志配置
            XmlConfigurator.ConfigureAndWatch(new FileInfo(@"./App.config"));            
            

            // 初始化依赖

        }

        static void TestLocal()
        {
            SimpleTestCase.TestAddEntity();
            SimpleTestCase.TestQueryEntity();
        }

        static void TestNet()
        {            
            var bllAssembly = Assembly.GetAssembly(typeof(GoodsInfoBLL));

            var testServer = new SimpleUdpServer(NetBase.DEFAULT_PORT, (requestParam, endpoint) =>
            {
                try
                {
                    var reqMethodArr = requestParam.RequestMethod.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                    var totalTypeName = string.Format("{0}.{1}", "WL_OA.BLL.query", reqMethodArr[0]);

                    var callType = bllAssembly.GetType(totalTypeName);

                    var callInstance = bllAssembly.CreateInstance(totalTypeName);

                    var callMethod = callType.GetMethod(reqMethodArr[1]);

                    var callParamsInfo = callMethod.GetParameters();

                    if(callParamsInfo.Length != 1)
                    {
                        throw new WLOARequestException(NetHandleResultCode.ErrorFormat,"暂时不支持大于1个参数的请求");
                    }

                    var callMethodParam = JsonHelper.DeserializeTo(requestParam.RequestParam, callParamsInfo[0].ParameterType);

                    var callResult = callMethod.Invoke(callInstance, new object[] { callMethodParam });

                    return new NetHandleResult(callResult);
                }
                catch(WLOARequestException ex)
                {
                    return new NetHandleResult(ex.ResultCode, ex.Message);
                }
                catch (Exception ex)
                {
                    return new NetHandleResult(NetHandleResultCode.Failed, ex.Message);
                }
            });

            testServer.Listen();

            while(true)
            {
                Thread.Sleep(10);
            }
        }

        static void Main(string[] args)
        {
            //(new TestFreBusiness()).TestAddFreBusinessInfo();
            (new TestFreBusiness()).TestQueryFreBusinessInfo();
            //(new TestFreBusiness()).TestUpdateFreBusinessInfo();
            //(new TestFreBusiness()).TestDelFreBusinessRecord();
        }
    }
}
