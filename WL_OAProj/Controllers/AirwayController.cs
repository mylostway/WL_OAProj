using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WL_OA.BLL.query;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dto;

namespace WL_OAProj.Controllers
{
    [Produces("application/json")]
    public class AirwayController : BaseController<AirLineInfoBLL>
    {
        [HttpPost]
        [Route("api/QueryAirwayInfoList")]
        public QueryResult<IList<AirwayEntity>> QueryAirwayInfoList(QueryAirLineInfoParam param)
        {
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("api/AddAirwayInfo")]
        public BaseOpResult AddAirwayInfo(AirwayEntity entity)
        {
            return BLL().AddEntity(entity);
        }

        [HttpGet]
        [Route("api/DelAirwayInfo/{entityID}")]
        public BaseOpResult DelAirwayInfo(int entityID)
        {
            return BLL().DelEntity(entityID);
        }


        [HttpPost]
        [Route("api/UpdateAirwayInfo")]
        public BaseOpResult UpdateAirwayInfo(AirwayEntity entity)
        {
            return BLL().UpdateEntity(entity);
        }
    }
}
