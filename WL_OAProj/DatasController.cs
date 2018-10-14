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
        [HttpPost("QueryDriverInfoList")]       
        public QueryResult<IList<DriverinfoEntity>> QueryDriverInfoList([FromBody] QueryDriverInfoParams param)
        {
            var bll = new DriverInfoBLL();
            return bll.GetEntityList(param);
        }


        [HttpPost("AddDriverInfo")]
        public BaseOpResult AddDriverInfo([FromBody] DriverinfoEntity entity)
        {
            var bll = new DriverInfoBLL();
            return bll.AddEntity(entity);
        }


        [HttpPost("DelDriverInfo")]
        public BaseOpResult DelDriverInfo([FromBody] int entityID)
        {
            var bll = new DriverInfoBLL();
            return bll.DelEntity(entityID);
        }


        [HttpGet("QueryGoodsInfoList")]
        public QueryResult<IList<GoodsinfoEntity>> QueryGoodsInfoList([FromQuery] QueryGoodsInfoParam param)
        {
            var bll = new GoodsInfoBLL();
            return bll.GetEntityList(param);
        }


        [HttpGet("QueryWharfInfoList")]
        public QueryResult<IList<WharfinfoEntity>> QueryWharfInfoList([FromQuery] QueryWharfInfoParam param)
        {
            var bll = new WharfInfoBLL();
            return bll.GetEntityList(param);
        }
        
    }
}
