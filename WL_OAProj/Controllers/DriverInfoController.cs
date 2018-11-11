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
    public class DriverInfoController : Controller
    {
        [HttpPost]
        [Route("api/QueryDriverInfoList")]
        public QueryResult<IList<DriverinfoEntity>> QueryDriverInfoList([FromQuery] QueryDriverInfoParams param)
        {
            var bll = new DriverInfoBLL();
            return bll.GetEntityList(param);
        }


        [HttpPost]
        [Route("api/AddDriverInfo")]
        public BaseOpResult AddDriverInfo([FromBody] DriverinfoEntity entity)
        {
            var bll = new DriverInfoBLL();
            return bll.AddEntity(entity);
        }


        [HttpPost]
        [Route("api/UpdateDriverInfo")]
        public BaseOpResult UpdateDriverInfo([FromBody] DriverinfoEntity entity)
        {
            var bll = new DriverInfoBLL();
            return bll.UpdateEntity(entity);
        }


        [HttpGet]
        [Route("api/DelDriverInfo/{entityID}")]
        public BaseOpResult DelDriverInfo(int entityID)
        {
            var bll = new DriverInfoBLL();
            return bll.DelEntity(entityID);
        }
    }
}