using BLL.util;
using WL_OA.Data;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WL_OA.BLL.query
{
    public class FreBusinessCenterBLL : CommBaseBLL<FreBusinessCenterEntity,QueryFreBusinessCenterParam>
    {
        public override QueryResult<IList<FreBusinessCenterEntity>> GetEntityList(QueryFreBusinessCenterParam param)
        {
            var queryParam = param as QueryFreBusinessCenterParam;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<FreBusinessCenterEntity>();

            var queryStartDate = queryParam.StartDate;

            var queryEndDate = queryParam.EndDate;

            QueryHelper.FixDate(ref queryStartDate, ref queryEndDate, 1);

            switch(queryParam.DateType)
            {
                case null:
                case DateTypeEnums.None:
                case DateTypeEnums.BusinessDate:
                    {
                        query.And(c => c.Fbusiness_date >= queryStartDate && c.Fbusiness_date <= queryEndDate);
                        break;
                    }
                case DateTypeEnums.HoldGoodsDate:
                    {
                        query.And(c => c.Fhold_goods_date >= queryStartDate && c.Fhold_goods_date <= queryEndDate);
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("暂时不支持这种日期类型的查询");
                    }
            }

            if (!string.IsNullOrEmpty(queryParam.ListID))
            {
                switch (queryParam.ListIDType)
                {
                    case ListIDTypeEnums.None:
                        {
                            query.And(c => c.Fship_trans_no == queryParam.ListID);
                            break;
                        }
                    case ListIDTypeEnums.CabinetNo:
                        {
                            query.And(c => c.Fcabinet_no == queryParam.ListID);
                            break;
                        }
                    case ListIDTypeEnums.WorkNo:
                        {
                            query.And(c => c.Fwork_order_no == queryParam.ListID);
                            break;
                        }
                    case ListIDTypeEnums.ShipNo:
                        {
                            query.And(c => c.Fship_main_line_no == queryParam.ListID);
                            break;
                        }
                    default:
                        {
                            throw new NotImplementedException("暂时不支持这种单号类型的查询");
                        }
                }                
            }

            if(queryParam.State1 != StateEnums.None)
            {                
                query.And(c => c.Frecord_state == (int)queryParam.State1);
            }
            
            int rawRowCont = query.RowCount();

            QueryHelper.FixQueryTake(param, rawRowCont);

            if (null != param.Skip && param.Skip.Value > 0) query.Skip(param.Skip.Value);
            if (null != param.Take && param.Take.Value > 0) query.Take(param.Take.Value);

            var retList = query.List();

            return new QueryResult<IList<FreBusinessCenterEntity>>(retList, rawRowCont, retList.Count);
        }

    }
}
