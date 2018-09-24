using BLL.util;
using Data;
using Data.dal;
using Data.dto;
using Data.entity;
using Data.param;
using Data.utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BLL.query
{
    public class FreBusinessCenterBLL : CommBaseBLL<FreBusinessCenterEntity>
    {
        public override QueryResult<IList<FreBusinessCenterEntity>> GetEntityList(BaseQueryParam param)
        {
            var queryParam = param as QueryFreBusinessCenterParam;

            SAssert.MustTrue((null != queryParam), string.Format("查询参数输入错误，在{0}", MethodBase.GetCurrentMethod().Name));

            var session = NHibernateHelper.getSession();

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
                        query.And(c => c.FbusinessDate >= queryStartDate && c.FbusinessDate <= queryEndDate);
                        break;
                    }
                case DateTypeEnums.HoldGoodsDate:
                    {
                        query.And(c => c.FholdGoodsDate >= queryStartDate && c.FholdGoodsDate <= queryEndDate);
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
                            query.And(c => c.FshipTransNo == queryParam.ListID);
                            break;
                        }
                    case ListIDTypeEnums.CabinetNo:
                        {
                            query.And(c => c.FcabinetNo == queryParam.ListID);
                            break;
                        }
                    case ListIDTypeEnums.WorkNo:
                        {
                            query.And(c => c.FworkOrderNo == queryParam.ListID);
                            break;
                        }
                    case ListIDTypeEnums.ShipNo:
                        {
                            query.And(c => c.FshipMainLineNo == queryParam.ListID);
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
                query.And(c => c.FrecordState == (int)queryParam.State1);
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
