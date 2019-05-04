using BLL.settings;
using BLL.util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WL_OA.BLL.query;
using WL_OA.Data;
using WL_OA.Data.dal;
using WL_OA.Data.dal.Cache;
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
                var pageIdx = param.GetFixedQueryPageIndex();
                var pageSize = param.GetFixedQueryPageSize();
                if (pageIdx > 1)
                {
                    query.Skip((pageIdx - 1) * pageSize);
                }
                query.Take(pageSize);
            }

            var retList = query.List();

            return new QueryResult<IList<SystemUserEntity>>(retList, rawRowCont, retList.Count);
        }


        const string ALL_USERS_CACHE_KEY = "CK_SYS_USERS";


        /// <summary>
        /// 获取所有用户信息（通常用于选择面板）
        /// </summary>
        /// <returns></returns>
        public IList<SystemUserEntity> GetAllUsers()
        {
            IList<SystemUserEntity> retList = null;

            if (null != m_cache)
            {
                retList = m_cache.Get<IList<SystemUserEntity>>(ALL_USERS_CACHE_KEY);
                if (null != retList)
                {
                    return retList;
                }
            }

            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<SystemUserEntity>();

            int rawRowCont = query.RowCount();

            retList = query.List();

            if (null != m_cache)
            {
                // 缓存设置失效时间，失效之后有请求调用该接口的会自动刷新缓存，省去很多修改的麻烦
                // 有特殊场景再特殊做，现在没空考虑这么多
                if (!m_cache.Add(ALL_USERS_CACHE_KEY, retList, CacheSetting.GetCacheDefaultExpireTimespan()))
                {
                    SLogger.Warn($"缓存记录 - {ALL_USERS_CACHE_KEY} 失败");
                }
            }

            return retList;
        }



        /// <summary>
        /// 检查登录授权
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public LoginInfo CheckLogin(LoginInfo info)
        {
            if(string.IsNullOrEmpty(info.Account))
            {
                info.RetMsg = "请输入登录账号";
                return info;
            }

            if (!string.IsNullOrEmpty(info.Token))
            {
                // 已启用session，检查token
                if(null != m_cache)
                {
                    // 已经登录，检验token是否合法即可
                    var cachedInfo = m_cache.Get<LoginInfo>(info.Token);
                    if (null == cachedInfo)
                    {
                        // 已过期，重新登录
                        info.RetMsg = "信息已过期，请重新登录";
                        info.Token = "";
                    }
                    else
                    {
                        if (cachedInfo.Account != info.Account)
                        {
                            info.RetMsg = "错误的登录信息，请检查参数";
                            info.Token = "";
                        }

                        m_cache.Add(info.Token, info);
                    }
                    return info;
                }                
            }
            else { }

            // 未登录，检验登录参数

            var session = NHibernateSessionManager.GetSession();

            // TODO:密码MD5，是否考虑进行密码MD5的再加密/解密
            var passWord = info.Password;

            var queryUsers = session.QueryOver<SystemUserEntity>()
                .Where(x => x.Fuser_account == info.Account && x.Fpassword == passWord).List();

            if(null == queryUsers || 0 == queryUsers.Count)
            {
                //throw new UserFriendlyException("用户名或密码错误", ExceptionScope.Parameter);
                info.RetMsg = "用户名或密码错误";
                info.Password = "";
                return info;                
            }

            if(1 != queryUsers.Count)
            {
                //throw new UserFriendlyException("用户数据异常", ExceptionScope.DB);
                SLogger.Err($"用户数据异常，账号：{info.Account}的数量为：{queryUsers.Count}，大于1");
            }

            var userEntity = queryUsers[0];

            if(userEntity.Fstate == (int)DataStateEnum.Discard)
            {
                info.RetMsg = $"账号{info.Account}已被弃用，请联系管理员";
                info.Token = "";
                return info;
            }

            info.Token = GenToken();
            info.LoginTime = DateTime.Now;
            info.Name = userEntity.Fname;
            info.Ticket = GenTicket();

            m_cache?.Add(info.Token, info);

            //return BaseOpResult.SucceedInstance;
            return info;
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
                m_cache?.Add(loginInfo.Token, loginInfo);
            }

            return loginInfo;
        }


        public override BaseOpResult AddEntityList(List<SystemUserEntity> entityList, bool bIsAutomic = false)
        {
            try
            {
                using (var session = NHibernateSessionManager.GetSession())
                {
                    var trans = session.BeginTransaction();

                    foreach (var newUser in entityList)
                    {
                        // 重置新用户的Fid，确保错误参数不影响操作
                        newUser.Fid = 0;
                        // 赋值用户创建时间
                        newUser.Fcreate_time = DateTime.Now;
                        // 赋值用户创建人
                        newUser.Fcreate_user = GetRequestContext().LoginInfo.Account;
                        try
                        {
                            newUser.IsValid();
                            var id = session.Save(newUser);
                        }
                        catch (Exception ex)
                        {
                            if (bIsAutomic)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                    trans.Commit();
                }                 
            }
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            return BaseOpResult.SucceedInstance;
        }


        public override BaseOpResult AddEntity(SystemUserEntity entity)
        {
            return AddUser(entity);
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
                // 赋值用户创建人
                newUser.Fcreate_user = GetRequestContext().LoginInfo.Account;

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

        public override BaseOpResult DelEntity(int entityID)
        {
            return DelUser(entityID);
        }

        public override BaseOpResult DelEntity(SystemUserEntity entity)
        {
            return DelUser(entity.Fid);
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
                    queryUser.Fstate = (int)DataStateEnum.Discard;
                    session.Update(queryUser);
                    //session.Delete(queryUser);
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
                    queryUser.Fstate = (int)DataStateEnum.Discard;
                    session.Update(queryUser);
                    //session.Delete(queryUser);
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


        public override BaseOpResult UpdateEntity(SystemUserEntity entity)
        {
            return UpdateUser(entity);
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
