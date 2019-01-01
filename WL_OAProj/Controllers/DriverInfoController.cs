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
    //[Route("api/DriverInfo")]
    public class DriverInfoController : BaseController<DriverInfoBLL>
    {
        [HttpPost]
        [Route("api/QueryDriverInfoList")]
        public QueryResult<IList<DriverinfoEntity>> QueryDriverInfoList(QueryDriverInfoParams param)
        {
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("api/AddDriverInfo")]
        public BaseOpResult AddDriverInfo([FromBody] DriverinfoEntity entity)
        {
            return BLL().AddEntity(entity);
        }


        [HttpPost]
        [Route("api/UpdateDriverInfo")]
        public BaseOpResult UpdateDriverInfo([FromBody] DriverinfoEntity entity)
        {
            return BLL().UpdateEntity(entity);
        }


        [HttpGet]
        [Route("api/DelDriverInfo/{entityID}")]
        public BaseOpResult DelDriverInfo(int entityID)
        {
            return BLL().DelEntity(entityID);
        }
    }
}