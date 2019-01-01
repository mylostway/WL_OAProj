using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WL_OA.Data.entity;

namespace WL_OA.Data
{
    public class LoginInfo : BaseEntity<int>
    {
        public LoginInfo() { }

        public LoginInfo(string account = "",string password = "")
        {
            this.Account = account;
            this.Password = password;
        }

        /// <summary>
        /// 用户账号
        /// </summary>
        [Required]
        public string Account { get; set; } = "";

        /// <summary>
        /// 登录名
        /// </summary>
        public string Name { get; set; } = "";


        /// <summary>
        /// 密码（登录的时候有值，其他时候不保存）
        /// </summary>
        [Required]
        public string Password { get; set; } = "";

        /// <summary>
        /// 登录key
        /// </summary>
        public string Token { get; set; } = "";


        /// <summary>
        /// 请求key，每次请求匹配Ticket，防止Token泄漏造成的危害（目前未实现）
        /// </summary>
        public string Ticket { get; set; } = "";


        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; } = DateTime.Now;

        
    }
}
