using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.entity;

namespace WL_OA.Data.dto
{
    /// <summary>
    /// 业务操作中心数据
    /// </summary>
    public class FreBussinessOpCenterDTO : IDataValidator
    {
        public FreBussinessOpCenterDTO() { }
        
        /// <summary>
        /// 委托信息
        /// </summary>
        public FreBusinessOrderInfoEntity OrderInfo { get; set; }

        /// <summary>
        /// 装货信息
        /// </summary>
        public FreBusinessHoldGoodsInfoEntity HoldGoodsInfo { get; set; }

        /// <summary>
        /// 卸货信息
        /// </summary>
        public FreBusinessLayGoodsInfoEntity LayGoodsInfo { get; set; }

        /// <summary>
        /// 货柜信息
        /// </summary>
        public List<FreBusinessContainsInfoEntity> ContainsInfoList { get; set; } = new List<FreBusinessContainsInfoEntity>();

        /// <summary>
        /// 海运信息
        /// </summary>
        public FreBusinessSeaTransportInfoEntity SeaTransportInfo { get; set; }

        /// <summary>
        /// 保险信息
        /// </summary>
        public FreBusinessAssuranceInfoEntity AssuranceInfo { get; set; }

        /// <summary>
        /// 事项信息
        /// </summary>
        public FreBusinessMatterInfoEntity MatterInfo { get; set; }

        /// <summary>
        /// 操作信息
        /// </summary>
        public FreBusinessOperationInfoEntity OpInfo { get; set; }

        /// <summary>
        /// 其他信息
        /// </summary>
        public FreBusinessOtherInfoEntity OtherInfo { get; set; }

        /// <summary>
        /// 链接交易单号
        /// </summary>
        /// <param name="listID"></param>
        public void LinkListID(string listID)
        {
            OrderInfo.Flist_id = listID;
            HoldGoodsInfo.Flist_id = listID;
            LayGoodsInfo.Flist_id = listID;
            SeaTransportInfo.Flist_id = listID;
            AssuranceInfo.Flist_id = listID;
            MatterInfo.Flist_id = listID;
            OpInfo.Flist_id = listID;
            OtherInfo.Flist_id = listID;

            if(ContainsInfoList != null && ContainsInfoList.Count > 0)
            {
                foreach (var e in ContainsInfoList)
                {
                    e.Flist_id = listID;
                }
            }            
        }


        public bool IsValid()
        {
            return true;
            var bRet = OrderInfo.IsValid()
                && HoldGoodsInfo.IsValid()
                && LayGoodsInfo.IsValid()
                && SeaTransportInfo.IsValid()
                && AssuranceInfo.IsValid()
                && MatterInfo.IsValid()
                && OpInfo.IsValid()
                && OtherInfo.IsValid();

            if(bRet)
            {
                if (ContainsInfoList != null && ContainsInfoList.Count > 0)
                {
                    foreach (var e in ContainsInfoList)
                    {
                        if (!e.IsValid()) return false;
                    }
                }                    
            }

            return bRet;
        }
    }
}
