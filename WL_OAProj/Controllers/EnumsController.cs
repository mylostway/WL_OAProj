using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WL_OA.BLL.query;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dto;
using WL_OA.Data;

namespace WL_OAProj.Controllers
{
    [Produces("application/json")]
    public class EnumsController : Controller
    {
        [HttpGet]
        [Route("api/getEnums")]
        public QueryResult<Dictionary<string, Dictionary<string, EnumInfo>>> GetEnums(string enumName)
        {
            var retDic = new Dictionary<string, Dictionary<string, EnumInfo>>();
            if (string.IsNullOrEmpty(enumName))
            {
                retDic = EnumHelper.GetAllEnums();
                return new QueryResult<Dictionary<string, Dictionary<string, EnumInfo>>>(retDic);
            }
            else
            {
                var ret = EnumHelper.GetEnumSettingOnName(enumName);                
                retDic.Add(enumName, ret);
                return new QueryResult<Dictionary<string, Dictionary<string, EnumInfo>>>(retDic);
            }
        }

    }
}
