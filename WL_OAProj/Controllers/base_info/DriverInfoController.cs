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
        [Route("baseInfo/driverInfo/get")]
        public QueryResult<IList<DriverinfoEntity>> QueryDriverInfoList([FromBody] QueryDriverInfoParams param)
        {
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("baseInfo/driverInfo/add")]
        public BaseOpResult AddDriverInfo([FromBody] DriverinfoEntity entity)
        {
            return BLL().AddEntity(entity);
        }


        [HttpPost]
        [Route("baseInfo/driverInfo/update")]
        public BaseOpResult UpdateDriverInfo([FromBody] DriverinfoEntity entity)
        {
            return BLL().UpdateEntity(entity);
        }


        [HttpGet]
        [Route("baseInfo/driverInfo/del/{entityID}")]
        public BaseOpResult DelDriverInfo(int entityID)
        {
            return BLL().DelEntity(entityID);
        }
    }
}