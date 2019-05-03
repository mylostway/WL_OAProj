using System;
using System.Collections.Generic;
using System.Linq;

using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.utils;

using BLL.settings;
using BLL.util;

using NHibernate;
using NHibernate.Criterion;
using WL_OA.Data;

namespace WL_OA.BLL.query
{
    public partial class CustomerManagerBLL : CommBaseBLL<CustomerInfoEntity, QueryCustomerInfoParam>
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public BaseOpResult AddEntity(AddCustomerInfoDTO dto)
        {
            var session = StartTrans();

            try
            {
                // FIX：输入录入人
                dto.InputInfo.Finputor = GetRequestContext().LoginInfo.Name;
                dto.InputInfo.Finput_time = DateTime.Now;

                var customID = session.Save(new CustomerInfoEntity(dto.CustomerInfo));
                dto.Linked(Convert.ToInt32(customID));

                session.AddEntityListEx(dto.CustomerInfo.ContactInfoList);
                session.AddEntityListEx(dto.CustomerInfo.BankAccountInfoList);
                session.AddEntityListEx(dto.CustomerInfo.BookSpaceReceiverInfoList);
                session.AddEntityListEx(dto.CustomerInfo.HoldAddrInfoList);

                session.Save(dto.CreditInfo);
                session.Save(dto.ConfigInfo);
                session.Save(dto.OtherInfo);
                session.Save(dto.InputInfo);

                CommitOnSession(session);
            }
            catch (Exception ex)
            {
                RollBackOnSession(session);
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }

            return BaseOpResult.SucceedInstance;
        }





        /// <summary>
        /// 更新信息，考虑先用delete，再add替代，当然有不完备性，比如add异常，则数据已经被delete掉
        /// </summary>
        /// <param name="entity"></param>
        public virtual BaseOpResult UpdateEntity(AddCustomerInfoDTO dto)
        {
            if (!IsCustomerDTOVaildForUpdate(dto)) return BaseOpResult.FailFor($"参数异常，请检查或刷新数据");

            var reqContxt = GetRequestContext();

            try
            {
                var customerId = dto.CustomerInfo.Fid;

                var toUpdateResult = GetCustomerFullInfo(customerId);

                if (!toUpdateResult.IsSucceed())
                    return BaseOpResult.FailFor($"操作失败，查找要更新数据失败");

                var toUpdateData = toUpdateResult.ResultData;

                // todo： 权限检查
                if (toUpdateData.InputInfo.Finputor != reqContxt.LoginInfo.Name)
                    return BaseOpResult.FailFor($"您不是该客户的录入人，不能修改资料");

                var session = StartTrans();

                try
                {
                    // 比较基本信息是否有差异
                    if (dto.CustomerInfo != toUpdateData.CustomerInfo)
                    {
                        session.Update(new CustomerInfoEntity(dto.CustomerInfo));
                    }

                    dto.CustomerInfo.Linked(toUpdateData.CustomerInfo.Fid);
                    session.UpdateCustomerInfoChildList(dto.CustomerInfo.ContactInfoList, toUpdateData.CustomerInfo.ContactInfoList);
                    session.UpdateCustomerInfoChildList(dto.CustomerInfo.HoldAddrInfoList, toUpdateData.CustomerInfo.HoldAddrInfoList);
                    session.UpdateCustomerInfoChildList(dto.CustomerInfo.BankAccountInfoList, toUpdateData.CustomerInfo.BankAccountInfoList);
                    session.UpdateCustomerInfoChildList(dto.CustomerInfo.BookSpaceReceiverInfoList, toUpdateData.CustomerInfo.BookSpaceReceiverInfoList);

                    /*
                    var toUpdateCi = toUpdateData.CustomerInfo;
                    var dtoCi = dto.CustomerInfo;

                    if (toUpdateCi.ContactInfoList.IsNullOrEmpty())
                    {
                        if (!dtoCi.ContactInfoList.IsNullOrEmpty())
                        {
                            // 原先没有，现在加入，全量添加
                            session.AddEntityListEx(dto.CustomerInfo.ContactInfoList);
                        }
                    }
                    else
                    {
                        if (!dtoCi.ContactInfoList.IsNullOrEmpty())
                        {
                            // 原先有，现在有更新，则遍历检查，并更新
                            for (var i = 0; i < dtoCi.ContactInfoList.Count; i++)
                            {
                                var curData = dtoCi.ContactInfoList[i];
                                if(curData.Fid == 0)
                                {
                                    // 新增数据
                                    session.Save(curData);
                                }
                                else
                                {
                                    // 更新数据
                                    var toUpdateEntity = toUpdateCi.ContactInfoList.SingleOrDefault(x => x.Fid == curData.Fid);
                                    if (null == toUpdateEntity)
                                    {
                                        // 没有找到要更新的数据，目前暂定新增
                                        curData.Fid = 0;
                                        session.Save(curData);
                                    }
                                    else
                                    {
                                        // 找到更新的数据
                                        if(toUpdateEntity != curData)
                                        {
                                            session.Update(curData);
                                        }
                                    }
                                }                                
                            }
                        }
                    }
                    */


                    if (dto.CreditInfo != toUpdateData.CreditInfo)
                    {
                        session.Update(dto.CreditInfo);
                    }

                    if (dto.ConfigInfo != toUpdateData.ConfigInfo)
                    {
                        session.Update(dto.ConfigInfo);
                    }

                    if (dto.OtherInfo != toUpdateData.OtherInfo)
                    {
                        session.Update(dto.OtherInfo);
                    }

                    CommitOnSession(session);
                }
                catch (Exception ex)
                {
                    RollBackOnSession(session);
                    return new BaseOpResult(QueryResultCode.Failed, ex.Message);
                }
            }
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }

            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 删除Entity
        /// </summary>
        /// <param name="entity"></param>
        public override BaseOpResult DelEntity(CustomerInfoEntity entity)
        {
            var relatedID = entity.Fid;
            var session = StartTrans();
            try
            {
                session.Delete(new CustomerContactEntity() { Fcustomer_id = relatedID });
                session.Delete(new CustomerHoldAddrEntity() { Fcustomer_id = relatedID });
                session.Delete(new CustomerBankAccountEntity() { Fcustomer_id = relatedID });
                session.Delete(new CustomerBookSpaceReceiverEntity() { Fcustomer_id = relatedID });
                session.Delete(new CustomerCreditInfoEntity() { Fcustomer_id = relatedID });
                session.Delete(new CustomerConfigInfoEntity() { Fcustomer_id = relatedID });
                session.Delete(new CustomerOtherInfoEntity() { Fcustomer_id = relatedID });
                session.Delete(new CustomerInputInfoEntity() { Fcustomer_id = relatedID });                

                session.Delete(new CustomerInfoEntity() { Fid = relatedID });
            }
            catch (Exception ex)
            {
                RollBackOnSession(session);
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }

            CommitOnSession(session);

            return BaseOpResult.SucceedInstance;
        }



        /// <summary>
        /// 规范的复杂数据更新流程！最小参数依赖原则
        /// </summary>
        /// <param name="updateInfo"></param>
        /// <returns></returns>
        public BaseOpResult UpdateConcatPeopleInfo(CustomerContactEntity updateInfo)
        {
            var session = StartTrans();

            var reqContxt = GetRequestContext();

            try
            {
                var cpQuery = session.QueryOver<CustomerContactEntity>().Where(c => c.Fid == updateInfo.Fid);

                var toUpdateResult = cpQuery.SingleOrDefault();

                if (null == toUpdateResult) return BaseOpResult.FailFor($"操作失败，数据不存在");

                // 没更改，直接返回成功
                if (toUpdateResult == updateInfo) return BaseOpResult.SucceedInstance;

                // 不应该修改的参数，异常排除
                if (updateInfo.Fcustomer_id != toUpdateResult.Fcustomer_id) return BaseOpResult.FailFor("数据有误，请检查或刷新数据");

                var customerInfoQuery = session.QueryOver<CustomerInputInfoEntity>().Where(c => c.Fid == toUpdateResult.Fcustomer_id);

                var queryCustomerInfo = customerInfoQuery.SingleOrDefault();

                if (null == queryCustomerInfo) return BaseOpResult.FailFor($"操作失败，客户信息不存在");

                // todo： 权限检查
                if (queryCustomerInfo.Finputor != reqContxt.LoginInfo.Name) return BaseOpResult.FailFor($"您不是该客户的录入人，不能修改资料");

                session.Update(updateInfo);
            }
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }

            return BaseOpResult.SucceedInstance;
        }
    }
}
