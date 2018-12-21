using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_order_info")]
    public class FreBusinessOrderInfoEntity : BaseEntity<int>
    {
        protected string flist_id = "";
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get { return flist_id; } set { flist_id = value; } }

        protected string fconsign_man = "";
        /// <summary>
        /// 托运人'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fconsign_man { get { return fconsign_man; } set { fconsign_man = value; } }

        protected string fstart_wharf = "";
        /// <summary>
        /// 起运码头'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fstart_wharf { get { return fstart_wharf; } set { fstart_wharf = value; } }

        protected string fstart_place = "";
        /// <summary>
        /// 起运地'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_place { get { return fstart_place; } set { fstart_place = value; } }

        protected string fto_place = "";
        /// <summary>
        /// 目的地'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fto_place { get { return fto_place; } set { fto_place = value; } }

        protected string fto_wharf = "";
        /// <summary>
        /// 目的码头'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fto_wharf { get { return fto_wharf; } set { fto_wharf = value; } }

        protected DateTime fbusiness_date = DateTime.Now;
        /// <summary>
        /// 业务日期'
        /// </summary>
        public virtual DateTime Fbusiness_date { get { return fbusiness_date; } set { fbusiness_date = value; } }

        protected string fbusinesser = "";
        /// <summary>
        /// 业务员'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusinesser { get { return fbusinesser; } set { fbusinesser = value; } }

        protected int fop_term = 0;
        /// <summary>
        /// 操作条款'
        /// </summary>
        [Required]
        [Range((int)FreBusinessTransportTermsEnums.St_St, (int)FreBusinessTransportTermsEnums.Gate_Fgate, ErrorMessage = "非法的操作条款")]
        public virtual int Fop_term { get { return fop_term; } set { fop_term = value; } }

        protected int ftransit_term = 0;
        /// <summary>
        /// 运输条款'
        /// </summary>
        [Required]
        [Range((int)FreBusinessTransportTermsEnums.St_St, (int)FreBusinessTransportTermsEnums.Gate_Fgate, ErrorMessage = "非法的运输条款")]
        public virtual int Ftransit_term { get { return ftransit_term; } set { ftransit_term = value; } }

        protected int fpay_way = 0;
        /// <summary>
        /// 付款方式'
        /// </summary>
        [Required]
        [Range((int)FreBusinessPaymentTypeEnums.None, (int)FreBusinessPaymentTypeEnums.Advance, ErrorMessage = "非法的付款方式")]
        public virtual int Fpay_way { get { return fpay_way; } set { fpay_way = value; } }

        protected string fprotocol_no = "";
        /// <summary>
        /// 协议号'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fprotocol_no { get { return fprotocol_no; } set { fprotocol_no = value; } }

        protected int fassociate_way = 0;
        /// <summary>
        /// 整柜拼箱方式'
        /// </summary>
        [Range((int)FreBusinessFLTypeEnums.None, (int)FreBusinessFLTypeEnums.LCL, ErrorMessage = "非法的整柜拼箱方式")]
        public virtual int Fassociate_way { get { return fassociate_way; } set { fassociate_way = value; } }

        protected string forder_no = "";
        /// <summary>
        /// 委托单号'
        /// </summary>
        [MaxLength(32)]
        public virtual string Forder_no { get { return forder_no; } set { forder_no = value; } }

        protected int fhas_assurance = 0;
        /// <summary>
        /// 是否包含保险，0 - 无，1 - 有'
        /// </summary>
        public virtual int Fhas_assurance { get { return fhas_assurance; } set { fhas_assurance = value; } }

        protected int fchild_bus_type = 0;
        /// <summary>
        /// 业务子类型，0 - 无，目前在网站上没有任何选择
        /// </summary>
        public virtual int Fchild_bus_type { get { return fchild_bus_type; } set { fchild_bus_type = value; } }

        public FreBusinessOrderInfoEntity()
        {
            Fbusiness_date = DateTime.Now;
        }

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
    }
}
