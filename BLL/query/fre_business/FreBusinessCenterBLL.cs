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
                Flast_modify_time = DateTime.Now,
                Finputor = GetRequestContext().LoginInfo.Account
        };

            dto.LinkListID(listID);

            dto.OpInfo.Finputor = GetRequestContext().LoginInfo.Name;

            using (var session = NHibernateSessionManager.GetSession())
            {
                var trans = session.BeginTransaction();
                try
                {
                    session.Save(businessBasicInfo);
                    session.Save(dto.OrderInfo);
                    session.Save(dto.HoldGoodsInfo);
                    session.Save(dto.LayGoodsInfo);

                    // FIXME：批量列表添加出现异常，待修复（null id in WL_OA.Data.entity.FreBusinessContainsInfoEntity entry (don't flush the Session after an exception occurs)）                    
                    //session.AddEntityListEx(dto.ContainsInfoList,true);
                    foreach(var e in dto.ContainsInfoList)
                    {
                        session.Save(e);                       
                    }
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
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }

        

        /// <summary>
        /// 删除工作单
        /// </summary>
        /// <param name="listID">工作单号</param>
        /// <param name="isSoftDel">软删除，默认true</param>
        /// <returns></returns>
        public BaseOpResult Del(string listID,bool isSoftDel = true)
        {
            CheckValidWorkListId(listID);
            using (var session = NHibernateSessionManager.GetSession())
            {
                var trans = session.BeginTransaction();
                try
                {
                    var nRet = 0;
                    if(isSoftDel)
                    {
                        nRet = session.CreateSQLQuery($"update t_fre_business_basic_info set Fstate=0 where Flist_id='{listID}'").ExecuteUpdate();
                        if(nRet > 0)
                        {
                            // nRet > 0 判断是否已经在 t_fre_business_basic_info 中操作过一次，如果 <=0 代表这个数据已经没有，后续的操作都不做了
                            for (var i = 1;i < FreBusinessTables.Length;i++)
                            {
                                session.CreateSQLQuery($"update {FreBusinessTables[i]} set Fstate=0 where Flist_id='{listID}'").ExecuteUpdate();
                            }
                        }                        
                    }
                    else
                    {
                        nRet = session.CreateSQLQuery($"delete from t_fre_business_basic_info where Flist_id='{listID}'").ExecuteUpdate();
                        if (nRet > 0)
                        {
                            // nRet > 0 判断是否已经在 t_fre_business_basic_info 中操作过一次，如果 <=0 代表这个数据已经没有，后续的操作都不做了
                            for (var i = 1; i < FreBusinessTables.Length; i++)
                            {
                                session.CreateSQLQuery($"delete from {FreBusinessTables[i]} where Flist_id='{listID}'").ExecuteUpdate();
                            }
                        }
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, ex.Message);
                }                
                session.Flush();
            }
            return BaseOpResult.SucceedInstance;
        }



        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="listIDList"></param>
        /// <param name="isSoftDel"></param>
        /// <returns></returns>
        public BaseOpResult BatchDel(IEnumerable<string> listIDs, bool isSoftDel = true)
        {
            if (null == listIDs) return BaseOpResult.SucceedInstance;
            BaseOpResult ret = null;
            bool bIsAllSucceed = true;
            var failListIDs = new List<string>();
            // 目前批量删除采用循环调用实现，后续再考虑是否有优化余地
            foreach (var eListID in listIDs)
            {
                ret = Del(eListID, isSoftDel);
                if (!ret.IsSucceed())
                {
                    // 有操作失败，目前采用尽量操作形式
                    bIsAllSucceed = false;
                    failListIDs.Add(eListID);
                }
            }
            if(bIsAllSucceed) return BaseOpResult.SucceedInstance;
            return new BaseOpResult(QueryResultCode.Partly, $"操作不完全成功，失败工作单列表:{failListIDs.ToSplitString()}");
        }


        /// <summary>
        ///获取当前最新一个工作单信息
        /// </summary>
        /// <returns></returns>
        public FreBusinessBasicInfoEntity GetLastFreBusinessBasicInfo()
        {
            var session = NHibernateSessionManager.GetSession();

            // 查询当天最大交易单值
            var result = session.CreateSQLQuery($"select * from t_fre_business_basic_info where Flist_id = (select max(Flist_id) from t_fre_business_basic_info where Finput_time > '{DateTime.Now.ToDateStr()}')")
                .AddEntity(typeof(FreBusinessBasicInfoEntity)).List<FreBusinessBasicInfoEntity>();

            if (result == null || 0 == result.Count)
            {
                return null;
            }

            return result[0] as FreBusinessBasicInfoEntity;
        }
    }
}
