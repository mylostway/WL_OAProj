using BLL.util;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using WL_OA.Data;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;

namespace WL_OA.BLL.query
{
    public class AuthManagerBLL : CommBaseBLL<SystemAuthEntity, QueryAuthParam>
    {
        /// <summary>
        /// 获取权限信息列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override QueryResult<IList<SystemAuthEntity>> GetEntityList(QueryAuthParam param)
        {
            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new QueryResult<IList<SystemAuthEntity>>(QueryResultCode.Failed, "抱歉，您无权查询权限列表信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var query = session.QueryOver<SystemAuthEntity>();

                query.WhereIfNotNull(param.Fid, x => x.Fid == param.Fid);
                query.WhereIfNotEmpty(param.Name, x => x.Fname == param.Name);

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

                return new QueryResult<IList<SystemAuthEntity>>(retList, rawRowCont, retList.Count);
            }
        }



        /// <summary>
        /// 增加权限信息
        /// </summary>
        /// <param name="newRelation"></param>
        /// <returns></returns>
        public BaseOpResult AddAuthInfo(SystemAuthEntity newAuth)
        {
            newAuth.IsValid();

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权新增权限信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var queryResult = session.QueryOver<SystemAuthEntity>()
                    .Where(x => x.Fname == newAuth.Fname).SingleOrDefault();

                if (null != queryResult) return new BaseOpResult(QueryResultCode.Failed, $"抱歉，\"{newAuth.Fname}\" 权限设置已经存在，请重新输入");

                newAuth.Fid = 0;
                var trans = session.BeginTransaction();
                try
                {
                    session.Save(newAuth);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"添加新权限失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="relationInfo"></param>
        /// <returns></returns>
        public BaseOpResult DelAuthInfo(SystemAuthEntity authInfo)
        {
            // 可以通过名称或ID删除权限
            if (0 == authInfo.Fid && authInfo.Fname.NullOrEmpty()) return new BaseOpResult(QueryResultCode.Failed, "抱歉，删除权限参数有误，ID和名称必须填写最少一个值");

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权删除权限信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var dbQuery = session.QueryOver<SystemAuthEntity>();
                dbQuery.WhereIfNotEmpty(authInfo.Fname, x => x.Fname == authInfo.Fname);
                dbQuery.WhereIf(authInfo.Fid != 0, x => x.Fid == authInfo.Fid);

                var queryResult = dbQuery.SingleOrDefault();
                if (null == queryResult) return new BaseOpResult(QueryResultCode.Failed, "该权限信息不存在或已被删除");

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
                    return new BaseOpResult(QueryResultCode.Failed, $"删除权限信息失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 更新权限信息
        /// </summary>
        /// <param name="updateAuth"></param>
        /// <returns></returns>
        public BaseOpResult UpdateAuthInfo(SystemAuthEntity updateAuth)
        {
            // 只可通过ID修改权限信息（因为权限名字也允许修改！）
            if (0 == updateAuth.Fid) return new BaseOpResult(QueryResultCode.Failed, "抱歉，更新权限参数有误，ID必须填写");

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权更新权限信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var dbQuery = session.QueryOver<SystemAuthEntity>();
                dbQuery.WhereIf(updateAuth.Fid != 0, x => x.Fid == updateAuth.Fid);
                var authInfoInDb = dbQuery.SingleOrDefault();

                if (null == authInfoInDb) return new BaseOpResult(QueryResultCode.Failed, "该权限信息不存在或已被删除");

                var trans = session.BeginTransaction();
                try
                {
                    updateAuth.Fid = authInfoInDb.Fid;
                    session.Merge(updateAuth);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"更新权限信息失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }
    }
}
