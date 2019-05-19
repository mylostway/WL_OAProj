using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WL_OA.BLL.query;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OAProj.Controllers.base_info
{

    [Produces("application/json")]
    public class FeeProjectController : BaseController<FeeProjectBLL>
    {
        [HttpPost]
        [Route("api/feeProject/get")]
        public QueryResult<IList<FeeProjectEntity>> Get([FromBody] QueryFeeProjectParam param)
        {
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("api/feeProject/add")]
        public BaseOpResult Add([FromBody] FeeProjectEntity entity)
        {
            entity.Finputor = RequestContext.LoginInfo.Name;
            entity.Finput_date = DateTime.Now;
            return BLL().AddEntity(entity);
        }

        [HttpGet]
        [Route("api/feeProject/del/{entityID}")]
        public BaseOpResult Delete(int entityID)
        {
            return BLL().DelEntity(entityID);
        }


        [HttpPost]
        [Route("api/feeProject/update")]
        public BaseOpResult Update([FromBody] FeeProjectEntity entity)
        {
            return BLL().UpdateEntity(entity);
        }



    }
}
