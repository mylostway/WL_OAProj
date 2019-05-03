using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.dto;
using WL_OA.Data.entity;

namespace WL_OA.Data.dto
{
    public class UserLoginResult : BaseOpResult
    {
        public UserLoginResult() { }

        public UserLoginResult(QueryResultCode resultCode, string retMsg)
            :base(resultCode,retMsg)
        {

        }

        public UserLoginResult(SystemUserEntity entity)
        {
            Fuser_account = entity.Fuser_account;
            Fname = entity.Fname;
            LoginTime = DateTime.Now;
        }

        public string Fuser_account { get; set; }

        public string Fname { get; set; }

        public string FToken { get; set; }

        public DateTime LoginTime { get; set; }
    }
}
