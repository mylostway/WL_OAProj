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
    public class GoodsInfoController : BaseController<GoodsInfoBLL>
    {
        [HttpPost]
        [Route("api/QueryGoodsInfoList")]
        public QueryResult<IList<GoodsinfoEntity>> QueryGoodsInfoList(QueryGoodsInfoParam param)
        {            
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("api/AddGoodsInfo")]
        public BaseOpResult AddGoodsInfo([FromBody] GoodsinfoEntity entity)
        {            
            return BLL().AddEntity(entity);
        }

        [HttpPost]
        [Route("api/DelGoodsInfo/{entityID}")]
        public BaseOpResult DelGoodsInfo(int entityID)
        {            
            return BLL().DelEntity(entityID);
        }


        [HttpPost]
        [Route("api/UpdateGoodsInfo")]
        public BaseOpResult UpdateGoodsInfo([FromBody] GoodsinfoEntity entity)
        {            
            return BLL().UpdateEntity(entity);
        }
    }
}