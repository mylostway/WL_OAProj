using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.entity;

namespace WL_OA.Data.dto
{
    public class GoodsInfoForSelData
    {
        public GoodsInfoForSelData() { }

        public GoodsInfoForSelData(GoodsinfoEntity entity)
        {
            if (null == entity) return;
            this.Fname = entity.Fchn_Name;
            this.Fmark = entity.Fmark;
        }

        public string Fname { get; set; } = "";

        public string Fmark { get; set; } = "";


        public static IList<GoodsInfoForSelData> ConvFrom(IList<GoodsinfoEntity> entityList)
        {
            var retList = new List<GoodsInfoForSelData>();
            if (null == entityList || 0 == entityList.Count) return retList;
            foreach(var e in entityList)
            {
                retList.Add(new GoodsInfoForSelData(e));
            }
            return retList;
        }
    }
}
