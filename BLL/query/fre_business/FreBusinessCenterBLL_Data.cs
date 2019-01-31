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
        /// 工作单信息关联的所有数据表
        /// </summary>
        static readonly string[] FreBusinessTables = {
            "t_fre_business_basic_info",
            "t_fre_business_order_info",
            "t_fre_business_hold_goods_info",
            "t_fre_business_lay_goods_info",
            "t_fre_business_contains_info",
            "t_fre_business_sea_transport_info",
            "t_fre_business_assurance_info",
            "t_fre_business_matter_info",
            "t_fre_business_operation_info",
            "t_fre_business_other_info",
        };


    }
}
