using BLL.settings;
using BLL.util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WL_OA.BLL.query;
using WL_OA.Data;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;

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
        public BaseOpResult CheckLogin(LoginInfo info)
        {
            var session = NHibernateSessionManager.GetSession();

            // TODO:密码MD5，是否考虑进行密码MD5的再加密/解密
            var passWord = info.Password;

            var userEntity = session.QueryOver<SystemUserEntity>()
                .Where(x => x.Fuser_account == info.Account && x.Fpassword == passWord).List();

            if(null == userEntity || 0 == userEntity.Count)
            {
                //throw new UserFriendlyException("用户名或密码错误", ExceptionScope.Parameter);
                return new BaseOpResult(QueryResultCode.Failed, "用户名或密码错误");
            }

            if(1 != userEntity.Count)
            {
                //throw new UserFriendlyException("用户数据异常", ExceptionScope.DB);
                SLogger.Err($"用户数据异常，账号：{info.Account}的数量为：{userEntity.Count}，大于1");
            }

            info.Token = GenToken();
            info.LoginTime = DateTime.Now;

            m_cache?.Set(info.Token, info, GetTokenTimeExpire());

            return BaseOpResult.SucceedInstance;
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
        public BaseOpResult AddUser(SystemUserEntity newUser)
        {
            newUser.IsValid();

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权限增加用户信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var queryUser = session.QueryOver<SystemUserEntity>()
                    .Where(x => x.Fuser_account == newUser.Fuser_account).SingleOrDefault();

                if(null != queryUser) return new BaseOpResult(QueryResultCode.Failed, "抱歉，用户账号已存在，请重新输入");

                // 重置新用户的Fid，确保错误参数不影响操作
                newUser.Fid = 0;
                // 赋值用户创建时间
                newUser.Fcreate_time = DateTime.Now;

                var trans = session.BeginTransaction();
                try
                {
                    session.Save(newUser);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"添加新用户失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        public BaseOpResult DelUser(int userID)
        {
            if (0 == userID) throw new UserFriendlyException("要删除用户的ID不能为空!", ExceptionScope.Parameter);

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权修改用户信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var queryUser = session.QueryOver<SystemUserEntity>()
                    .Where(x => x.Fid == userID).SingleOrDefault();

                if (null == queryUser) return new BaseOpResult(QueryResultCode.Failed, "用户不存在或已被删除");

                //this.SoftDelEntity(queryUser);

                var trans = session.BeginTransaction();
                try
                {
                    //queryUser.Fstate = 0;
                    //session.Update(queryUser);
                    session.Delete(queryUser);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"删除用户失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        public BaseOpResult DelUser(string userAccount)
        {
            if (string.IsNullOrEmpty(userAccount)) throw new UserFriendlyException("要删除用户的账号不能为空!", ExceptionScope.Parameter);

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name)) return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权修改用户信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var queryUser = session.QueryOver<SystemUserEntity>()
                    .Where(x => x.Fuser_account == userAccount).SingleOrDefault();

                if (null == queryUser) return new BaseOpResult(QueryResultCode.Failed, "用户不存在");

                //this.SoftDelEntity(queryUser);
                
                var trans = session.BeginTransaction();
                try
                {
                    //queryUser.Fstate = 0;
                    //session.Update(queryUser);
                    session.Delete(queryUser);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"删除用户失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }



        /// <summary>
        /// 更新用户基本信息（只有用户本身能修改密码！）
        /// </summary>
        /// <param name="newUser"></param>
        public BaseOpResult UpdateUser(SystemUserEntity updateUser)
        {
            updateUser.IsValid();

            var opUser = GetRequestContext().LoginInfo.Account;

            using (var session = NHibernateSessionManager.GetSession())
            {
                var dbQuery = session.QueryOver<SystemUserEntity>().Where(x => x.Fuser_account == updateUser.Fuser_account);

                dbQuery.WhereIf(0 != updateUser.Fid, x => x.Fid == updateUser.Fid);

                var userInfoInDb = dbQuery.SingleOrDefault();

                if (null == userInfoInDb) return new BaseOpResult(QueryResultCode.Failed, "用户不存在");

                // 只有用户本身能通过系统请求修改自身密码（管理员可以通过其他渠道修改，如直接DB更新等）
                if (!updateUser.Fpassword.NullOrEmpty() && opUser != userInfoInDb.Fuser_account)
                    return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权修改用户密码");

                if (opUser != userInfoInDb.Fuser_account
                    && !CanUserDo(MethodBase.GetCurrentMethod().Name, opUser))
                {
                    return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权修改用户信息");
                }

                var trans = session.BeginTransaction();
                try
                {
                    updateUser.Fid = userInfoInDb.Fid;
                    session.Merge(updateUser);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"更新用户信息失败，原因：${ex.Message}");
                }
                session.Flush();                
            }

            return BaseOpResult.SucceedInstance;
        }

    }
}
