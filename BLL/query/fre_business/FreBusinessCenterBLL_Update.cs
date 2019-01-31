using WL_OA.Data;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.utils;
using WL_OA.Data.consts;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WL_OA.BLL
{
    public partial class FreBusinessCenterBLL : CommBaseBLL<FreBusinessCenterEntity, QueryFreBusinessCenterParam>
    {        
        /// <summary>
        /// 更新工作单部分信息
        /// </summary>
        /// <returns></returns>
        public BaseOpResult UpdateFreBusinessPartInfo<T>(T updateInfo)
            where T : BaseEntity<int>, IFreBusinessPartInfoEntity
        {
            var opUser = GetRequestContext().LoginInfo.Account;

            using (var session = NHibernateSessionManager.GetSession())
            {
                var srcResult = session.QueryOver<T>().Where(x => x.Flist_id == updateInfo.Flist_id).SingleOrDefault();

                if (null == srcResult)
                {
                    return new BaseOpResult(QueryResultCode.Failed, $"更新委托信息不存在，更新失败，单号{updateInfo.Flist_id}");
                }

                // 检查是否有权限修改数据状态
                var basicInfo = session.QueryOver<FreBusinessBasicInfoEntity>().Where(x => x.Flist_id == updateInfo.Flist_id).SingleOrDefault();

                if (basicInfo.Finputor != opUser
                    && (GetServices<IAssessRight>()?.CanUserDo(opUser, MethodBase.GetCurrentMethod().Name) != true))
                {
                    return new BaseOpResult(QueryResultCode.Failed, $"您无权修改该信息，单号{updateInfo.Flist_id}");
                }

                var trans = session.BeginTransaction();
                try
                {
                    //session.Update(orderInfo);
                    session.Merge(updateInfo);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new BaseOpResult(QueryResultCode.Failed, ex.Message);
                }
                session.Flush();
            }
            return BaseOpResult.SucceedInstance;
        }

    }
}
