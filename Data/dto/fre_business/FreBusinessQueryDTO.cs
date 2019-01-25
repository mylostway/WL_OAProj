using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.dto.fre_business
{
    public class FreBusinessQueryDTO
    {
        /// <summary>
        /// 工作单号
        /// </summary>
        public string Fwork_id { get; set; }

        /// <summary>
        /// 物流状态
        /// </summary>
        public string Fflow_state { get; set; }

        /// <summary>
        /// 托运人'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fconsign_man { get; set; }


        /// <summary>
        /// 起运码头'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fstart_wharf { get; set; }


        /// <summary>
        /// 起运地'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fstart_place { get; set; }



        /// <summary>
        /// 目的地'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fto_place { get; set; }


        /// <summary>
        /// 目的码头'
        /// </summary>
        [Required]
        [MaxLength(30)]
        public virtual string Fto_wharf { get; set; }


        /// <summary>
        /// 业务日期'
        /// </summary>
        public virtual DateTime Fbusiness_date { get; set; }


        /// <summary>
        /// 业务员'
        /// </summary>
        [MaxLength(30)]
        public virtual string Fbusinesser { get; set; }


        /// <summary>
        /// 货名'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fgoods_name { get; set; }



        /// <summary>
        /// 装货地点'
        /// </summary>
        [MaxLength(60)]
        public virtual string Fhold_goods_place { get; set; }


        /// <summary>
        /// 装货联系人'
        /// </summary>
        [MaxLength(20)]
        public virtual string Fhold_goods_people { get; set; }

        /// <summary>
        /// 卸货地点'
        /// </summary>
        [MaxLength(60)]
        public virtual string Flay_goods_place { get; set; }

        /// <summary>
        /// 卸货联系人'
        /// </summary>
        [MaxLength(20)]
        public virtual string Flay_goods_people { get; set; }



        /// <summary>
        /// 操作条款'
        /// </summary>
        [Required]
        [Range((int)FreBusinessTransportTermsEnums.St_St, (int)FreBusinessTransportTermsEnums.Gate_Fgate, ErrorMessage = "非法的操作条款")]
        public virtual int Fop_term { get; set; }


        /// <summary>
        /// 运输条款'
        /// </summary>
        [Required]
        [Range((int)FreBusinessTransportTermsEnums.St_St, (int)FreBusinessTransportTermsEnums.Gate_Fgate, ErrorMessage = "非法的运输条款")]
        public virtual int Ftransit_term { get; set; }


        /// <summary>
        /// 付款方式'
        /// </summary>
        [Required]
        [Range((int)FreBusinessPaymentTypeEnums.None, (int)FreBusinessPaymentTypeEnums.Advance, ErrorMessage = "非法的付款方式")]
        public virtual int Fpay_way { get; set; }



        /// <summary>
        /// 状态
        /// </summary>
        public FreBusinessSearchDtoStatusTypeEnums State { get; set; }


        /// <summary>
        /// 船公司'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fship_company { get; set; }

        /// <summary>
        /// 干线船名'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmain_line_ship_name { get; set; }


        /// <summary>
        /// 干线航次'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmain_line_no { get; set; }


        /// <summary>
        /// 运单号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fship_no { get; set; }



        // FIXME:未完待续
    }
}
