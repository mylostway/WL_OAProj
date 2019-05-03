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

namespace WL_OA.BLL
{
    public class CompanyDepartmentBLL : CommBaseBLL<CompanyDepartmentEntity, QueryCompanyDepartmentInfoParam>
    {
        /// <summary>
        /// 获取部门信息列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override QueryResult<IList<CompanyDepartmentEntity>> GetEntityList(QueryCompanyDepartmentInfoParam param)
        {
            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new QueryResult<IList<CompanyDepartmentEntity>>(QueryResultCode.Failed, "抱歉，您无权查询部门列表信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var query = session.QueryOver<CompanyDepartmentEntity>();

                query.WhereIfNotNull(param.Fid, x => x.Fid == param.Fid);
                query.WhereIfNotEmpty(param.DepartmentName, x => x.Fname == param.DepartmentName);

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

                return new QueryResult<IList<CompanyDepartmentEntity>>(retList, rawRowCont, retList.Count);
            }
        }



        /// <summary>
        /// 增加部门信息
        /// </summary>
        /// <param name="newRelation"></param>
        /// <returns></returns>
        public BaseOpResult AddDepartmentInfo(CompanyDepartmentEntity newDepartment)
        {
            newDepartment.IsValid();

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权新增部门信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var queryResult = session.QueryOver<CompanyDepartmentEntity>()
                    .Where(x => x.Fname == newDepartment.Fname).SingleOrDefault();

                if (null != queryResult) return new BaseOpResult(QueryResultCode.Failed, $"抱歉，\"{newDepartment.Fname}\" 部门已经存在，请重新输入");

                newDepartment.Fid = 0;
                newDepartment.Fcreate_time = DateTime.Now;
                var trans = session.BeginTransaction();
                try
                {
                    session.Save(newDepartment);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"添加新部门失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="relationInfo"></param>
        /// <returns></returns>
        public BaseOpResult DelDepartmentInfo(CompanyDepartmentEntity delDepartment)
        {
            // 可以通过名称或ID删除部门
            if (0 == delDepartment.Fid && delDepartment.Fname.NullOrEmpty()) return new BaseOpResult(QueryResultCode.Failed, "抱歉，删除部门信息参数有误，ID和名称必须填写最少一个值");

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权删除部门信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var dbQuery = session.QueryOver<CompanyDepartmentEntity>();
                dbQuery.WhereIfNotEmpty(delDepartment.Fname, x => x.Fname == delDepartment.Fname);
                dbQuery.WhereIf(delDepartment.Fid != 0, x => x.Fid == delDepartment.Fid);

                var queryResult = dbQuery.SingleOrDefault();
                if (null == queryResult) return new BaseOpResult(QueryResultCode.Failed, "该部门信息不存在或已被删除");

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
                    return new BaseOpResult(QueryResultCode.Failed, $"删除部门信息失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="updateDepartment"></param>
        /// <returns></returns>
        public BaseOpResult UpdateDepartmentInfo(CompanyDepartmentEntity updateDepartment)
        {
            // 只可通过ID修改部门
            if (0 == updateDepartment.Fid) return new BaseOpResult(QueryResultCode.Failed, "抱歉，更新部门信息参数有误，ID和姓名必须填写最少一个值");

            if (!CanUserDo(MethodBase.GetCurrentMethod().Name))
                return new BaseOpResult(QueryResultCode.Failed, "抱歉，您无权更新部门信息");

            using (var session = NHibernateSessionManager.GetSession())
            {
                var dbQuery = session.QueryOver<CompanyDepartmentEntity>();
                dbQuery.WhereIf(updateDepartment.Fid != 0, x => x.Fid == updateDepartment.Fid);
                var authInfoInDb = dbQuery.SingleOrDefault();

                if (null == authInfoInDb) return new BaseOpResult(QueryResultCode.Failed, "该部门信息不存在或已被删除");

                var trans = session.BeginTransaction();
                try
                {
                    updateDepartment.Fid = authInfoInDb.Fid;
                    session.Merge(updateDepartment);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, $"更新部门信息失败，原因：${ex.Message}");
                }
                session.Flush();
            }

            return BaseOpResult.SucceedInstance;
        }

    }
}
