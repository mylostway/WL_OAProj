using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WL_OA.BLL.query;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OAProj.Controllers
{
    [Route("api/Customer")]
    public class CustomerManageController : BaseController<CustomerManagerBLL>
    {
        [HttpGet]
        [Route("GetCustomerFullInfo/{customerID}")]
        public QueryResult<CustomerInfoDTO> GetCustomerFullInfo(int customerID)
        {
            return BLL().GetCustomerFullInfo(customerID);
        }


        [HttpPost]
        [Route("GetEntityList")]
        public BaseOpResult GetEntityList([FromBody] QueryCustomerInfoParam param)
        {
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("AddCustomerInfo")]
        public BaseOpResult AddCustomerInfo([FromBody] CustomerInfoDTO dto)
        {
            return BLL().AddEntity(dto);
        }


        [HttpPost]
        [Route("UpdateEntity")]
        public BaseOpResult UpdateEntity([FromBody] CustomerInfoDTO dto)
        {
            return BLL().UpdateEntity(dto);
        }


        [HttpPost]
        [Route("DelEntity")]
        public BaseOpResult DelEntity([FromBody] CustomerInfoEntity entity)
        {
            return BLL().DelEntity(entity);
        }
    }
}