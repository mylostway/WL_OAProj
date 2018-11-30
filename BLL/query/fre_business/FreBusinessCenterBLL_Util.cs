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
            var strBusType = busType.PadLeft(LIST_ID_BUS_TYPE_TAKE - busType.Length, '0');

            var strTime = DateTime.Now.ToDateSecondStr();

            var strUserID = GetRequestContext().LoginInfo.ID.ToUserID();

            var nCounter = Interlocked.Increment(ref s_idCounter);

            if(nCounter >= MAX_COUNTER)
            {
                Interlocked.CompareExchange(ref s_idCounter, 0, MAX_COUNTER);

                // 其实这里没必要要求这么“原子化”，因为正常情况下每个员工请求一个交易单需要的时间远大于1秒
                //nCounter = Interlocked.Increment(ref s_idCounter);
                nCounter = 1;
            }

            var strCounter = string.Format("{0:D2}", nCounter);

            return string.Format("{0}{1}{2}{3}{4}", busType, strTime, strUserID, STR_UNUSED, strCounter);
        }
    }
}
