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

        public FreBussinessOpCenterDTO(FreBussinessOpCenterDTO rhs)
        {
            this.Flist_id = rhs.Flist_id;
            this.OrderInfo = new FreBusinessOrderInfoEntity(rhs.OrderInfo);
            this.HoldGoodsInfo = new FreBusinessHoldGoodsInfoEntity(rhs.HoldGoodsInfo);
            this.LayGoodsInfo = new FreBusinessLayGoodsInfoEntity(rhs.LayGoodsInfo);
            this.SeaTransportInfo = new FreBusinessSeaTransportInfoEntity(rhs.SeaTransportInfo);
            this.AssuranceInfo = new FreBusinessAssuranceInfoEntity(rhs.AssuranceInfo);
            this.MatterInfo = new FreBusinessMatterInfoEntity(rhs.MatterInfo);
            this.OpInfo = new FreBusinessOperationInfoEntity(rhs.OpInfo);
            this.OtherInfo = new FreBusinessOtherInfoEntity(rhs.OtherInfo);

            if (!rhs.ContainsInfoList.IsNullOrEmpty())
            {
                if (null == ContainsInfoList) ContainsInfoList = new List<FreBusinessContainsInfoEntity>();
                foreach (var e in rhs.ContainsInfoList)
                {
                    ContainsInfoList.Add(new FreBusinessContainsInfoEntity(e));
                }
            }
        }

        /// <summary>
        /// 工作单号，其实每个字信息里边都有存，这里提取出来方便操作
        /// </summary>
        public string Flist_id { get; set; }

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
        public IList<FreBusinessContainsInfoEntity> ContainsInfoList { get; set; } = new List<FreBusinessContainsInfoEntity>();

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
            //Flist_id = listID;
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


        /// <summary>
        /// 校验数据合法性
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            var bRet = true;

            bRet = OrderInfo != null
                && HoldGoodsInfo != null
                && LayGoodsInfo != null;

            if (!bRet) throw new UserFriendlyException("工作单信息缺乏必要信息录入");

            bRet = bRet && OrderInfo.IsValid()
                && HoldGoodsInfo.IsValid()
                && LayGoodsInfo.IsValid();

            SeaTransportInfo?.IsValid();
            AssuranceInfo?.IsValid();        
            MatterInfo?.IsValid();
            OpInfo?.IsValid();
            OtherInfo?.IsValid();

            if(bRet)
            {
                if (ContainsInfoList != null && ContainsInfoList.Count > 0)
                {
                    foreach (var e in ContainsInfoList)
                    {
                        //if (null == e) continue;
                        if (!e.IsValid()) return false;
                    }
                }
            }

            return bRet;
        }


        /// <summary>
        /// 修正更新的结果，如果数据没变化就置空不修改了
        /// </summary>
        /// <param name="toUpdateData"></param>
        /// <returns></returns>
        public FreBussinessOpCenterDTO FixUpdateResult(FreBussinessOpCenterDTO toUpdateData)
        {
            toUpdateData.IsValid();
            var srcData = this;            
            toUpdateData.Flist_id = toUpdateData.OrderInfo.Flist_id;
            if (srcData.OrderInfo == toUpdateData.OrderInfo) toUpdateData.OrderInfo = null;
            if (srcData.HoldGoodsInfo == toUpdateData.HoldGoodsInfo) toUpdateData.HoldGoodsInfo = null;
            if (srcData.LayGoodsInfo == toUpdateData.LayGoodsInfo) toUpdateData.LayGoodsInfo = null;
            if (srcData.AssuranceInfo == toUpdateData.AssuranceInfo) toUpdateData.AssuranceInfo = null;
            if (srcData.MatterInfo == toUpdateData.MatterInfo) toUpdateData.MatterInfo = null;
            if (srcData.OpInfo == toUpdateData.OpInfo) toUpdateData.OpInfo = null;
            if (srcData.OtherInfo == toUpdateData.OtherInfo) toUpdateData.OtherInfo = null;
            if (srcData.SeaTransportInfo == toUpdateData.SeaTransportInfo) toUpdateData.SeaTransportInfo = null;

            var toUpdateContainsList = new List<FreBusinessContainsInfoEntity>();

            if(!toUpdateData.ContainsInfoList.IsNullOrEmpty())
            {
                foreach(var eToUpdate in toUpdateData.ContainsInfoList)
                {
                    if (eToUpdate.Fid == 0)
                    {
                        // 需要新增的记录
                        toUpdateContainsList.Add(eToUpdate);
                        continue;
                    }

                    // 删除的记录这里不处理，在编辑工作单UI中，单独发送删除请求

                    foreach (var eSrc in this.ContainsInfoList)
                    {
                        // FIXME：这里待定，因为目前还不确定
                        if(eToUpdate.Fid == eSrc.Fid)
                        {
                            if(eToUpdate != eSrc)
                            {
                                toUpdateContainsList.Add(eToUpdate);
                            }
                            break;
                        }
                    }
                }
                toUpdateData.ContainsInfoList = toUpdateContainsList;
            }
            else
            {
                srcData.ContainsInfoList = null;
            }

            return toUpdateData;
        }


        /// <summary>
        /// 判断DTO的数据集是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsNullOrEmpty()
        {
            return (
                OrderInfo == null 
                && HoldGoodsInfo == null
                && LayGoodsInfo == null
                && AssuranceInfo == null
                && MatterInfo == null
                && OpInfo == null
                && OtherInfo == null
                && SeaTransportInfo == null
                && OrderInfo == null
                && ContainsInfoList.IsNullOrEmpty()
                );
        }
    }
}
