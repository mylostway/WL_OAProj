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
        [Route("api/GetWebAppSelectPanelData/{id}")]
        public QueryResult<IDictionary<string, IList<BaseEntity<int>>>> GetWebAppSelectPanelData(string appId)
        {
            var retDic = new Dictionary<string, IList<BaseEntity<int>>>();
            return new QueryResult<IDictionary<string, IList<BaseEntity<int>>>>(retDic, retDic.Keys.Count, retDic.Keys.Count);
        }
    }
}
