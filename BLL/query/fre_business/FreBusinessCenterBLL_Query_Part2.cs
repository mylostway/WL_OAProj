using BLL.util;
using WL_OA.Data;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;
using WL_OA.Data.consts;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using NHibernate.Transform;

namespace WL_OA.BLL
{
    public partial class FreBusinessCenterBLL : CommBaseBLL<FreBusinessCenterEntity, QueryFreBusinessCenterParam>
    {

        /// <summary>
        /// 获取单个工单详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FreBussinessOpCenterDTO GetDetail(int id)
        {
            var session = NHibernateSessionManager.GetSession();

            var basicInfo = session.Get<FreBusinessBasicInfoEntity>(id);

            if (null == basicInfo) throw new UserFriendlyException($"业务数据ID{id}不存在!请核实数据");

            return GetDetail(basicInfo);
        }


        /// <summary>
        /// 获取单个工单详细信息
        /// </summary>
        /// <param name="workID"></param>
        /// <returns></returns>
        public FreBussinessOpCenterDTO GetDetail(string workID)
        {
            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<FreBusinessBasicInfoEntity>();

            query.And(x => x.Flist_id == workID);

            var basicInfo = query.SingleOrDefault();

            if (null == basicInfo) throw new UserFriendlyException($"工作单号{workID}不存在!请核实数据");

            return GetDetail(basicInfo);
        }


        /// <summary>
        /// 获取单个工单详细信息
        /// </summary>
        /// <param name="basicInfo"></param>
        /// <returns></returns>
        public FreBussinessOpCenterDTO GetDetail(FreBusinessBasicInfoEntity basicInfo)
        {
            if (null == basicInfo) throw new UserFriendlyException($"工作单号{basicInfo.Flist_id}不存在!请核实数据");

            var workID = basicInfo.Flist_id;

            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<FreBusinessBasicInfoEntity>();

            var retDto = new FreBussinessOpCenterDTO();

            retDto.OrderInfo = session.QueryOver<FreBusinessOrderInfoEntity>().Where(x => x.Flist_id == workID).SingleOrDefault();
            retDto.HoldGoodsInfo = session.QueryOver<FreBusinessHoldGoodsInfoEntity>().Where(x => x.Flist_id == workID).SingleOrDefault();
            retDto.LayGoodsInfo = session.QueryOver<FreBusinessLayGoodsInfoEntity>().Where(x => x.Flist_id == workID).SingleOrDefault();
            retDto.ContainsInfoList = session.QueryOver<FreBusinessContainsInfoEntity>().Where(x => x.Flist_id == workID).List();
            retDto.SeaTransportInfo = session.QueryOver<FreBusinessSeaTransportInfoEntity>().Where(x => x.Flist_id == workID).SingleOrDefault();
            retDto.AssuranceInfo = session.QueryOver<FreBusinessAssuranceInfoEntity>().Where(x => x.Flist_id == workID).SingleOrDefault();
            retDto.MatterInfo = session.QueryOver<FreBusinessMatterInfoEntity>().Where(x => x.Flist_id == workID).SingleOrDefault();
            retDto.OpInfo = session.QueryOver<FreBusinessOperationInfoEntity>().Where(x => x.Flist_id == workID).SingleOrDefault();
            retDto.OtherInfo = session.QueryOver<FreBusinessOtherInfoEntity>().Where(x => x.Flist_id == workID).SingleOrDefault();

            if (!retDto.IsValid()) throw new UserFriendlyException($"工作单号{workID}数据异常!请联系管理员");

            return retDto;
        }
    }
}
