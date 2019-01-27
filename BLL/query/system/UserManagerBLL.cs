using BLL.settings;
using BLL.util;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.BLL.query;
using WL_OA.Data;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OA.BLL
{
    public partial class UserManagerBLL : CommBaseBLL<SystemUserEntity, QueryUserInfoParam>
    {
        public override QueryResult<IList<SystemUserEntity>> GetEntityList(QueryUserInfoParam param)
        {
            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<SystemUserEntity>();

            query.WhereIfNotNull(param.Fid, x => x.Fid == param.Fid);
            query.WhereIfNotEmpty(param.Account, x => x.Fuser_account == param.Account);
            query.WhereIfNotEmpty(param.Name, x => x.Fname == param.Name);
            query.WhereIfNotNull(param.CreateTime, x => x.Fcreate_time >= param.CreateTime);

            int rawRowCont = query.RowCount();

            if (param.IsAllowPagging)
            {
                QueryHelper.FixQueryTake(param, rawRowCont);

                if (null != param.Skip && param.Skip.Value > 0) query.Skip(param.Skip.Value);
                if (null != param.Take && param.Take.Value > 0) query.Take(param.Take.Value);
            }

            var retList = query.List();

            return new QueryResult<IList<SystemUserEntity>>(retList, rawRowCont, retList.Count);
        }



        /// <summary>
        /// 检查登录授权
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CheckLogin(LoginInfo info)
        {
            var session = NHibernateSessionManager.GetSession();

            // TODO:密码MD5，是否考虑进行密码MD5的在加密/解密
            var passWord = info.Password;

            var userEntity = session.QueryOver<SystemUserEntity>()
                .Where(x => x.Fuser_account == info.Account && x.Fpassword == passWord).List();

            if(null == userEntity || 0 == userEntity.Count)
            {
                throw new UserFriendlyException("用户名或密码错误", ExceptionScope.Parameter);
            }

            if(1 != userEntity.Count)
            {
                throw new UserFriendlyException("用户数据异常", ExceptionScope.DB);
            }

            info.Token = GenToken();
            info.LoginTime = DateTime.Now;

            m_cache?.Set(info.Token, info, GetTokenTimeExpire());

            return false;
        }

        /// <summary>
        /// 获取登录信息，返回null表示没有登录或者登录态已经过期
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public LoginInfo GetLoginInfo(string token)
        {
            var loginInfo = m_cache?.Get<LoginInfo>(token);

            if (null != loginInfo)
            {
                // 更新信息过期时间
                m_cache?.Set(loginInfo.Token, loginInfo, GetTokenTimeExpire());
            }

            return loginInfo;
        }


        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="newUser"></param>
        public void AddUser(SystemUserEntity newUser)
        {
            newUser.Fcreate_time = DateTime.Now;

            this.AddEntity(newUser);
        }


        public void DelUser(int userID)
        {
            this.SoftDelEntity(userID);
        }


        public void DelUser(string userAccount)
        {
            var session = NHibernateSessionManager.GetSession();

            var queryUser = session.QueryOver<SystemUserEntity>()
                .Where(x => x.Fuser_account == userAccount).SingleOrDefault();

            if(null == queryUser)
            {
                throw new UserFriendlyException("要废弃的用户不存在", ExceptionScope.Parameter);
            }

            this.SoftDelEntity(queryUser);
        }



        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="newUser"></param>
        public void UpdateUser(SystemUserEntity updateUser)
        {
            this.UpdateEntity(updateUser);
        }

    }
}
