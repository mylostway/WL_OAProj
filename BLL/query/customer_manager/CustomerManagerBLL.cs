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
using System.Linq;

namespace WL_OA.BLL.query
{
    public partial class CustomerManagerBLL : CommBaseBLL<CustomerInfoEntity, QueryCustomerInfoParam>
    {
        public QueryResult<AddCustomerInfoDTO> GetCustomerFullInfo(int customerId)
        {
            return GetCustomerFullInfo(new QueryCustomerFullInfoParam(customerId));
        }

        /// <summary>
        /// 获取客户完整信息
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public QueryResult<AddCustomerInfoDTO> GetCustomerFullInfo(QueryCustomerFullInfoParam queryParam)
        {
            var session = NHibernateSessionManager.GetSession();

            var customerID = queryParam.CustomerID;
            var skipNum = queryParam.ChildInfoListSkip;
            var takeNum = queryParam.ChildInfoListTake;
            var queryEntity = session.Get<CustomerInfoEntity>(customerID);
            if(null == queryEntity)
            {
                return new QueryResult<AddCustomerInfoDTO>(QueryResultCode.Failed, $"客户不存在");
            }
            var contactInfoQuery = session.QueryOver<CustomerContactEntity>().Where(c => c.Fcustomer_id == customerID);
            var holdAddrQuery = session.QueryOver<CustomerHoldAddrEntity>().Where(c => c.Fcustomer_id == customerID);
            var bankAccountQuery = session.QueryOver<CustomerBankAccountEntity>().Where(c => c.Fcustomer_id == customerID);
            var bookSpaceReceiverQuery = session.QueryOver<CustomerBookSpaceReceiverEntity>().Where(c => c.Fcustomer_id == customerID);

            var creditInfoQuery = session.QueryOver<CustomerCreditInfoEntity>().Where(c => c.Fcustomer_id == customerID);
            var configInfoQuery = session.QueryOver<CustomerConfigInfoEntity>().Where(c => c.Fcustomer_id == customerID);
            var otherInfoQuery = session.QueryOver<CustomerOtherInfoEntity>().Where(c => c.Fcustomer_id == customerID);
            var inputInfoQuery = session.QueryOver<CustomerInputInfoEntity>().Where(c => c.Fcustomer_id == customerID);

            var retResult = new QueryResult<AddCustomerInfoDTO>(new AddCustomerInfoDTO()
            {
                // 这里没对数据进行校验，应该是每个客户信息只有一个下面信息记录的（目前DB没有进行限制）
                CustomerInfo = new CustomerSummaryInfoDTO(queryEntity),
                CreditInfo = creditInfoQuery.SingleOrDefault(),
                ConfigInfo = configInfoQuery.SingleOrDefault(),
                OtherInfo = otherInfoQuery.SingleOrDefault(),
                InputInfo = inputInfoQuery.SingleOrDefault()
            });

            // 目前采取一次性查询完整数据返回的形式实现。
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

            IQueryOver<CustomerInputInfoEntity, CustomerInputInfoEntity> queryInputInfo = null;

            var queryStartDate = queryParam.StartDate;

            var queryEndDate = queryParam.EndDate;

            QueryHelper.FixDate(ref queryStartDate, ref queryEndDate, -1);

            switch (queryParam.DateType)
            {
                case null:
                case DateTypeEnums.None:
                case DateTypeEnums.InputTime:
                    {
                        queryInputInfo = session.QueryOver<CustomerInputInfoEntity>().Where(c => c.Finput_time >= queryStartDate && c.Finput_time <= queryEndDate);                        
                        break;
                    }
                case DateTypeEnums.AduitTime:
                    {
                        queryInputInfo = session.QueryOver<CustomerInputInfoEntity>().Where(c => c.Faduit_time >= queryStartDate && c.Faduit_time <= queryEndDate);
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("暂时不支持这种日期类型的查询");
                    }
            }

            if (null != queryInputInfo)
            {
                var inputInfoEntityList = queryInputInfo.Select(x => x.Fcustomer_id).List<int>();
                if (inputInfoEntityList.IsNullOrEmpty()) return new QueryResult<IList<CustomerInfoEntity>>();
                query.And(Restrictions.In("Fid", inputInfoEntityList.ToArray()));
            }

            AddQueryIDTypeCondition(queryParam.IDType1, queryParam.ID1, query);
            AddQueryIDTypeCondition(queryParam.IDType2, queryParam.ID2, query);

            AddQueryDataStateCondition(queryParam.StateType, query);

            int rawRowCont = query.RowCount();

            //QueryHelper.FixQueryTake(param, rawRowCont);            

            var pageIdx = param.GetFixedQueryPageIndex();
            var pageSize = param.GetFixedQueryPageSize();

            query.OrderBy((x) => x.Fid).Desc();

            //if (null != param.Skip && param.Skip.Value > 0) query.Skip(param.Skip.Value);
            //if (null != param.Take && param.Take.Value > 0) query.Take(param.Take.Value);
            if(pageIdx > 1)
            {
                query.Skip((pageIdx - 1) * pageSize);
            }
            query.Take(pageSize);

            var retList = query.List();
            return new QueryResult<IList<CustomerInfoEntity>>(retList, rawRowCont, retList.Count);
        }
    }
}
