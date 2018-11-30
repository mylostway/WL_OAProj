using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.BLL.query
{
    public class BookShipManagerBLL : CommBaseBLL<ShipBookManagerEntity, BaseQueryParam>
    {
        public override QueryResult<IList<ShipBookManagerEntity>> GetEntityList(BaseQueryParam param)
        {
            throw new NotImplementedException();
        }
    }
}
