using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data
{
    public class LoginInfo
    {
        public LoginInfo() { }



        /// <summary>
        /// 用户ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 密码（登录的时候有值，其他时候不保存）
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 登录key
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
    }
}
