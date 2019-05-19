using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WL_OA.BLL.query.base_info;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OAProj.Controllers
{
    [Produces("application/json")]
    public class CompanyAccountController : BaseController<CompanyAccountBLL>
    {
        [HttpPost]
        [Route("api/companyAccount/get")]
        public QueryResult<IList<CompanyAccountEntity>> Get([FromBody] QueryCompanyAccountParam param)
        {
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("api/companyAccount/add")]
        public BaseOpResult Add([FromBody] CompanyAccountEntity entity)
        {
            entity.Finputor = RequestContext.LoginInfo.Name;
            entity.Finput_date = DateTime.Now;
            return BLL().AddEntity(entity);
        }

        [HttpGet]
        [Route("api/companyAccount/del/{entityID}")]
        public BaseOpResult Delete(int entityID)
        {
            return BLL().DelEntity(entityID);
        }


        [HttpPost]
        [Route("api/companyAccount/update")]
        public BaseOpResult Update([FromBody] CompanyAccountEntity entity)
        {
            return BLL().UpdateEntity(entity);
        }


        
    }
}
