using BLL.util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;

namespace WL_OA.BLL.query
{
    public class UserRoleRelationBLL : CommBaseBLL<SystemUserRoleRelationEntity, QueryUserRoleRelationParam>
    {
        /// <summary>
        /// 查询用户角色关联信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override QueryResult<IList<SystemUserRoleRelationEntity>> GetEntityList(QueryUserRoleRelationParam param)
        {
            var session = NHibernateSessionManager.GetSession();

            var query = session.QueryOver<SystemUserRoleRelationEntity>();

            query.WhereIfNotNull(param.Fid, x => x.Fid == param.Fid);
            query.WhereIfNotNull(param.RoleID, x => x.Frole_id == param.RoleID);
            query.WhereIfNotNull(param.UserID, x => x.Fuser_id == param.UserID);

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

            return new QueryResult<IList<SystemUserRoleRelationEntity>>(retList, rawRowCont, retList.Count);
        }


        /// <summary>
        /// 增加用户角色关联
        /// </summary>
        /// <param name="newRelation"></param>
        /// <returns></returns>
        public BaseOpResult AddRelation(SystemUserRoleRelationEntity newRelation)
        {
            newRelation.IsValid();

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权新增用户角色信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var queryResult = session.QueryOver<SystemUserRoleRelationEntity>()
                    .Where(x => x.Frole_id == newRelation.Frole_id && x.Fuser_id == newRelation.Fuser_id).SingleOrDefault();

                if (null != queryResult) return new BaseOpResult(QueryResultCode.Failed, "抱歉，该用户角色关联已经存在，请重新输入");

                newRelation.Fid = 0;
                var trans = session.BeginTransaction();
                try
                {
                    session.Save(newRelation);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"添加新用户角色失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 删除用户角色关联
        /// </summary>
        /// <param name="relationInfo"></param>
        /// <returns></returns>
        public BaseOpResult DelRelation(SystemUserRoleRelationEntity relationInfo)
        {
            // 当前只允许单个授权信息删除，即Frole_id和Fauth_id必须有值，且唯一指向一个授权信息
            if (0 == relationInfo.Frole_id || 0 == relationInfo.Fuser_id) return new BaseOpResult(QueryResultCode.Failed, "抱歉，删除授权信息参数有误");

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权删除授权信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var queryResult = session.QueryOver<SystemUserRoleRelationEntity>().Where(x => x.Fuser_id == relationInfo.Fuser_id && x.Frole_id == relationInfo.Frole_id).SingleOrDefault();

                if (null == queryResult) return new BaseOpResult(QueryResultCode.Failed, "该授权关联信息不存在或已被删除");

                //this.SoftDelEntity(queryUser);

                var trans = session.BeginTransaction();
                try
                {
                    //queryUser.Fstate = 0;
                    //session.Update(queryUser);
                    session.Delete(queryResult);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"删除授权信息失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 用户角色关联目前没有可更新的资料，只需增删
        /// </summary>
        /// <param name="updateRelation"></param>
        /// <returns></returns>
        public BaseOpResult UpdateRelation(SystemUserRoleRelationEntity updateRelation)
        {
            throw new NotImplementedException();

            updateRelation.IsValid();

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权更新授权信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var dbQuery = session.QueryOver<SystemUserRoleRelationEntity>().Where(x => x.Fuser_id == updateRelation.Fuser_id && x.Frole_id == updateRelation.Frole_id);

                var relationInfoInDb = dbQuery.SingleOrDefault();

                if (null == relationInfoInDb) return new BaseOpResult(QueryResultCode.Failed, "该授权信息不存在或已被删除");

                var trans = session.BeginTransaction();
                try
                {
                    updateRelation.Fid = relationInfoInDb.Fid;
                    session.Merge(updateRelation);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"更新授权关联信息失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }
    }
}
