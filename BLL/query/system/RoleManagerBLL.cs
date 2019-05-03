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

namespace WL_OA.BLL
{
    public partial class RoleManagerBLL : CommBaseBLL<SystemRoleEntity, QueryRoleInfoParam>
    {
        public override QueryResult<IList<SystemRoleEntity>> GetEntityList(QueryRoleInfoParam param)
        {
            //if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                //return new QueryResult<IList<SystemRoleEntity>>(QueryResultCode.Failed, "抱歉，您无权限查询角色信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var query = session.QueryOver<SystemRoleEntity>();

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

                return new QueryResult<IList<SystemRoleEntity>>(retList, rawRowCont, retList.Count);
            }
        }


        public BaseOpResult AddRole(SystemRoleEntity newRole)
        {
            newRole.IsValid();

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权限增加角色信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var queryResult = session.QueryOver<SystemRoleEntity>()
                    .Where(x => x.Fname == newRole.Fname).SingleOrDefault();

                if (null != queryResult) return new BaseOpResult(QueryResultCode.Failed, "抱歉，该角色名称已存在，请重新输入");

                // 重置新用户的Fid，确保错误参数不影响操作
                newRole.Fid = 0;
                // 赋值用户创建时间
                newRole.Fcreate_time = DateTime.Now;

                var trans = session.BeginTransaction();
                try
                {
                    session.Save(newRole);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"添加新角色失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        public BaseOpResult DelRole(SystemRoleEntity roleEntity)
        {
            if(0 == roleEntity.Fid && roleEntity.Fname.NullOrEmpty()) return new BaseOpResult(QueryResultCode.Failed, "抱歉，删除角色信息失败，请输入角色ID或名称");

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权删除角色信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var dbQuery = session.QueryOver<SystemRoleEntity>();
                dbQuery.WhereIfNotEmpty(roleEntity.Fname, x => x.Fname == roleEntity.Fname);
                dbQuery.WhereIf(roleEntity.Fid != 0, x => x.Fid == roleEntity.Fid);

                var queryResult = dbQuery.SingleOrDefault();

                if (null == queryResult) return new BaseOpResult(QueryResultCode.Failed, "该角色信息不存在或已被删除");

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
                    return new BaseOpResult(QueryResultCode.Failed, $"删除角色信息失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        public BaseOpResult UpdateRole(SystemRoleEntity updateRole)
        {
            updateRole.IsValid();

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权修改角色信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var dbQuery = session.QueryOver<SystemRoleEntity>().Where(x => x.Fname == updateRole.Fname);

                dbQuery.WhereIf(0 != updateRole.Fid, x => x.Fid == updateRole.Fid);

                var roleInfoInDb = dbQuery.SingleOrDefault();

                if (null == roleInfoInDb) return new BaseOpResult(QueryResultCode.Failed, "该角色信息不存在或已被删除");

                var trans = session.BeginTransaction();
                try
                {
                    updateRole.Fid = roleInfoInDb.Fid;
                    session.Merge(updateRole);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"更新角色信息失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }
    }
}
