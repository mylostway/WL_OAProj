using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BLL.util;
using WL_OA.Data;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;

namespace WL_OA.BLL
{
    public partial class FreBusinessCenterBLL : CommBaseBLL<FreBusinessCenterEntity, QueryFreBusinessCenterParam>
    {
        static FreBusinessCenterBLL()
        {
            var instance = new FreBusinessCenterBLL();
            var lastFreBusEntity = instance.GetLastFreBusinessBasicInfo();
            if (null != lastFreBusEntity)
            {
                var listId = lastFreBusEntity.Flist_id;
                var todayStr = DateTime.Now.ToDateStr();
                var dateTimeOffsetInStr = listId.Length - (8 + MAX_GEN_LIST_ID_TEN_TIMES);
                var lastEntityDayStr = listId.Substring(dateTimeOffsetInStr, 8);
                if (todayStr == lastEntityDayStr)
                {
                    var counterStr = listId.Substring(dateTimeOffsetInStr + 8);
                    s_idCounter = int.Parse(counterStr);
                }
                else
                {
                    s_idCounter = 0;
                }
            }
            else
            {
                s_idCounter = 0;
            }
        }



        /// <summary>
        /// 业务类型占位
        /// </summary>
        public const int LIST_ID_BUS_TYPE_TAKE = 4;

        /// <summary>
        /// 保留位
        /// </summary>
        public const string STR_UNUSED = "0000";

        /// <summary>
        /// 交易单ID顺序计数器
        /// </summary>
        public static int s_idCounter = 0;

        /// <summary>
        /// 最大交易单计数器，按照设计每秒每个员工最多产生99个交易单
        /// </summary>
        public const int MAX_COUNTER = 99;

        /// <summary>
        /// 生成交易单ID，规则（业务类型（4字节） + 时间（到秒，yyyyMMddhhmmss,14字节） + 员工号（8字节） + 保留位（4字节） + 顺序号（2字节） = 32字节）
        /// </summary>
        /// <param name="busType"></param>
        /// <returns></returns>
        public string GenListID(string busType = "")
        {
            if (string.IsNullOrEmpty(busType)) busType = "";
            if (busType.Length > LIST_ID_BUS_TYPE_TAKE)
                throw new UserFriendlyException($"生成交易单操作，传入的业务类型：{busType}异常", ExceptionScope.Parameter);
            var strBusType = busType.PadLeft(LIST_ID_BUS_TYPE_TAKE - busType.Length, '0');

            var strTime = DateTime.Now.ToDateSecondStr();

            var strUserID = GetRequestContext().LoginInfo.Fid.ToUserID();

            var nCounter = Interlocked.Increment(ref s_idCounter);

            if(nCounter >= MAX_COUNTER)
            {
                Interlocked.CompareExchange(ref s_idCounter, 0, MAX_COUNTER);

                // 其实这里没必要要求这么“原子化”，因为正常情况下每个员工请求一个交易单需要的时间远大于1秒
                //nCounter = Interlocked.Increment(ref s_idCounter);
                nCounter = 1;
            }

            var strCounter = string.Format("{0:D2}", nCounter);

            return string.Format("{0}{1}{2}{3}{4}", strBusType, strTime, strUserID, STR_UNUSED, strCounter);
        }


        /// <summary>
        /// 最大产生订单号的10次防数
        /// </summary>
        private const int MAX_GEN_LIST_ID_TEN_TIMES = 7;

        /// <summary>
        /// 辅助常量，去除prefix前缀的长度
        /// </summary>
        const int EXPECT_PREFIX_LEN_IN_LIST_ID = 8 + MAX_GEN_LIST_ID_TEN_TIMES;

        /// <summary>
        /// 最大工作单长度
        /// </summary>
        const int MAX_LIST_ID_LEN = 32;

        /// <summary>
        /// 生成工作单号（根据新集运规则）
        /// </summary>
        /// <param name="busType"></param>
        /// <returns></returns>
        public string GenWorkListID(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new UserFriendlyException("产生工作单号的业务前缀不能为空！", ExceptionScope.Parameter);
            }

            var strTime = DateTime.Now.ToDateStr();
            
            var nCounter = Interlocked.Increment(ref s_idCounter);

            if (nCounter >= MAX_COUNTER)
            {                
                throw new UserFriendlyException($"今天产生的订单量超出最大上限 {Math.Pow(10, MAX_GEN_LIST_ID_TEN_TIMES)}张!请联系管理员");
            }

            // 如此算，这个最大一天产生 10 ^ 7张单
            var strCounter = string.Format("{0:D7}", nCounter);

            return string.Format("{0}{1}{2}", prefix, strTime, strCounter);
        }


        /// <summary>
        /// 判断一个工作单号是否合法
        /// </summary>
        /// <param name="workListID"></param>
        /// <returns></returns>
        public void CheckValidWorkListId(string workListID)
        {
            SAssert.MustTrue(!workListID.NullOrEmpty(),"工作单号异常，不能为空串");
            SAssert.MustTrue(workListID.Length > EXPECT_PREFIX_LEN_IN_LIST_ID && workListID.Length <= MAX_LIST_ID_LEN, $"工作单号异常：{workListID}");
            var strExpectPrefix = workListID.Substring(workListID.Length - EXPECT_PREFIX_LEN_IN_LIST_ID);
            long parseNum = 0;
            SAssert.MustTrue(long.TryParse(strExpectPrefix, out parseNum), $"工作单号异常：{workListID}");
            // 如果更严格的检查，可以查一下业务前缀是否已经记录
        }



        /// <summary>
        /// 检测用户是否有权限操作该委托单
        /// </summary>
        public void CheckOpUserHasRight(string listID)
        {
            CheckValidWorkListId(listID);


        }
    }
}
