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
        public QueryResult<IList<FreBussinessOpCenterDTO>> GetEntityList([FromBody] QueryFreBusinessCenterParam param)
        {
            return BLL().GetFreBusinessOpCenterList(param);
        }


        [HttpPost]
        [Route("api/GetFreBusinessDetail/{id}")]
        public FreBussinessOpCenterDTO GetDetail(int id)
        {
            return BLL().GetDetail(id);
        }


        [HttpPost]
        [Route("api/AddFreBusiness")]
        public BaseOpResult AddFreBusiness([FromBody] FreBussinessOpCenterDTO dto)
        {
            return BLL().AddEntity(dto);
        }


        [HttpPost]
        [Route("api/UpdateFreBusiness")]
        public BaseOpResult UpdateFreBusiness([FromBody] FreBussinessOpCenterDTO updateInfo)
        {
            return BLL().UpdateFreBusinessDTO(updateInfo);
        }


        [HttpPost]
        [Route("api/DelFreBusinessWorkList/{workListID}")]
        public BaseOpResult DelFreBusinessWorkList(string workListID)
        {
            return BLL().Del(workListID);
        }


        [HttpPost]
        [Route("api/DelFreBusinessContainsInfo/{listID}")]
        public BaseOpResult DelFreBusinessContainsInfo(string listID)
        {
            return new BaseOpResult(QueryResultCode.Failed, "该方法未支持");
            //return BLL().Del(listID);
        }


        [HttpPost]
        [Route("api/UpdateFreBusinessOrderInfo")]
        public BaseOpResult UpdateOrderInfo(FreBusinessOrderInfoEntity orderInfo)
        {
            return BLL().UpdateFreBusinessPartInfo(orderInfo);
        }

        [HttpPost]
        [Route("api/UpdateFreBusinessHoldingGoodsInfo")]
        public BaseOpResult UpdateHoldingGoodsInfo(FreBusinessHoldGoodsInfoEntity updateInfo)
        {
            return BLL().UpdateFreBusinessPartInfo(updateInfo);
        }

        [HttpPost]
        [Route("api/UpdateFreBusinessLayingGoodsInfo")]
        public BaseOpResult UpdateLayingGoodsInfo(FreBusinessLayGoodsInfoEntity updateInfo)
        {
            return BLL().UpdateFreBusinessPartInfo(updateInfo);
        }

        [HttpPost]
        [Route("api/UpdateFreBusinessContainsInfo")]
        public BaseOpResult UpdateContainsInfo(FreBusinessContainsInfoEntity updateInfo)
        {
            return BLL().UpdateFreBusinessPartInfo(updateInfo);
        }

        [HttpPost]
        [Route("api/UpdateFreBusinessSeaInfo")]
        public BaseOpResult UpdateSeaInfo(FreBusinessSeaTransportInfoEntity updateInfo)
        {
            return BLL().UpdateFreBusinessPartInfo(updateInfo);
        }

        [HttpPost]
        [Route("api/UpdateFreBusinessOtherInfo")]
        public BaseOpResult UpdateOtherInfo(FreBusinessOtherInfoEntity updateInfo)
        {
            return BLL().UpdateFreBusinessPartInfo(updateInfo);
        }

        [HttpPost]
        [Route("api/UpdateFreBusinessOperationInfo")]
        public BaseOpResult UpdateOperationInfo(FreBusinessOperationInfoEntity updateInfo)
        {
            return BLL().UpdateFreBusinessPartInfo(updateInfo);
        }

        [HttpPost]
        [Route("api/UpdateFreBusinessMatterInfo")]
        public BaseOpResult UpdateMatterInfo(FreBusinessMatterInfoEntity updateInfo)
        {
            return BLL().UpdateFreBusinessPartInfo(updateInfo);
        }

        [HttpPost]
        [Route("api/UpdateFreBusinessAssuranceInfo")]
        public BaseOpResult UpdateAssuranceInfo(FreBusinessAssuranceInfoEntity updateInfo)
        {
            return BLL().UpdateFreBusinessPartInfo(updateInfo);
        }

        [HttpPost]
        [Route("api/UpdateFreBusinessBasicInfo")]
        public BaseOpResult UpdateBasicInfo(FreBusinessBasicInfoEntity updateInfo)
        {
            return BLL().UpdateFreBusinessPartInfo(updateInfo);
        }


        
    }
}