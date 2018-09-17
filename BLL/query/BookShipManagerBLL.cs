using Data.dto;
using Data.entity;
using Data.param;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.query
{
    public class BookShipManagerBLL : CommBaseBLL<ShipBookManagerEntity>
    {
        public override QueryResult<IList<ShipBookManagerEntity>> GetEntityList(BaseQueryParam param)
        {
            throw new NotImplementedException();
        }
    }
}
