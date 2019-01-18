using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WL_OA.BLL;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OAProj.Controllers
{
    [Produces("application/json")]    
    public class FreBusinessController : BaseController<FreBusinessCenterBLL>
    {
        [HttpPost]
        [Route("api/GetFreBusinessList")]
        public QueryResult<IList<FreBusinessCenterEntity>> GetEntityList(QueryFreBusinessCenterParam param)
        {
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("api/GetFreBusinessDetail/{id}")]
        public FreBussinessOpCenterDTO GetDetail(int id)
        {
            return BLL().GetDetail(id);
        }


        [HttpPost]
        [DisableRequestSizeLimit]
        [Route("api/AddFreBusiness")]
        public BaseOpResult AddFreBusiness([FromBody] FreBussinessOpCenterDTO dto)
        {
            return BLL().AddEntity(dto);
        }


        [HttpPost]
        [Route("api/DelFreBusiness/{listID}")]
        public BaseOpResult DelFreBusiness(string listID)
        {
            return BLL().Del(listID);
        }
    }
}