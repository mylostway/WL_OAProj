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
        [Route("baseInfo/goodNames/get")]
        public QueryResult<IList<GoodsinfoEntity>> QueryGoodsInfoList([FromBody] QueryGoodsInfoParam param)
        {            
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("baseInfo/goodNames/add")]
        public BaseOpResult AddGoodsInfo([FromBody] GoodsinfoEntity entity)
        {            
            return BLL().AddEntity(entity);
        }

        [HttpGet]
        [Route("baseInfo/goodNames/del/{entityID}")]
        public BaseOpResult DelGoodsInfo(int entityID)
        {            
            return BLL().DelEntity(entityID);
        }


        [HttpPost]
        [Route("baseInfo/goodNames/update")]
        public BaseOpResult UpdateGoodsInfo([FromBody] GoodsinfoEntity entity)
        {            
            return BLL().UpdateEntity(entity);
        }


        [HttpGet]
        [Route("baseInfo/goodNames/getAll")]
        public QueryResult<IList<GoodsInfoForSelData>> GetAllGoodsInfo()
        {
            var getList = BLL().GetAllGoodsInfo();
            var retList = GoodsInfoForSelData.ConvFrom(getList);
            return new QueryResult<IList<GoodsInfoForSelData>>(retList, retList.Count, retList.Count);
        }
    }
}