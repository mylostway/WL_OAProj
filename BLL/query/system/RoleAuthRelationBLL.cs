using BLL.util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;

namespace WL_OA.BLL.query
{
    public class RoleAuthRelationBLL : CommBaseBLL<SystemRoleAuthRelationEntity, QueryRoleAuthRelationParam>
    {
        /// <summary>
        /// 查询授权列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override QueryResult<IList<SystemRoleAuthRelationEntity>> GetEntityList(QueryRoleAuthRelationParam param)
        {
            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new QueryResult<IList<SystemRoleAuthRelationEntity>>(QueryResultCode.Failed, "抱歉，您无权查询授权信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var query = session.QueryOver<SystemRoleAuthRelationEntity>();

                query.WhereIfNotNull(param.Fid, x => x.Fid == param.Fid);
                query.WhereIfNotNull(param.RoleID, x => x.Frole_id == param.RoleID);
                query.WhereIfNotNull(param.AuthID, x => x.Fauth_id == param.AuthID);

                int rawRowCont = query.RowCount();

                if (param.IsAllowPagging)
                {
                    QueryHelper.FixQueryTake(param, rawRowCont);

                    if (null != param.Skip && param.Skip.Value > 0) query.Skip(param.Skip.Value);
                    if (null != param.Take && param.Take.Value > 0) query.Take(param.Take.Value);
                }

                var retList = query.List();

                return new QueryResult<IList<SystemRoleAuthRelationEntity>>(retList, rawRowCont, retList.Count);
            }
        }


        /// <summary>
        /// 增加授权
        /// </summary>
        /// <param name="newRelation"></param>
        /// <returns></returns>
        public BaseOpResult AddRelation(SystemRoleAuthRelationEntity newRelation)
        {
            newRelation.IsValid();

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权新增授权信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var queryResult = session.QueryOver<SystemRoleAuthRelationEntity>()
                    .Where(x => x.Frole_id == newRelation.Frole_id && x.Fauth_id == newRelation.Fauth_id).SingleOrDefault();

                if (null != queryResult) return new BaseOpResult(QueryResultCode.Failed, "抱歉，该授权关联已经存在，请重新输入");

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
                    return new BaseOpResult(QueryResultCode.Failed, $"添加新授权失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 删除授权
        /// </summary>
        /// <param name="relationInfo"></param>
        /// <returns></returns>
        public BaseOpResult DelRelation(SystemRoleAuthRelationEntity relationInfo)
        {
            // 当前只允许单个授权信息删除，即Frole_id和Fauth_id必须有值，且唯一指向一个授权信息
            if (0 == relationInfo.Frole_id || 0 == relationInfo.Fauth_id) return new BaseOpResult(QueryResultCode.Failed, "抱歉，删除授权信息参数有误");

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权删除授权信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var queryResult = session.QueryOver<SystemRoleAuthRelationEntity>().Where(x => x.Fauth_id == relationInfo.Fauth_id && x.Frole_id == relationInfo.Frole_id).SingleOrDefault();

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
        /// 授权关联目前没有可更新的资料，只需增删
        /// </summary>
        /// <param name="updateRelation"></param>
        /// <returns></returns>
        public BaseOpResult UpdateRelation(SystemRoleAuthRelationEntity updateRelation)
        {
            throw new NotImplementedException();

            updateRelation.IsValid();

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权更新授权信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var dbQuery = session.QueryOver<SystemRoleAuthRelationEntity>().Where(x => x.Fauth_id == updateRelation.Fauth_id && x.Frole_id == updateRelation.Frole_id);

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
