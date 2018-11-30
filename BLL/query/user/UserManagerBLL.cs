using BLL.settings;
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
            throw new NotImplementedException();
        }




        public bool CheckLogin(LoginInfo info)
        {
            var session = NHibernateSessionManager.GetSession();

            // TODO:密码MD5，是否考虑进行密码MD5的在加密/解密
            var passWord = info.Password;

            var userEntity = session.QueryOver<SystemUserEntity>()
                .Where(x => x.Fuser_id == info.ID && x.Fpassword == passWord).List();

            if(null == userEntity || 0 == userEntity.Count)
            {
                throw new UserFriendlyException("用户名或密码错误", ExceptionScope.Parameter);
            }

            if(1 != userEntity.Count)
            {
                throw new UserFriendlyException("用户异常", ExceptionScope.DB);
            }

            m_cache.Set(GenToken(), info, GetTokenTimeExpire());

            return false;
        }

        
    }
}
