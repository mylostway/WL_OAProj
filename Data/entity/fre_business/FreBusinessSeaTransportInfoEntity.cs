using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_sea_transport_info")]
    public class FreBusinessSeaTransportInfoEntity : BaseEntity<int>, IFreBusinessPartInfoEntity
    {
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get; set; } = "";

        /// <summary>
        /// 订舱代理'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbook_cabint_proxy { get; set; } = "";

        /// <summary>
        /// 船公司'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fship_company { get; set; } = "";

        /// <summary>
        /// 干线船名'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmain_line_ship_name { get; set; } = "";

        /// <summary>
        /// 干线航次'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmain_line_no { get; set; } = "";

        /// <summary>
        /// 运单号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fship_no { get; set; } = "";

        /// <summary>
        /// 预开船期'
        /// </summary>
        public virtual DateTime? Fship_go_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 预到船期'
        /// </summary>
        public virtual DateTime? Fship_reach_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 预报船期'
        /// </summary>
        public virtual DateTime? Fship_report_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 预计到达日期'
        /// </summary>
        public virtual DateTime? Fpredit_reach_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 订舱委托人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbook_order_man { get; set; } = "";

        /// <summary>
        /// 订舱收货人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbook_recv_man { get; set; } = "";

        /// <summary>
        /// 驳船公司'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcarft_ship_company { get; set; } = "";

        /// <summary>
        /// 支线船名'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbranch_ship_name { get; set; } = "";

        /// <summary>
        /// 支线航次'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbranch_ship_no { get; set; } = "";

        /// <summary>
        /// 中转船到期'
        /// </summary>
        public virtual DateTime? Ftransfer_ship_reach_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 中转开船期'
        /// </summary>
        public virtual DateTime? Ftransfer_ship_go_date { get; set; } = default(DateTime?);

        /// <summary>
        /// 三程船名'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ftriple_pass_way { get; set; } = "";

        /// <summary>
        /// 三程航次'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ftriple_pass_ship_no { get; set; } = "";

        /// <summary>
        /// 中转开船期2'
        /// </summary>
        public virtual DateTime? Ftransfer_ship_go_date2 { get; set; } = default(DateTime?);

        /// <summary>
        /// 是否转船,0 - 否，1 - 是，默认0'
        /// </summary>
        public virtual int? Fis_transfer_ship { get; set; } = 0;

        /// <summary>
        /// 航线中文'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fline_chn_name { get; set; } = "";

        /// <summary>
        /// 是否干线车,0 - 否，1 - 是，默认0'
        /// </summary>
        public virtual int? Fis_main_line_car { get; set; } = 0;

        /// <summary>
        /// 中转船到期2'
        /// </summary>
        public virtual DateTime? Ftransfer_ship_reach_date2 { get; set; } = default(DateTime?);

        /// <summary>
        /// 中转码头'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ftransfer_ship_wharf { get; set; } = "";

        /// <summary>
        /// 中转码头2'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ftransfer_ship_wharf2 { get; set; } = "";

        /// <summary>
        /// 驳船信息'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcarft_ship_info_way { get; set; } = "";

        /// <summary>
        /// 头程上船期
        /// </summary>
        public virtual DateTime? Ffirst_ship_get_date { get; set; } = default(DateTime?);

        public FreBusinessSeaTransportInfoEntity() { }

        public FreBusinessSeaTransportInfoEntity(FreBusinessSeaTransportInfoEntity rhs)
        {
            if (null == rhs) return;
            this.Fid = rhs.Fid;
            this.Fstate = rhs.Fstate;
            this.Flist_id = rhs.Flist_id;
            this.Fbook_cabint_proxy = rhs.Fbook_cabint_proxy;
            this.Fship_company = rhs.Fship_company;
            this.Fmain_line_ship_name = rhs.Fmain_line_ship_name;
            this.Fmain_line_no = rhs.Fmain_line_no;
            this.Fship_no = rhs.Fship_no;
            this.Fship_go_date = rhs.Fship_go_date;
            this.Fship_reach_date = rhs.Fship_reach_date;
            this.Fship_report_date = rhs.Fship_report_date;
            this.Fpredit_reach_date = rhs.Fpredit_reach_date;
            this.Fbook_order_man = rhs.Fbook_order_man;
            this.Fbook_recv_man = rhs.Fbook_recv_man;
            this.Fcarft_ship_company = rhs.Fcarft_ship_company;
            this.Fbranch_ship_name = rhs.Fbranch_ship_name;
            this.Fbranch_ship_no = rhs.Fbranch_ship_no;
            this.Ftransfer_ship_reach_date = rhs.Ftransfer_ship_reach_date;
            this.Ftransfer_ship_go_date = rhs.Ftransfer_ship_go_date;
            this.Ftriple_pass_way = rhs.Ftriple_pass_way;
            this.Ftriple_pass_ship_no = rhs.Ftriple_pass_ship_no;
            this.Ftransfer_ship_go_date2 = rhs.Ftransfer_ship_go_date2;
            this.Fis_transfer_ship = rhs.Fis_transfer_ship;
            this.Fline_chn_name = rhs.Fline_chn_name;
            this.Fis_main_line_car = rhs.Fis_main_line_car;
            this.Ftransfer_ship_reach_date2 = rhs.Ftransfer_ship_reach_date2;
            this.Ftransfer_ship_wharf = rhs.Ftransfer_ship_wharf;
            this.Ftransfer_ship_wharf2 = rhs.Ftransfer_ship_wharf2;
            this.Fcarft_ship_info_way = rhs.Fcarft_ship_info_way;
            this.Ffirst_ship_get_date = rhs.Ffirst_ship_get_date;
        }

        public static bool operator ==(FreBusinessSeaTransportInfoEntity lhs, FreBusinessSeaTransportInfoEntity rhs)
        {
            if (Object.ReferenceEquals(lhs, null) && !Object.ReferenceEquals(rhs, null)) return false;
            if (!Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return false;
            if (Object.ReferenceEquals(lhs, null) && Object.ReferenceEquals(rhs, null)) return true;
            return (
               lhs.Fid == rhs.Fid &&
               lhs.Fstate == rhs.Fstate &&
               lhs.Flist_id == rhs.Flist_id &&
               lhs.Fbook_cabint_proxy == rhs.Fbook_cabint_proxy &&
               lhs.Fship_company == rhs.Fship_company &&
               lhs.Fmain_line_ship_name == rhs.Fmain_line_ship_name &&
               lhs.Fmain_line_no == rhs.Fmain_line_no &&
               lhs.Fship_no == rhs.Fship_no &&
               lhs.Fship_go_date == rhs.Fship_go_date &&
               lhs.Fship_reach_date == rhs.Fship_reach_date &&
               lhs.Fship_report_date == rhs.Fship_report_date &&
               lhs.Fpredit_reach_date == rhs.Fpredit_reach_date &&
               lhs.Fbook_order_man == rhs.Fbook_order_man &&
               lhs.Fbook_recv_man == rhs.Fbook_recv_man &&
               lhs.Fcarft_ship_company == rhs.Fcarft_ship_company &&
               lhs.Fbranch_ship_name == rhs.Fbranch_ship_name &&
               lhs.Fbranch_ship_no == rhs.Fbranch_ship_no &&
               lhs.Ftransfer_ship_reach_date == rhs.Ftransfer_ship_reach_date &&
               lhs.Ftransfer_ship_go_date == rhs.Ftransfer_ship_go_date &&
               lhs.Ftriple_pass_way == rhs.Ftriple_pass_way &&
               lhs.Ftriple_pass_ship_no == rhs.Ftriple_pass_ship_no &&
               lhs.Ftransfer_ship_go_date2 == rhs.Ftransfer_ship_go_date2 &&
               lhs.Fis_transfer_ship == rhs.Fis_transfer_ship &&
               lhs.Fline_chn_name == rhs.Fline_chn_name &&
               lhs.Fis_main_line_car == rhs.Fis_main_line_car &&
               lhs.Ftransfer_ship_reach_date2 == rhs.Ftransfer_ship_reach_date2 &&
               lhs.Ftransfer_ship_wharf == rhs.Ftransfer_ship_wharf &&
               lhs.Ftransfer_ship_wharf2 == rhs.Ftransfer_ship_wharf2 &&
               lhs.Fcarft_ship_info_way == rhs.Fcarft_ship_info_way &&
               lhs.Ffirst_ship_get_date == rhs.Ffirst_ship_get_date
           );
        }

        public static bool operator !=(FreBusinessSeaTransportInfoEntity lhs, FreBusinessSeaTransportInfoEntity rhs)
        {
            return !(lhs == rhs);
        }
    }
}
