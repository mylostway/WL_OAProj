using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_order_info")]
    public class FreBusinessOrderInfoEntity : BaseEntity<int>, IFreBusinessPartInfoEntity
    {
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get; set; } = "";

        /// <summary>
        /// 托运人'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fconsign_man { get; set; } = "";

        /// <summary>
        /// 起运码头'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fstart_wharf { get; set; } = "";

        /// <summary>
        /// 起运地'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_place { get; set; } = "";

        /// <summary>
        /// 目的地'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fto_place { get; set; } = "";

        /// <summary>
        /// 目的码头'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fto_wharf { get; set; } = "";

        /// <summary>
        /// 业务日期'
        /// </summary>
        public virtual DateTime? Fbusiness_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 业务员'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusinesser { get; set; } = "";

        /// <summary>
        /// 操作条款'
        /// </summary>
        [Required]
        [MaxLength(60)]
        public virtual string Fop_term { get; set; } = "";

        /// <summary>
        /// 运输条款'
        /// </summary>
        [Required]
        [MaxLength(60)]
        public virtual string Ftransit_term { get; set; } = "";

        /// <summary>
        /// 付款方式'
        /// </summary>
        [Required]
        [MaxLength(60)]
        public virtual string Fpay_way { get; set; } = "";

        /// <summary>
        /// 协议号'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fprotocol_no { get; set; } = "";

        /// <summary>
        /// 整柜拼箱方式'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fassociate_way { get; set; } = "";

        /// <summary>
        /// 委托单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Forder_no { get; set; } = "";

        /// <summary>
        /// 是否包含保险，0 - 无，1 - 有'
        /// </summary>
        [Range(0, 1, ErrorMessage = "非法的是否包含保险字段")]
        public virtual int? Fhas_assurance { get; set; } = 0;

        /// <summary>
        /// 业务子类型，0 - 无，目前在网站上没有任何选择
        /// </summary>
        [Range(0, 127, ErrorMessage = "非法的业务子类型")]
        public virtual int? Fchild_bus_type { get; set; } = 0;

        public FreBusinessOrderInfoEntity() { }

        public FreBusinessOrderInfoEntity(FreBusinessOrderInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Flist_id = rhs.Flist_id;
            this.Fconsign_man = rhs.Fconsign_man;
            this.Fstart_wharf = rhs.Fstart_wharf;
            this.Fstart_place = rhs.Fstart_place;
            this.Fto_place = rhs.Fto_place;
            this.Fto_wharf = rhs.Fto_wharf;
            this.Fbusiness_date = rhs.Fbusiness_date;
            this.Fbusinesser = rhs.Fbusinesser;
            this.Fop_term = rhs.Fop_term;
            this.Ftransit_term = rhs.Ftransit_term;
            this.Fpay_way = rhs.Fpay_way;
            this.Fprotocol_no = rhs.Fprotocol_no;
            this.Fassociate_way = rhs.Fassociate_way;
            this.Forder_no = rhs.Forder_no;
            this.Fhas_assurance = rhs.Fhas_assurance;
            this.Fchild_bus_type = rhs.Fchild_bus_type;
        }



        public static bool operator ==(FreBusinessOrderInfoEntity lhs, FreBusinessOrderInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Flist_id == rhs.Flist_id &&
               lhs.Fconsign_man == rhs.Fconsign_man &&
               lhs.Fstart_wharf == rhs.Fstart_wharf &&
               lhs.Fstart_place == rhs.Fstart_place &&
               lhs.Fto_place == rhs.Fto_place &&
               lhs.Fto_wharf == rhs.Fto_wharf &&
               lhs.Fbusiness_date == rhs.Fbusiness_date &&
               lhs.Fbusinesser == rhs.Fbusinesser &&
               lhs.Fop_term == rhs.Fop_term &&
               lhs.Ftransit_term == rhs.Ftransit_term &&
               lhs.Fpay_way == rhs.Fpay_way &&
               lhs.Fprotocol_no == rhs.Fprotocol_no &&
               lhs.Fassociate_way == rhs.Fassociate_way &&
               lhs.Forder_no == rhs.Forder_no &&
               lhs.Fhas_assurance == rhs.Fhas_assurance &&
               lhs.Fchild_bus_type == rhs.Fchild_bus_type
           );
        }

        public static bool operator !=(FreBusinessOrderInfoEntity lhs, FreBusinessOrderInfoEntity rhs)
        {
            return !(lhs == rhs);
        }


        
    }
}
