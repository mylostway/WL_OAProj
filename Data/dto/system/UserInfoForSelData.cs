using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.entity;

namespace WL_OA.Data.dto
{
    public class UserInfoForSelData
    {
        public UserInfoForSelData() { }

        public UserInfoForSelData(SystemUserEntity entity)
        {
            this.Fname = entity.Fname;
            this.Faccount = entity.Fuser_account;
        }

        public string Fname { get; set; }

        public string Faccount { get; set; }

        public static IList<UserInfoForSelData> ConvFrom(IList<SystemUserEntity> entityList)
        {
            var retList = new List<UserInfoForSelData>();
            if (null == entityList || 0 == entityList.Count) return retList;
            foreach (var e in entityList)
            {
                retList.Add(new UserInfoForSelData(e));
            }
            return retList;
        }
    }
}
