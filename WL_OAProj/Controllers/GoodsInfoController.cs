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
    //[Route("api")]
    public class GoodsInfoController : Controller
    {
        [HttpGet]
        [Route("api/QueryGoodsInfoList")]
        public QueryResult<IList<GoodsinfoEntity>> QueryGoodsInfoList(QueryGoodsInfoParam param)
        {
            var bll = new GoodsInfoBLL();
            return bll.GetEntityList(param);
        }


        //[HttpPost("AddGoodsInfo")]
        [HttpGet]
        [Route("api/AddGoodsInfo")]
        public BaseOpResult AddGoodsInfo(GoodsinfoEntity entity)
        {
            var bll = new GoodsInfoBLL();
            return bll.AddEntity(entity);
        }

        [HttpGet]
        [Route("api/DelGoodsInfo/{entityID}")]
        public BaseOpResult DelGoodsInfo(int entityID)
        {
            var bll = new GoodsInfoBLL();
            return bll.DelEntity(entityID);
        }
    }
}