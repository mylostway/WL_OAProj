using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WL_OA.BLL.query;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WL_OAProj
{
    [Route("api/Datas")]
    public class DatasController : Controller
    {

        [HttpGet("QueryWharfInfoList")]
        public QueryResult<IList<WharfinfoEntity>> QueryWharfInfoList([FromQuery] QueryWharfInfoParam param)
        {
            var bll = new WharfInfoBLL();
            return bll.GetEntityList(param);
        }

        [HttpPost("AddWharfInfo")]
        public BaseOpResult AddWharfInfo([FromBody] WharfinfoEntity entity)
        {
            var bll = new WharfInfoBLL();
            return bll.AddEntity(entity);
        }


        [HttpPost("DelWharfInfo")]
        public BaseOpResult DelWharfInfo([FromBody] int entityID)
        {
            var bll = new WharfInfoBLL();
            return bll.DelEntity(entityID);
        }
    }
}
