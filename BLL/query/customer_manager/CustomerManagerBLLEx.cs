using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Criterion;

using WL_OA.Data;
using WL_OA.Data.dto;
using WL_OA.Data.entity;

namespace WL_OA.BLL.query
{
    public static class CustomerManagerBLLEx
    {
        /// <summary>
        /// 更新客户信息子列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="dtoList"></param>
        /// <param name="dbList"></param>
        /// <returns></returns>
        public static bool UpdateCustomerInfoChildList<T>(this ISession session, IList<T> dtoList, IList<T> dbList)
            where T : BaseEntity<int>,  IComparable<T>, new()
        {
            try
            {
                if (dbList.IsNullOrEmpty())
                {
                    if (!dtoList.IsNullOrEmpty())
                    {
                        // 原先没有，现在加入，全量添加
                        session.AddEntityListEx(dtoList);
                    }
                }
                else
                {
                    if (!dtoList.IsNullOrEmpty())
                    {
                        // 原先有，现在有更新，则遍历检查，并更新
                        for (var i = 0; i < dtoList.Count; i++)
                        {
                            var curData = dtoList[i];
                            if (curData.Fid == 0)
                            {
                                // 新增数据
                                session.Save(curData);
                            }
                            else
                            {
                                // 更新数据
                                var toUpdateEntity = dbList.SingleOrDefault(x => x.Fid == curData.Fid);
                                if (null == toUpdateEntity)
                                {
                                    // 没有找到要更新的数据，目前暂定新增
                                    curData.Fid = 0;
                                    session.Save(curData);
                                }
                                else
                                {
                                    // 找到更新的数据
                                    if (toUpdateEntity.CompareTo(curData) != 0)
                                    {
                                        session.Update(curData);
                                    }
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }
    }
}
