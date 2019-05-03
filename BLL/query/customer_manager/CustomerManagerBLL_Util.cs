using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using WL_OA.Data.entity;
using WL_OA.Data.param;
using WL_OA.Data.dal;
using WL_OA.Data.dto;
using WL_OA.Data.utils;

using BLL.settings;
using BLL.util;

using NHibernate;
using NHibernate.Criterion;
using WL_OA.Data;

namespace WL_OA.BLL.query
{
    public partial class CustomerManagerBLL : CommBaseBLL<CustomerInfoEntity, QueryCustomerInfoParam>
    {
        /// <summary>
        /// 根据复杂的IDType，添加ID的查询条件，因为允许两个查询条件，所以提取出来当方法
        /// </summary>
        /// <param name="enumVal"></param>
        /// <param name="val"></param>
        /// <param name="query"></param>
        private void AddQueryIDTypeCondition(QueryCustomerInfoIDTypeEnums? enumVal, string val, IQueryOver<CustomerInfoEntity, CustomerInfoEntity> query)
        {
            if (!string.IsNullOrEmpty(val))
            {
                switch (enumVal)
                {
                    case null:
                    case QueryCustomerInfoIDTypeEnums.None:
                    case QueryCustomerInfoIDTypeEnums.Forshot:
                        {
                            query.And(c => c.Fname_for_short.Contains(val));
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.FullName:
                        {
                            query.And(c => c.Fname.Contains(val));
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.Remark:
                        {
                            query.And(c => c.Fmark.Contains(val));
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.CustomType:
                        {
                            query.And(c => c.Fcustomer_type == val);
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.Payway:
                        {
                            query.And(c => c.Fpay_way == val);
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.BusinessMan:
                        {
                            query.And(c => c.Fbusinesser.Contains(val));
                            break;
                        }
                    case QueryCustomerInfoIDTypeEnums.Province:
                        {
                            // 这个要关联查询
                            throw new NotImplementedException();
                        }
                }
            }
        }

        /// <summary>
        /// 根据数据状态值添加查询条件
        /// </summary>
        /// <param name="enumVal"></param>
        /// <param name="query"></param>
        private void AddQueryDataStateCondition(QueryCustomerInfoStateEnums? enumVal, IQueryOver<CustomerInfoEntity, CustomerInfoEntity> query)
        {
            if (enumVal == null || enumVal == QueryCustomerInfoStateEnums.None) return;

            switch (enumVal)
            {
                case QueryCustomerInfoStateEnums.Useless:
                    {
                        query.And(c => ((c.Fdata_status & 0x01) == 0));
                        break;
                    }
                case QueryCustomerInfoStateEnums.Usable:
                    {
                        query.And(c => ((c.Fdata_status & 0x01) == 1));
                        break;
                    }
                case QueryCustomerInfoStateEnums.Aduited:
                    {
                        query.And(c => ((c.Fdata_status & 0x02) == 1));
                        break;
                    }
                case QueryCustomerInfoStateEnums.UnAduited:
                    {
                        query.And(c => ((c.Fdata_status & 0x02) == 0));
                        break;
                    }
                case QueryCustomerInfoStateEnums.Shared:
                    {
                        query.And(c => ((c.Fdata_status & 0x04) == 1));
                        break;
                    }
                case QueryCustomerInfoStateEnums.UnShared:
                    {
                        query.And(c => ((c.Fdata_status & 0x04) == 0));
                        break;
                    }
                case QueryCustomerInfoStateEnums.BlackList:
                    {
                        query.And(c => ((c.Fdata_status & 0x08) == 1));
                        break;
                    }
                case QueryCustomerInfoStateEnums.NotBlackList:
                    {
                        query.And(c => ((c.Fdata_status & 0x08) == 0));
                        break;
                    }
                case QueryCustomerInfoStateEnums.ReceivedShortmsg:
                    {
                        query.And(c => ((c.Fdata_status & 0x10) == 1));
                        break;
                    }
                case QueryCustomerInfoStateEnums.NotReceivedShortmsg:
                    {
                        query.And(c => ((c.Fdata_status & 0x10) == 0));
                        break;
                    }
            }
        }


        /// <summary>
        /// 检查更新参数是否合法
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool IsCustomerDTOVaildForUpdate(AddCustomerInfoDTO dto)
        {
            var toUpdateId = dto.CustomerInfo.Fid;
            return dto.IsValid()
                && toUpdateId == dto.CreditInfo.Fcustomer_id
                && toUpdateId == dto.ConfigInfo.Fcustomer_id
                && toUpdateId == dto.OtherInfo.Fcustomer_id;
        }
    }
}
