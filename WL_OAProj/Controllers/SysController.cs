using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WL_OA.BLL.query;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dto;
using WL_OA.Data;
using WL_OA.BLL;

namespace WL_OAProj.Controllers
{
    [Produces("application/json")]
    public class SysController : BaseController<UserManagerBLL>
    {
        [HttpPost]
        [Route("login")]
        public LoginInfo Login([FromBody] LoginInfo info)
        {
            return BLL().CheckLogin(info);
        }
    }
}
