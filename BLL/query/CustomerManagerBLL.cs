using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

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
        /// 获取客户完整信息
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public QueryResult<CustomerInfoDTO> GetCustomerFullInfo(int customerID)
        {
            var session = NHibernateSessionManager.GetSession();

            var queryEntity = session.Get<CustomerInfoEntity>(customerID);
            var contactInfoQuery = session.QueryOver<CustomerContactEntity>().Where(c => c.FcustomerId == customerID).Take(1);
            var holdAddrQuery = session.QueryOver<CustomerHoldAddrEntity>().Where(c => c.FcustomerId == customerID).Take(1);
            var bankAccountQuery = session.QueryOver<CustomerBankAccountEntity>().Where(c => c.FcustomerId == customerID).Take(1);
            var bookSpaceReceiverQuery = session.QueryOver<CustomerBookSpaceReceiverEntity>().Where(c => c.FcustomerId == customerID).Take(1);
            var creditInfoQuery = session.QueryOver<CustomerCreditInfoEntity>().Where(c => c.FcustomerId == customerID).Take(1);
            var configInfoQuery = session.QueryOver<CustomerConfigInfoEntity>().Where(c => c.FcustomerId == customerID).Take(1);
            var otherInfoQuery = session.QueryOver<CustomerOtherInfoEntity>().Where(c => c.FcustomerId == customerID).Take(1);

            var retResult = new QueryResult<CustomerInfoDTO>(new CustomerInfoDTO()
            {
                CustomerInfo = new CustomerSummaryInfoDTO(queryEntity),
                CreditInfo = creditInfoQuery.SingleOrDefault(),
                ConfigInfo = configInfoQuery.SingleOrDefault(),
                OtherInfo = otherInfoQuery.SingleOrDefault()
            });

            retResult.ResultData.CustomerInfo.ContactInfoList = contactInfoQuery.List();
            retResult.ResultData.CustomerInfo.HoldAddrInfoList = holdAddrQuery.List();
            retResult.ResultData.CustomerInfo.BankAccountInfoList = bankAccountQuery.List();
            retResult.ResultData.CustomerInfo.BookSpaceReceiverInfoList = bookSpaceReceiverQuery.List();

            return retResult;
        }


        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override QueryResult<IList<CustomerInfoEntity>> GetEntityList(QueryCustomerInfoParam param)
        {
            var queryParam = param;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<CustomerInfoEntity>();

            var queryStartDate = queryParam.StartDate;

            var queryEndDate = queryParam.EndDate;

            QueryHelper.FixDate(ref queryStartDate, ref queryEndDate, -1);

            switch (queryParam.DateType)
            {
                case null:
                case DateTypeEnums.None:
                case DateTypeEnums.InputTime:
                    {
                        query.And(c => c.FinputTime >= queryStartDate && c.FinputTime <= queryEndDate);
                        break;
                    }
                case DateTypeEnums.AduitTime:
                    {
                        query.And(c => c.FaduitTime >= queryStartDate && c.FaduitTime <= queryEndDate);
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("暂时不支持这种日期类型的查询");
                    }
            }

            AddQueryIDTypeCondition(queryParam.IDType1, queryParam.ID1, query);
            AddQueryIDTypeCondition(queryParam.IDType2, queryParam.ID2, query);

            AddQueryDataStateCondition(queryParam.StateType, query);

            int rawRowCont = query.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query.Take(param.Take.Value);

            var retList = query.List();

            return new QueryResult<IList<CustomerInfoEntity>>(retList, rawRowCont, retList.Count);
        }


        /// <summary>
        /// 根据复杂的IDType，添加ID的查询条件，因为允许两个查询条件，所以提取出来当方法
        /// </summary>
        /// <param name="enumVal"></param>
        /// <param name="val"></param>
        /// <param name="query"></param>
        private void AddQueryIDTypeCondition(QueryCustomerInfoIDTypeEnums? enumVal, string val,IQueryOver<CustomerInfoEntity, CustomerInfoEntity> query)
        {
            if (!string.IsNullOrEmpty(val))
            {
                switch (enumVal)
                {
                    case null:
                    case QueryCustomerInfoIDTypeEnums.None:
                    case QueryCustomerInfoIDTypeEnums.Forshot:
                        {
                            query.Where(c => c.FnameForShort.Contains(val));
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.FullName:
                        {
                            query.Where(c => c.Fname.Contains(val));
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.Remark:
                        {
                            query.Where(c => c.Fmark.Contains(val));
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.CustomType:
                        {
                            query.Where(c => c.FcustomerType == val);
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.Payway:
                        {
                            query.Where(c => c.FpayWay == val.ToEnumVal(typeof(PaywayEnums)));                            
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.BusinessMan:
                        {
                            query.Where(c => c.Fbusinesser.Contains(val));
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.Province:
                        {
                            // 这个要关联查询
                            throw new NotImplementedException();
                        }
                }
            }
        }

        /// <summary>
        /// 根据数据状态值添加查询条件
        /// </summary>
        /// <param name="enumVal"></param>
        /// <param name="query"></param>
        private void AddQueryDataStateCondition(QueryCustomerInfoStateEnums? enumVal, IQueryOver<CustomerInfoEntity, CustomerInfoEntity> query)
        {
            if (enumVal == null || enumVal == QueryCustomerInfoStateEnums.None) return;

            switch(enumVal)
            {
                case QueryCustomerInfoStateEnums.Useless:
                    {
                        query.Where(c => ((c.FdataStatus & 0x01) == 0));
                        break;
                    }
                case QueryCustomerInfoStateEnums.Usable:
                    {
                        query.Where(c => ((c.FdataStatus & 0x01) == 1));
                        break;
                    }
                case QueryCustomerInfoStateEnums.Aduited:
                    {
                        query.Where(c => ((c.FdataStatus & 0x02) == 1));
                        break;
                    }
                case QueryCustomerInfoStateEnums.UnAduited:
                    {
                        query.Where(c => ((c.FdataStatus & 0x02) == 0));
                        break;
                    }
                case QueryCustomerInfoStateEnums.Shared:
                    {
                        query.Where(c => ((c.FdataStatus & 0x04) == 1));
                        break;
                    }
                case QueryCustomerInfoStateEnums.UnShared:
                    {
                        query.Where(c => ((c.FdataStatus & 0x04) == 0));
                        break;
                    }
                case QueryCustomerInfoStateEnums.BlackList:
                    {
                        query.Where(c => ((c.FdataStatus & 0x08) == 1));
                        break;
                    }
                case QueryCustomerInfoStateEnums.NotBlackList:
                    {
                        query.Where(c => ((c.FdataStatus & 0x08) == 0));
                        break;
                    }
                case QueryCustomerInfoStateEnums.ReceivedShortmsg:
                    {
                        query.Where(c => ((c.FdataStatus & 0x10) == 1));
                        break;
                    }
                case QueryCustomerInfoStateEnums.NotReceivedShortmsg:
                    {
                        query.Where(c => ((c.FdataStatus & 0x10) == 0));
                        break;
                    }
            }
        }


        public BaseOpResult AddEntity(CustomerInfoDTO dto)
        {
            var session = StartTrans();

            try
            {
                // FIX：输入录入人
                //dto.CustomerInfo.Finputor = "";
                dto.CustomerInfo.FinputTime = DateTime.Now;

                var customID = session.Save(dto.CustomerInfo);
                dto.Linked(dto.CustomerInfo.Fid);

                //session.AddEntityListEx(dto.CustomerInfo.ContactInfoList);
                //session.AddEntityListEx(dto.CustomerInfo.BankAccountInfoList);
                //session.AddEntityListEx(dto.CustomerInfo.BookSpaceReceiverInfoList);
                //session.AddEntityListEx(dto.CustomerInfo.HoldAddrInfoList);

                AddEntityList(session, dto.CustomerInfo.ContactInfoList);
                AddEntityList(session, dto.CustomerInfo.BankAccountInfoList);
                AddEntityList(session, dto.CustomerInfo.BookSpaceReceiverInfoList);
                AddEntityList(session, dto.CustomerInfo.HoldAddrInfoList);

                session.Save(dto.CreditInfo);
                session.Save(dto.ConfigInfo);
                session.Save(dto.OtherInfo);
            }
            catch(Exception ex)
            {
                RollBackOnSession(session);
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }

            CommitOnSession(session);

            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 更新信息，考虑先用delete，再add替代，当然有不完备性，比如add异常，则数据已经被delete掉
        /// </summary>
        /// <param name="entity"></param>
        public virtual BaseOpResult UpdateEntity(CustomerInfoDTO dto)
        {
            try
            {
                DelEntity(dto.CustomerInfo);

                AddEntity(dto);
            }
            catch(Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }

            return BaseOpResult.SucceedInstance;

            /*
            var session = NHibernateHelper.getSession();
            var trans = session.BeginTransaction();
            session.Update(entity);
            trans.Commit();
            */
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
                session.Delete(new CustomerContactEntity() { FcustomerId = relatedID });
                session.Delete(new CustomerHoldAddrEntity() { FcustomerId = relatedID });
                session.Delete(new CustomerBankAccountEntity() { FcustomerId = relatedID });
                session.Delete(new CustomerBookSpaceReceiverEntity() { FcustomerId = relatedID });
                session.Delete(new CustomerCreditInfoEntity() { FcustomerId = relatedID });
                session.Delete(new CustomerConfigInfoEntity() { FcustomerId = relatedID });
                session.Delete(new CustomerOtherInfoEntity() { FcustomerId = relatedID });

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

    }
}
