using BLL.util;
using WL_OA;
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
using NHibernate;

namespace WL_OA.BLL
{
    public partial class FreBusinessCenterBLL : CommBaseBLL<FreBusinessCenterEntity, QueryFreBusinessCenterParam>
    {
        public override QueryResult<IList<FreBusinessCenterEntity>> GetEntityList(QueryFreBusinessCenterParam param)
        {
            throw new NotImplementedException("暂不实现");
        }

        public QueryResult<IList<FreBussinessOpCenterDTO>> GetFreBusinessOpCenterList(QueryFreBusinessCenterParam queryParam)
        {
            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var retResult = new QueryResult<IList<FreBussinessOpCenterDTO>>();

            var retList = new List<FreBussinessOpCenterDTO>();

            var session = NHibernateSessionManager.GetSession();

            var queryStartDate = queryParam.StartDate;

            var queryEndDate = queryParam.EndDate;

            QueryHelper.FixDate(ref queryStartDate, ref queryEndDate, 1);

            IList<string> queryWorkIDList = new List<string>();

            IQueryOver<FreBusinessBasicInfoEntity, FreBusinessBasicInfoEntity> basicInfoQuery = session.QueryOver<FreBusinessBasicInfoEntity>();
            IQueryOver<FreBusinessContainsInfoEntity, FreBusinessContainsInfoEntity> containsInfoQuery = null;
            IQueryOver<FreBusinessSeaTransportInfoEntity, FreBusinessSeaTransportInfoEntity> seaInfoQuery = null;

            var queryListID1 = queryParam.ListID;

            if (!string.IsNullOrEmpty(queryParam.ListID))
            {
                switch (queryParam.ListIDType)
                {
                    case ListIDTypeEnums.None:
                    case ListIDTypeEnums.WorkNo:
                        {
                            basicInfoQuery.Where(x => x.Flist_id == queryListID1);
                            break;
                        }
                    case ListIDTypeEnums.CabinetNo:
                        {
                            containsInfoQuery = session.QueryOver<FreBusinessContainsInfoEntity>().Where(x => x.Fcabinet_no == queryListID1);
                            break;
                        }
                    case ListIDTypeEnums.ShipNo:
                        {
                            seaInfoQuery = session.QueryOver<FreBusinessSeaTransportInfoEntity>().Where(x => x.Fship_no == queryListID1);
                            break;
                        }
                    default:
                        {
                            throw new NotImplementedException("暂时不支持这种单号类型的查询");
                        }
                }
            }

            switch (queryParam.DateType)
            {
                // 这几个默认录入日期
                case null:
                case DateTypeEnums.None:
                case DateTypeEnums.InputTime:
                    {
                        basicInfoQuery.WhereIfNotNull(queryStartDate, x => x.Finput_time >= queryStartDate.Value);
                        basicInfoQuery.WhereIfNotNull(queryEndDate, x => x.Finput_time <= queryEndDate.Value);
                        break;
                    }
                case DateTypeEnums.BookedShipStartDate:
                    {
                        if (null == containsInfoQuery) containsInfoQuery = session.QueryOver<FreBusinessContainsInfoEntity>();
                        containsInfoQuery.WhereIfNotNull(queryStartDate, x => x.Fbook_date >= queryStartDate.Value);
                        containsInfoQuery.WhereIfNotNull(queryEndDate, x => x.Fbook_date <= queryEndDate.Value);
                        break;
                    }
                case DateTypeEnums.HoldGoodsDate:
                    {
                        if (null == containsInfoQuery) containsInfoQuery = session.QueryOver<FreBusinessContainsInfoEntity>();
                        containsInfoQuery.WhereIfNotNull(queryStartDate, x => x.Fhold_goods_date >= queryStartDate.Value);
                        containsInfoQuery.WhereIfNotNull(queryEndDate, x => x.Fhold_goods_date <= queryEndDate.Value);
                        break;
                    }
                case DateTypeEnums.WantedReachDate:
                    {
                        if (null == seaInfoQuery) seaInfoQuery = session.QueryOver<FreBusinessSeaTransportInfoEntity>();
                        seaInfoQuery.WhereIfNotNull(queryStartDate, x => x.Fpredit_reach_date >= queryStartDate.Value);
                        seaInfoQuery.WhereIfNotNull(queryEndDate, x => x.Fpredit_reach_date <= queryEndDate.Value);
                        break;
                    }
            }

            if (null != containsInfoQuery)
            {
                queryWorkIDList = containsInfoQuery.Select(x => x.Flist_id).TransformUsing(Transformers.AliasToBean<string>()).List<string>();
            }

            if (null != seaInfoQuery)
            {
                if (!queryWorkIDList.IsNullOrEmpty())
                {
                    seaInfoQuery.Where(x => queryWorkIDList.Contains(x.Flist_id));
                }
                queryWorkIDList = seaInfoQuery.Select(x => x.Flist_id).TransformUsing(Transformers.AliasToBean<string>()).List<string>();
            }

            if (!queryWorkIDList.IsNullOrEmpty())
            {
                basicInfoQuery.Where(x => queryWorkIDList.Contains(x.Flist_id));
            }

            var rawRowCont = basicInfoQuery.RowCount();

            basicInfoQuery = basicInfoQuery.OrderBy(x => x.Finput_time).Desc;

            if (queryParam.IsAllowPagging)
            {
                QueryHelper.FixQueryTake(queryParam, rawRowCont);
                if (null != queryParam.Skip && queryParam.Skip.Value > 0) basicInfoQuery.Skip(queryParam.Skip.Value);
                if (null != queryParam.Take && queryParam.Take.Value > 0) basicInfoQuery.Take(queryParam.Take.Value);
            }

            // 完成交易单基本信息查询
            var queryBasicInfoList = basicInfoQuery.List();

            // 找出交易单列表
            var subQueryList = from eBasicInfo in queryBasicInfoList select eBasicInfo.Flist_id;

            // 组合DTO对象

            // 先批量查询完所有信息集合
            var basicInfoList = session.QueryOver<FreBusinessBasicInfoEntity>().Where(x => subQueryList.Contains(x.Flist_id)).List();
            var orderInfoList = session.QueryOver<FreBusinessOrderInfoEntity>().Where(x => subQueryList.Contains(x.Flist_id)).List();
            var holdGoodsInfoList = session.QueryOver<FreBusinessHoldGoodsInfoEntity>().Where(x => subQueryList.Contains(x.Flist_id)).List();
            var layGoodsInfoList = session.QueryOver<FreBusinessLayGoodsInfoEntity>().Where(x => subQueryList.Contains(x.Flist_id)).List();
            var containInfoList = session.QueryOver<FreBusinessContainsInfoEntity>().Where(x => subQueryList.Contains(x.Flist_id)).List();
            var seaInfoList = session.QueryOver<FreBusinessSeaTransportInfoEntity>().Where(x => subQueryList.Contains(x.Flist_id)).List();
            var assuranceInfoList = session.QueryOver<FreBusinessAssuranceInfoEntity>().Where(x => subQueryList.Contains(x.Flist_id)).List();
            var matterInfoList = session.QueryOver<FreBusinessMatterInfoEntity>().Where(x => subQueryList.Contains(x.Flist_id)).List();
            var opInfoList = session.QueryOver<FreBusinessOperationInfoEntity>().Where(x => subQueryList.Contains(x.Flist_id)).List();
            var otherInfoList = session.QueryOver<FreBusinessOtherInfoEntity>().Where(x => subQueryList.Contains(x.Flist_id)).List();

            // 组合所有结果到DTO
            foreach (var e in basicInfoList)
            {
                var dto = new FreBussinessOpCenterDTO();
                dto.OrderInfo = (from item in orderInfoList where item.Flist_id == e.Flist_id select item).FirstOrDefault();
                dto.HoldGoodsInfo = (from item in holdGoodsInfoList where item.Flist_id == e.Flist_id select item).FirstOrDefault();
                dto.LayGoodsInfo = (from item in layGoodsInfoList where item.Flist_id == e.Flist_id select item).FirstOrDefault();
                dto.ContainsInfoList = (from item in containInfoList where item.Flist_id == e.Flist_id select item).ToList();
                dto.SeaTransportInfo = (from item in seaInfoList where item.Flist_id == e.Flist_id select item).FirstOrDefault();
                dto.AssuranceInfo = (from item in assuranceInfoList where item.Flist_id == e.Flist_id select item).FirstOrDefault();
                dto.MatterInfo = (from item in matterInfoList where item.Flist_id == e.Flist_id select item).FirstOrDefault();
                dto.OpInfo = (from item in opInfoList where item.Flist_id == e.Flist_id select item).FirstOrDefault();
                dto.OtherInfo = (from item in otherInfoList where item.Flist_id == e.Flist_id select item).FirstOrDefault();

                retList.Add(dto);
            }

            retResult.ResultCount = rawRowCont;


            retResult.ResultData = retList;

            return retResult;
        }
    }
}
