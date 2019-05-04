using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WL_OA.BLL;
using WL_OA.BLL.query;
using WL_OA.Data.dto;
using WL_OA.Data.entity;

namespace WL_OAProj.Controllers
{
    [Produces("application/json")]
    public class WebAppDataController : BaseController<UserManagerBLL>
    {
        [HttpPost]
        [Route("api/DynamicSelects/GoodNames/{appId}")]
        public QueryResult<IList<GoodsInfoForSelData>> GetDSGoodsInfo(string appId)
        {
            var getList = BLL<GoodsInfoBLL>().GetAllGoodsInfo();
            var retList = GoodsInfoForSelData.ConvFrom(getList);

            //var retResult = new DynamicSelectInfo()
            //{
            //    cols = new List<DSStruct>() {
            //        new DSStruct(){label="货物名称",prop="Fname" },
            //        new DSStruct(){label="助记码",prop="Fmark",isKeyCol=true }
            //    },
            //};

            return new QueryResult<IList<GoodsInfoForSelData>>(retList, retList.Count, retList.Count);
        }


        [HttpPost]
        [Route("api/DynamicSelects/BusinessMan/{appId}")]
        public QueryResult<IList<UserInfoForSelData>> GetDSBusinessMan(string appId)
        {
            var getList = BLL<UserManagerBLL>().GetAllUsers();
            var retList = UserInfoForSelData.ConvFrom(getList);
            return new QueryResult<IList<UserInfoForSelData>>(retList, retList.Count, retList.Count);
        }
    }
}
