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


namespace WL_OA.BLL
{
    public partial class FreBusinessCenterBLL : CommBaseBLL<FreBusinessCenterEntity,QueryFreBusinessCenterParam>
    {
        /// <summary>
        /// 添加业务工作单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public BaseOpResult AddEntity(FreBussinessOpCenterDTO dto)
        {
            dto.IsValid();

            //var listID = this.GenListID();
            var listID = this.GenWorkListID(SystemSettings.COMPANY_APP_PREFIX);

            // 基本信息，用于查询和关联
            var businessBasicInfo = new FreBusinessBasicInfoEntity()
            {
                Flist_id = listID,
                Fstart_time = DateTime.Now,
                Finput_time = DateTime.Now,
                Flast_modify_time = DateTime.Now
            };

            dto.LinkListID(listID);

            var session = NHibernateSessionManager.GetSession();

            var trans = session.BeginTransaction();

            try
            {
                session.Save(dto.OrderInfo);
                session.Save(dto.HoldGoodsInfo);
                session.Save(dto.LayGoodsInfo);

                // FIXME：批量列表添加出现异常，待修复（null id in WL_OA.Data.entity.FreBusinessContainsInfoEntity entry (don't flush the Session after an exception occurs)）
                //AddEntityList(session, dto.ContainsInfoList, true);
                session.AddEntityListEx(dto.ContainsInfoList);
                session.Save(dto.MatterInfo);
                session.Save(dto.AssuranceInfo);
                session.Save(dto.SeaTransportInfo);
                session.Save(dto.OpInfo);
                session.Save(dto.OtherInfo);

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            
            return BaseOpResult.SucceedInstance;
        }



        public BaseOpResult Del(string listID)
        {
            var session = NHibernateSessionManager.GetSession();

            var trans = session.BeginTransaction();

            try
            {
                // 这里删除需要用到query了
                throw new NotImplementedException();                
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }

            return BaseOpResult.SucceedInstance;
        }
    }
}
