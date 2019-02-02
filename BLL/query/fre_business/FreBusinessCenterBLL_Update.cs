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
    public partial class FreBusinessCenterBLL : CommBaseBLL<FreBusinessCenterEntity, QueryFreBusinessCenterParam>
    {        
        /// <summary>
        /// 更新工作单部分信息
        /// </summary>
        /// <returns></returns>
        public BaseOpResult UpdateFreBusinessPartInfo<T>(T updateInfo)
            where T : BaseEntity<int>, IFreBusinessPartInfoEntity
        {
            var opUser = GetRequestContext().LoginInfo.Account;

            using (var session = NHibernateSessionManager.GetSession())
            {
                var srcResult = session.QueryOver<T>().Where(x => x.Flist_id == updateInfo.Flist_id).SingleOrDefault();

                if (null == srcResult)
                {
                    return new BaseOpResult(QueryResultCode.Failed, $"更新工作单信息不存在，更新失败，单号：{updateInfo.Flist_id}");
                }

                // 检查是否有权限修改数据状态
                var basicInfo = session.QueryOver<FreBusinessBasicInfoEntity>().Where(x => x.Flist_id == updateInfo.Flist_id).SingleOrDefault();

                if (null == basicInfo) return new BaseOpResult(QueryResultCode.Failed, $"工作单不存在,单号：{updateInfo.Flist_id}");

                if (basicInfo.Finputor != opUser
                    && (GetServices<IAssessRight>()?.CanUserDo(opUser, MethodBase.GetCurrentMethod().Name) != true))
                {
                    return new BaseOpResult(QueryResultCode.Failed, $"您无权修改该信息，单号：{updateInfo.Flist_id}");
                }

                var trans = session.BeginTransaction();
                try
                {
                    //session.Update(orderInfo);
                    session.Merge(updateInfo);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"更新工作单信息失败，原因：${ex.Message}");
                }
                session.Flush();
            }
            return BaseOpResult.SucceedInstance;
        }



        /// <summary>
        /// 更新整体的业务单信息，约定客户端检查相应的信息有没有更新。
        /// 如果没有那就置null，服务端自动忽略不更新这块信息。（集装箱列表则传有更新的那条就行）
        /// </summary>
        /// <param name="updateInfo"></param>
        /// <returns></returns>
        public BaseOpResult UpdateFreBusinessDTO(FreBussinessOpCenterDTO updateInfo)
        {
            BaseOpResult opResult = BaseOpResult.SucceedInstance;

            var listID = updateInfo.Flist_id;

            if(string.IsNullOrEmpty(listID))
            {
                return new BaseOpResult(QueryResultCode.Failed, $"更新数据工作单号不能为空");
            }

            var opUser = GetRequestContext().LoginInfo.Account;

            using (var session = NHibernateSessionManager.GetSession())
            {
                var trans = session.BeginTransaction();

                try
                {
                    // 检查是否有权限修改数据状态
                    var basicInfo = session.QueryOver<FreBusinessBasicInfoEntity>().Where(x => x.Flist_id == listID).SingleOrDefault();

                    if (null == basicInfo) return new BaseOpResult(QueryResultCode.Failed, $"工作单不存在,单号：{listID}");

                    var bUserHasRight = GetServices<IAssessRight>()?.CanUserDo(opUser, MethodBase.GetCurrentMethod().Name);

                    if (basicInfo.Finputor != opUser && (bUserHasRight != true)) return new BaseOpResult(QueryResultCode.Failed, $"您无权修改该信息，单号：{listID}");

                    if (null != updateInfo.OrderInfo)
                    {
                        var orderDbInfo = session.QueryOver<FreBusinessOrderInfoEntity>().Where(x => x.Flist_id == listID).SingleOrDefault();
                        if (null == orderDbInfo) return new BaseOpResult(QueryResultCode.Failed, $"更新工作单委托信息不存在，更新失败，单号{listID}");
                        session.Merge(updateInfo.OrderInfo);
                    }

                    if (null != updateInfo.HoldGoodsInfo)
                    {
                        var holdDbInfo = session.QueryOver<FreBusinessHoldGoodsInfoEntity>().Where(x => x.Flist_id == listID).SingleOrDefault();
                        if (null == holdDbInfo) return new BaseOpResult(QueryResultCode.Failed, $"更新工作单装货信息不存在，更新失败，单号{listID}");
                        session.Merge(updateInfo.HoldGoodsInfo);
                    }

                    if (null != updateInfo.LayGoodsInfo)
                    {
                        var layDbInfo = session.QueryOver<FreBusinessLayGoodsInfoEntity>().Where(x => x.Flist_id == listID).SingleOrDefault();
                        if (null == layDbInfo) return new BaseOpResult(QueryResultCode.Failed, $"更新工作单卸货信息不存在，更新失败，单号{listID}");
                        session.Merge(updateInfo.LayGoodsInfo);
                    }

                    if (null != updateInfo.AssuranceInfo)
                    {
                        var assuranceDbInfo = session.QueryOver<FreBusinessAssuranceInfoEntity>().Where(x => x.Flist_id == listID).SingleOrDefault();
                        // 保险信息可以为null
                        if (null == assuranceDbInfo) //return new BaseOpResult(QueryResultCode.Failed, $"更新工作单保险信息不存在，更新失败，单号{listID}");
                            session.Save(updateInfo.AssuranceInfo);
                        else
                            session.Merge(updateInfo.AssuranceInfo);
                    }

                    if (null != updateInfo.MatterInfo)
                    {
                        var matterDbInfo = session.QueryOver<FreBusinessMatterInfoEntity>().Where(x => x.Flist_id == listID).SingleOrDefault();
                        // 事项信息可以为null
                        if (null == matterDbInfo) //return new BaseOpResult(QueryResultCode.Failed, $"更新工作单保险信息不存在，更新失败，单号{listID}");
                            session.Save(updateInfo.MatterInfo);
                        else
                            session.Merge(updateInfo.MatterInfo);
                    }

                    if (null != updateInfo.OpInfo)
                    {
                        var opDbInfo = session.QueryOver<FreBusinessOperationInfoEntity>().Where(x => x.Flist_id == listID).SingleOrDefault();
                        // 操作信息可以为null
                        if (null == opDbInfo) //return new BaseOpResult(QueryResultCode.Failed, $"更新工作单保险信息不存在，更新失败，单号{listID}");
                            session.Save(updateInfo.OpInfo);
                        else
                            session.Merge(updateInfo.OpInfo);
                    }

                    if (null != updateInfo.OtherInfo)
                    {
                        var otherInfoInDb = session.QueryOver<FreBusinessOtherInfoEntity>().Where(x => x.Flist_id == listID).SingleOrDefault();
                        // 其他信息可以为null
                        if (null == otherInfoInDb) //return new BaseOpResult(QueryResultCode.Failed, $"更新工作单保险信息不存在，更新失败，单号{listID}");
                            session.Save(updateInfo.OtherInfo);
                        else
                            session.Merge(updateInfo.OtherInfo);
                    }

                    if (null != updateInfo.SeaTransportInfo)
                    {
                        var seaInfoInDb = session.QueryOver<FreBusinessSeaTransportInfoEntity>().Where(x => x.Flist_id == listID).SingleOrDefault();
                        // 其他信息可以为null
                        if (null == seaInfoInDb) //return new BaseOpResult(QueryResultCode.Failed, $"更新工作单保险信息不存在，更新失败，单号{listID}");
                            session.Save(updateInfo.SeaTransportInfo);
                        else
                            session.Merge(updateInfo.SeaTransportInfo);
                    }

                    var containsInfoList = updateInfo.ContainsInfoList;
                    if (!containsInfoList.IsNullOrEmpty())
                    {
                        var containsInfoListInDb = session.QueryOver<FreBusinessContainsInfoEntity>().Where(x => x.Flist_id == listID).List();
                        if(containsInfoListInDb.IsNullOrEmpty())
                        {
                            foreach(var e in containsInfoList)
                            {
                                session.Save(e);
                            }
                        }
                        else
                        {
                            foreach (var eUpdateContainsInfo in containsInfoList)
                            {
                                if(eUpdateContainsInfo.Fid == 0)
                                {
                                    // Fid为0，新增记录
                                    session.Save(eUpdateContainsInfo);
                                    continue;
                                }
                                var isDataFoundInDb = false;
                                foreach(var eContainsInfoInDb in containsInfoListInDb)
                                {
                                    if(eUpdateContainsInfo.Fid == eContainsInfoInDb.Fid)
                                    {
                                        // 已经存在相同的Fid，更新记录
                                        session.Merge(eUpdateContainsInfo);
                                        isDataFoundInDb = true;
                                        break;
                                    }
                                }
                                if(!isDataFoundInDb)
                                {
                                    // 异常情况，Db中不存在这条有ID的记录，但却有更新！
                                    // FIXME：目前采用保存该条记录的方式兼容，待确认！
                                    SLogger.Warn($"货柜信息状态异常,ID={eUpdateContainsInfo.Fid}的数据在DB中不存在，但却请求更新！");
                                    session.Save(eUpdateContainsInfo);
                                }
                            }
                        }
                    }

                    trans.Commit();
                }
                catch(Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"更新工作单信息失败，原因：${ex.Message}");
                }

                session.Flush();
            }

            return opResult;
        }

    }
}
