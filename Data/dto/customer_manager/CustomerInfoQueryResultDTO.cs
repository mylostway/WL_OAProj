using System;
using System.Collections.Generic;
using System.Text;
using WL_OA.Data.entity;

namespace WL_OA.Data.dto
{
    public class CustomerInfoQueryResultDTO : CustomerInfoEntity
    {
        public CustomerInfoQueryResultDTO() { }

        public CustomerInfoQueryResultDTO(CustomerInfoEntity rhs)
            :base(rhs)
        {
            //IsUsable = ((rhs.FdataStatus & 0x02) > 1).ToYesNoStr();
            IsUsable = ((rhs.FdataStatus & 0x02) > 1);
        }

        /// <summary>
        /// 英文全称
        /// </summary>
        public string EngFullName { get; set; }


        public string EngAddr { get; set; }


        public string WebSite { get; set; }


        public string Email { get; set; }


        /// <summary>
        /// 是否白名单车队
        /// </summary>
        public bool IsWhitelist { get; set; } 

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsUsable { get; set; }

    }
}
