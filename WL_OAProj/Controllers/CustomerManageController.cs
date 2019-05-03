using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WL_OAProj;
using WL_OA.BLL.query;
using WL_OA.Data;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OAProj.Controllers
{
    //[Route("api/Customer")]
    [Produces("application/json")]
    public class CustomerManageController : BaseController<CustomerManagerBLL>
    {
        [HttpPost]
        [Route("api/GetCustomerFullInfo")]
        public QueryResult<AddCustomerInfoDTO> GetCustomerFullInfo([FromBody] QueryCustomerFullInfoParam param)
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
            if(null != infoList)
            {
                foreach (var eInfo in infoList)
                {
                    retList.Add(new CustomerInfoQueryResultDTO(eInfo));
                }
            }
            return new QueryResult<IList<CustomerInfoQueryResultDTO>>(retList, baseInfoQueryResult.MaxResultCount);
        }


        [HttpPost]
        [Route("api/AddCustomerInfo")]
        public BaseOpResult AddCustomerInfo([FromBody] AddCustomerInfoDTO dto)
        {
            /*
             测试映射复杂对象用
            var deObj = HttpContext.DeSerializeRequestObjFromRequest<AddCustomerInfoDTO>();
            */
            if (null == dto) return BaseOpResult.FailFor("添加的信息不能为空，请检查参数");
            return BLL().AddEntity(dto);
        }


        [HttpPost]
        [Route("api/UpdateCustomerInfo")]
        public BaseOpResult UpdateEntity([FromBody] AddCustomerInfoDTO dto)
        {
            if (null == dto) return BaseOpResult.FailFor("更新的信息不能为空，请检查参数");
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