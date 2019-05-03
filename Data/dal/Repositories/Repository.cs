using Chloe;
using Chloe.Annotations;
using Chloe.MySql;
using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.config;
using WL_OA.Data.dal.Chloe;
using WL_OA.Data.dto;
using WL_OA.Data.entity;
using WL_OA.Data.utils;

namespace WL_OA.Data.dal
{
    public abstract class Repository<T>
        where T : BaseEntity<int>
    {
        public Repository()
        {
            var type = typeof(T);

            var tableAttr = type.GetCustomAttributes(typeof(TableAttribute), true);

            if (null == tableAttr || 1 != tableAttr.Length) throw new Exception("实体配置错误，没有找到表特性声明");

            var tabAttr = tableAttr[0] as TableAttribute;

            var tableName = tabAttr.Name;

            SAssert.MustTrue(!string.IsNullOrEmpty(tableName), "实体声明的表特性，表明不能为空");

            var connStr = TableDbMappingConfig.GetDefaultDbConnectionStringOnTableName(tableName);

            DBContext = new MySqlContext(new MySqlConnectionFactory(connStr));
        }

        public IDbContext DBContext { get; protected set; } = null;


        /// <summary>
        /// 根据指定ID获取实例
        /// </summary>
        /// <returns></returns>
        public virtual QueryResult<T> GetEntityById(int id)
        {
            var queryEntity = DBContext.QueryByKey<T>(id);

            return new QueryResult<T>(queryEntity);
        }

        /// <summary>
        /// 增加Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual BaseOpResult AddEntity(T entity)
        {
            try
            {
                entity.IsValid();

                var addedEntity = DBContext.Insert(entity);
            }
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }

            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 增加一个列表
        /// </summary>
        /// <param name="entityList"></param>
        /// <param name="bIsAutomic">是否原子操作（目前仅仅表示，如果批量操作中有一个失败则全部回退，默认false）</param>
        public virtual BaseOpResult AddEntityList(List<T> entityList, bool bIsAutomic = false)
        {
            try
            {
                // 检查实体合法性
                foreach (var e in entityList)
                {
                    try
                    {
                        e.IsValid();
                    }
                    catch (Exception ex)
                    {
                        if (bIsAutomic)
                        {
                            throw ex;
                        }
                    }
                }

                DBContext.Session.BeginTransaction();
                DBContext.InsertRange(entityList);
                DBContext.Session.CommitTransaction();
            }
            catch (Exception ex)
            {
                if (bIsAutomic)
                {
                    if (DBContext.Session.IsInTransaction)
                        DBContext.Session.RollbackTransaction();
                    return new BaseOpResult(QueryResultCode.Failed, ex.Message);
                }                
            }
            return BaseOpResult.SucceedInstance;
        }


        


        /// <summary>
        /// 更新Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual BaseOpResult UpdateEntity(T entity)
        {
            try
            {
                entity.IsValid();
                DBContext.Session.BeginTransaction();
                DBContext.Update(entity);
                DBContext.Session.CommitTransaction();
            }
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 删除Entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual BaseOpResult DelEntity(T entity)
        {
            try
            {
                entity.IsValid();
                DBContext.Session.BeginTransaction();
                DBContext.Delete(entity);
                DBContext.Session.CommitTransaction();
            }
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            return BaseOpResult.SucceedInstance;
        }


        /// <summary>
        /// 软删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual BaseOpResult SoftDelEntity(T entity)
        {
            try
            {
                //entity.IsValid();

                DBContext.Session.BeginTransaction();

                var queryEntity = DBContext.QueryByKey<T>(entity.Fid);

                if (queryEntity.Fstate != 0)
                {
                    queryEntity.Fstate = 0;
                    DBContext.Update(queryEntity);
                    DBContext.Session.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                return new BaseOpResult(QueryResultCode.Failed, ex.Message);
            }
            return BaseOpResult.SucceedInstance;
        }

        
    }
}
