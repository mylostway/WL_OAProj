using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using NHibernate.Criterion;

using WL_OA.Data.dto;
using WL_OA.Data.entity;

namespace WL_OA.Data
{
    public static class DBEx
    {
        /// <summary>
        /// 增加一个列表，传入已经开启事务的session（相当于封装一个简便函数而已）
        /// </summary>
        /// <param name="entityList"></param>
        public static BaseOpResult AddEntityListEx<T>(this ISession session, IList<T> entityList, bool bIsAutomic = false)
            where T : BaseEntity<int>, new()
        {
            if (null == entityList || 0 == entityList.Count) return new BaseOpResult();

            try
            {
                foreach (var e in entityList)
                {
                    try
                    {
                        e.IsValid();

                        var id = session.Save(e);
                    }
                    catch (Exception ex)
                    {
                        if (bIsAutomic)
                        {
                            throw ex;
                        }
                    }
                }

                /*
                foreach (var e in entityList)
                {
                    ChloeUtil.DbContext.Insert(e);
                }
                */
            }
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            return BaseOpResult.SucceedInstance;
        }
    }
}
