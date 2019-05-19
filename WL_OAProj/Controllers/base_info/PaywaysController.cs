using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WL_OA.BLL.query;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OAProj.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    public class PaywaysController : BaseController<PaywayInfoBLL>
    {
        [HttpPost]
        [Route("api/payWays/get")]
        public QueryResult<IList<PayWaysEntity>> QueryGoodsInfoList([FromBody] QueryPaywaysParam param)
        {
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("api/payWays/add")]
        public BaseOpResult AddGoodsInfo([FromBody] PayWaysEntity entity)
        {
            return BLL().AddEntity(entity);
        }

        [HttpGet]
        [Route("api/payWays/del/{entityID}")]
        public BaseOpResult DelGoodsInfo(int entityID)
        {
            return BLL().DelEntity(entityID);
        }


        [HttpPost]
        [Route("api/payWays/update")]
        public BaseOpResult UpdateGoodsInfo([FromBody] PayWaysEntity entity)
        {
            return BLL().UpdateEntity(entity);
        }


        [HttpGet]
        [Route("api/payWays/getAll")]
        public QueryResult<IList<PayWaysEntity>> GetAllGoodsInfo()
        {
            var retList = BLL().GetAllPayways();
            return new QueryResult<IList<PayWaysEntity>>(retList, retList.Count, retList.Count);
        }
    }
}
