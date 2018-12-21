using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WL_OA.Data.entity
{
    [Table("t_fre_business_sea_transport_info")]
    public class FreBusinessSeaTransportInfoEntity : BaseEntity<int>
    {
        protected string flist_id = "";
        /// <summary>
        /// 关联的交易单号'
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string Flist_id { get { return flist_id; } set { flist_id = value; } }

        protected string fbook_cabint_proxy = "";
        /// <summary>
        /// 订舱代理'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbook_cabint_proxy { get { return fbook_cabint_proxy; } set { fbook_cabint_proxy = value; } }

        protected string fship_company = "";
        /// <summary>
        /// 船公司'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fship_company { get { return fship_company; } set { fship_company = value; } }

        protected string fmain_line_ship_name = "";
        /// <summary>
        /// 干线船名'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmain_line_ship_name { get { return fmain_line_ship_name; } set { fmain_line_ship_name = value; } }

        protected string fmain_line_no = "";
        /// <summary>
        /// 干线航次'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fmain_line_no { get { return fmain_line_no; } set { fmain_line_no = value; } }

        protected string fship_no = "";
        /// <summary>
        /// 运单号'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fship_no { get { return fship_no; } set { fship_no = value; } }

        protected DateTime fship_go_date = DateTime.Now;
        /// <summary>
        /// 预开船期'
        /// </summary>
        public virtual DateTime Fship_go_date { get { return fship_go_date; } set { fship_go_date = value; } }

        protected DateTime fship_reach_date = DateTime.Now;
        /// <summary>
        /// 预到船期'
        /// </summary>
        public virtual DateTime Fship_reach_date { get { return fship_reach_date; } set { fship_reach_date = value; } }

        protected DateTime fship_report_date = DateTime.Now;
        /// <summary>
        /// 预报船期'
        /// </summary>
        public virtual DateTime Fship_report_date { get { return fship_report_date; } set { fship_report_date = value; } }

        protected DateTime fpredit_reach_date = DateTime.Now;
        /// <summary>
        /// 预计到达日期'
        /// </summary>
        public virtual DateTime Fpredit_reach_date { get { return fpredit_reach_date; } set { fpredit_reach_date = value; } }

        protected string fbook_order_man = "";
        /// <summary>
        /// 订舱委托人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbook_order_man { get { return fbook_order_man; } set { fbook_order_man = value; } }

        protected string fbook_recv_man = "";
        /// <summary>
        /// 订舱收货人'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbook_recv_man { get { return fbook_recv_man; } set { fbook_recv_man = value; } }

        protected string fcarft_ship_company = "";
        /// <summary>
        /// 驳船公司'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fcarft_ship_company { get { return fcarft_ship_company; } set { fcarft_ship_company = value; } }

        protected string fbranch_ship_name = "";
        /// <summary>
        /// 支线船名'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbranch_ship_name { get { return fbranch_ship_name; } set { fbranch_ship_name = value; } }

        protected string fbranch_ship_no = "";
        /// <summary>
        /// 支线航次'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fbranch_ship_no { get { return fbranch_ship_no; } set { fbranch_ship_no = value; } }

        protected DateTime ftransfer_ship_reach_date = DateTime.Now;
        /// <summary>
        /// 中转船到期'
        /// </summary>
        public virtual DateTime Ftransfer_ship_reach_date { get { return ftransfer_ship_reach_date; } set { ftransfer_ship_reach_date = value; } }

        protected DateTime ftransfer_ship_go_date = DateTime.Now;
        /// <summary>
        /// 中转开船期'
        /// </summary>
        public virtual DateTime Ftransfer_ship_go_date { get { return ftransfer_ship_go_date; } set { ftransfer_ship_go_date = value; } }

        protected string ftriple_pass_way = "";
        /// <summary>
        /// 三程船名'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ftriple_pass_way { get { return ftriple_pass_way; } set { ftriple_pass_way = value; } }

        protected string ftriple_pass_ship_no = "";
        /// <summary>
        /// 三程航次'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ftriple_pass_ship_no { get { return ftriple_pass_ship_no; } set { ftriple_pass_ship_no = value; } }

        protected DateTime ftransfer_ship_go_date2 = DateTime.Now;
        /// <summary>
        /// 中转开船期2'
        /// </summary>
        public virtual DateTime Ftransfer_ship_go_date2 { get { return ftransfer_ship_go_date2; } set { ftransfer_ship_go_date2 = value; } }

        protected int fis_transfer_ship = 0;
        /// <summary>
        /// 是否转船,0 - 否，1 - 是，默认0'
        /// </summary>
        public virtual int Fis_transfer_ship { get { return fis_transfer_ship; } set { fis_transfer_ship = value; } }

        protected string fline_chn_name = "";
        /// <summary>
        /// 航线中文'
        /// </summary>
        [MaxLength(50)]
        public virtual string Fline_chn_name { get { return fline_chn_name; } set { fline_chn_name = value; } }

        protected int fis_main_line_car = 0;
        /// <summary>
        /// 是否干线车,0 - 否，1 - 是，默认0'
        /// </summary>
        public virtual int Fis_main_line_car { get { return fis_main_line_car; } set { fis_main_line_car = value; } }

        protected DateTime ftransfer_ship_reach_date2 = DateTime.Now;
        /// <summary>
        /// 中转船到期2'
        /// </summary>
        public virtual DateTime Ftransfer_ship_reach_date2 { get { return ftransfer_ship_reach_date2; } set { ftransfer_ship_reach_date2 = value; } }

        protected string ftransfer_ship_wharf = "";
        /// <summary>
        /// 中转码头'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ftransfer_ship_wharf { get { return ftransfer_ship_wharf; } set { ftransfer_ship_wharf = value; } }

        protected string ftransfer_ship_wharf2 = "";
        /// <summary>
        /// 中转码头2'
        /// </summary>
        [MaxLength(50)]
        public virtual string Ftransfer_ship_wharf2 { get { return ftransfer_ship_wharf2; } set { ftransfer_ship_wharf2 = value; } }

        protected int fcarft_ship_info_way = 0;
        /// <summary>
        /// 驳船信息'
        /// </summary>
        [MaxLength(50)]
        [Range((int)FreBusinessBargeInformationEnums.None, (int)FreBusinessBargeInformationEnums.Intelligence, ErrorMessage = "非法的驳船信息")]
        public virtual int Fcarft_ship_info_way { get { return fcarft_ship_info_way; } set { fcarft_ship_info_way = value; } }

        protected DateTime ffirst_ship_get_date = DateTime.Now;
        /// <summary>
        /// 头程上船期'
        /// </summary>
        public virtual DateTime Ffirst_ship_get_date { get { return ffirst_ship_get_date; } set { ffirst_ship_get_date = value; } }

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
    }
}
