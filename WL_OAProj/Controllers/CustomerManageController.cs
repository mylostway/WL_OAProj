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
    //[Route("api/Customer")]
    [Produces("application/json")]
    public class CustomerManageController : BaseController<CustomerManagerBLL>
    {
        [HttpGet]
        [Route("GetCustomerFullInfo/{customerID}")]
        public QueryResult<AddCustomerInfoDTO> GetCustomerFullInfo(QueryCustomerFullInfoParam param)
        {
            return BLL().GetCustomerFullInfo(param);
        }


        [HttpPost]
        [Route("api/GetCustomerInfoList")]
        public QueryResult<IList<CustomerInfoQueryResultDTO>> GetEntityList([FromBody] QueryCustomerInfoParam param)
        {
            var baseInfoQueryResult = BLL().GetEntityList(param);
            var infoList = baseInfoQueryResult.ResultData;
            var retList = new List<CustomerInfoQueryResultDTO>();
            foreach(var eInfo in infoList)
            {
                retList.Add(new CustomerInfoQueryResultDTO(eInfo));
            }
            return new QueryResult<IList<CustomerInfoQueryResultDTO>>(retList, baseInfoQueryResult.MaxResultCount);
        }


        [HttpPost]
        [Route("api/AddCustomerInfo")]
        public BaseOpResult AddCustomerInfo(AddCustomerInfoDTO dto)
        {
            return BLL().AddEntity(dto);
        }


        [HttpPost]
        [Route("api/UpdateCustomerInfo")]
        public BaseOpResult UpdateEntity([FromBody] AddCustomerInfoDTO dto)
        {
            return BLL().UpdateEntity(dto);
        }


        [HttpPost]
        [Route("api/DelCustomerInfo")]
        public BaseOpResult DelEntity([FromBody] CustomerInfoEntity entity)
        {
            return BLL().DelEntity(entity);
        }
    }
}