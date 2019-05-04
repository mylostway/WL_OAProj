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


        [HttpPost]
        [Route("/api/orgManager/uim/get")]
        public QueryResult<IList<SystemUserEntity>> GetSystemUsers([FromBody] QueryUserInfoParam param)
        {
            return BLL().GetEntityList(param);
        }


        [HttpPost]
        [Route("/api/orgManager/uim/add")]
        public BaseOpResult AddSystemUser([FromBody] SystemUserEntity entity)
        {            
            return BLL().AddUser(entity);
        }


        [HttpPost]
        [Route("/api/orgManager/uim/update")]
        public BaseOpResult UpdateSystemUser([FromBody] SystemUserEntity entity)
        {            
            return BLL().UpdateUser(entity);
        }



        [HttpGet]
        [Route("/api/orgManager/uim/del/{id}")]
        public BaseOpResult DelUser(int userId)
        {
            return BLL().DelUser(userId);
        }


        [HttpGet]
        [Route("/api/orgManager/uim/del/{account}")]
        public BaseOpResult DelUser(string account)
        {
            return BLL().DelUser(account);
        }
    }
}
