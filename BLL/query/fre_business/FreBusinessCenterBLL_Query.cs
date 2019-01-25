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

            IQueryOver<FreBusinessBasicInfoEntity> basicInfoQuery = null;
            IQueryOver<FreBusinessContainsInfoEntity> containsInfoQuery = null;
            IQueryOver<FreBusinessSeaTransportInfoEntity> seaInfoQuery = null;

            var queryListID1 = queryParam.ListID;

            if (!string.IsNullOrEmpty(queryParam.ListID))
            {
                switch (queryParam.ListIDType)
                {
                    case ListIDTypeEnums.None:
                    case ListIDTypeEnums.WorkNo:
                        {
                            basicInfoQuery = session.QueryOver<FreBusinessBasicInfoEntity>().Where(x => x.Flist_id == queryListID1);

                            var queryBasicInfo = query.SingleOrDefault();
                            // 查询本身工作单号，没有数据，则认为已经不可能存在该单，直接返回空结果
                            if (null == queryBasicInfo) return retResult;
                            queryWorkIDList.Add(queryBasicInfo.Flist_id);
                            break;
                        }
                    case ListIDTypeEnums.CabinetNo:
                        {
                            var query = session.QueryOver<FreBusinessContainsInfoEntity>().Where(x => x.Fcabinet_no == queryListID1);
                            switch (queryParam.DateType)
                            {
                                // 这几个默认起始订舱日期
                                case null:
                                case DateTypeEnums.None:
                                case DateTypeEnums.BookedShipStartDate:
                                    {
                                        query.WhereifNotNull(queryStartDate, x => x.Fbook_date >= queryStartDate.Value);
                                        query.WhereifNotNull(queryEndDate, x => x.Fbook_date <= queryEndDate.Value);
                                        break;
                                    }
                                case DateTypeEnums.HoldGoodsDate:
                                    {
                                        // 装货日期
                                        query.WhereifNotNull(queryStartDate, x => x.Fhold_goods_date >= queryStartDate.Value);
                                        query.WhereifNotNull(queryEndDate, x => x.Fhold_goods_date <= queryEndDate.Value);
                                        break;
                                    }
                            }
                            // FIXME:这里只需返回listID即可，待确认是否正确
                            queryWorkIDList = query.Select(x => x.Flist_id).TransformUsing(Transformers.AliasToBean<string>()).List<string>();
                            // 查询柜号，没有关联工作单数据，直接返回空结果
                            if (queryWorkIDList.IsNullOrEmpty()) return retResult;
                            break;
                        }
                    case ListIDTypeEnums.ShipNo:
                        {
                            var query = session.QueryOver<FreBusinessSeaTransportInfoEntity>().Where(x => x.Fship_no == queryListID1);
                            switch (queryParam.DateType)
                            {
                                // 这几个默认预计到达船期
                                case null:
                                case DateTypeEnums.None:
                                case DateTypeEnums.WantedReachDate:
                                    {
                                        query.WhereifNotNull(queryStartDate, x => x.Fpredit_reach_date >= queryStartDate.Value);
                                        query.WhereifNotNull(queryEndDate, x => x.Fpredit_reach_date <= queryEndDate.Value);
                                        break;
                                    }
                            }
                            // FIXME:这里只需返回listID即可，待确认是否正确
                            queryWorkIDList = query.Select(x => x.Flist_id).TransformUsing(Transformers.AliasToBean<string>()).List<string>();
                            // 查询运单号，没有关联工作单数据，直接返回空结果
                            if (queryWorkIDList.IsNullOrEmpty()) return retResult;
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
                        basicInfoQuery.WhereifNotNull(queryStartDate, x => x.Finput_time >= queryStartDate.Value);
                        basicInfoQuery.WhereifNotNull(queryEndDate, x => x.Finput_time <= queryEndDate.Value);
                        break;
                    }
            }

            if (queryWorkIDList.IsNullOrEmpty())
            {
                return retResult;
            }

            if (queryWorkIDList.Count == 1)
            {
                retResult.ResultCount = 1;
                retList.Add(GetDetail(queryWorkIDList[0]));
            }
            else
            {
                var rawRowCont = queryWorkIDList.Count;
                var subQueryList = queryWorkIDList;
                // 这里先假设每个能查出单号的记录都必须存在，否则会很复杂。。。。
                if (queryParam.IsAllowPagging)
                {
                    QueryHelper.FixQueryTake(queryParam, rawRowCont);

                    var startIdx = (null == queryParam.Skip) ? 0 : queryParam.Skip.Value;
                    var endIdx = queryParam.Take.Value;
                    subQueryList = queryWorkIDList.Sub(startIdx, endIdx);
                }

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
            }

            retResult.ResultData = retList;

            return retResult;
        }
    }
}
