﻿using BLL.settings;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.BLL.query;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OA.BLL
{
    public partial class UserManagerBLL : CommBaseBLL<SystemUserEntity, QueryUserInfoParam>
    {
        /// <summary>
        /// 用户ID最大占位长度
        /// </summary>
        public const int MAX_USER_BIT_COUNT = 8;

        /// <summary>
        /// 最大用户数量
        /// </summary>
        public const int MAX_USER_COUNT = 100000000 - 1;

        /// <summary>
        /// 用户ID最大字符串
        /// </summary>
        public static readonly string MAX_USER_ID_STR = MAX_USER_COUNT.ToString();

        /// <summary>
        /// 整形ID格式化到用户ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ToUserID(int id)
        {
            if (id > MAX_USER_COUNT) throw new Exception("用户ID异常，超出最大用户数值");
            return id.ToString(string.Format("{0:D8}", id));
        }

        /// <summary>
        /// 字符串ID格式化到用户ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ToUserID(string id)
        {
            if (id.Length > MAX_USER_ID_STR.Length) throw new Exception("用户ID异常，超出最大用户数值");
            return id.PadLeft(MAX_USER_BIT_COUNT - id.Length, '0');
        }


        /// <summary>
        /// 获取用户操作令牌过期时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetTokenTimeExpire()
        {
            return DateTime.Now.AddSeconds(BLLSettings.DEFAULT_TOKEN_TIME_OUT_IN_SEC);
        }


        /// <summary>
        /// 获取用户操作令牌
        /// </summary>
        /// <returns></returns>
        public static string GenToken()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }


        /// <summary>
        /// 每次用户操作都生成一个操作Ticket，防止重放，token盗用等BUG，目前未实现(可以考虑用md5(account + time + rand))
        /// </summary>
        /// <returns></returns>
        public static string GenTicket()
        {
            return "";
        }
    }
}
