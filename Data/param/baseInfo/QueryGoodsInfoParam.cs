﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WL_OA.Data.param
{
    /// <summary>
    /// 查询货品信息的参数
    /// </summary>
    public class QueryGoodsInfoParam : BaseQueryParam
    {
        public QueryGoodsInfoParam() { }

        public QueryGoodsInfoParam(int? id = null, string name = "", string mark = "")
        {
            this.Fid = id;
            this.FChnName = name;
            Fmark = mark;                
        }

        public int? Fid { get; set; }

        public string FChnName { get; set; }
        
        public string Fmark { get; set; }

        public int? Fusable { get; set; }
    }
}
