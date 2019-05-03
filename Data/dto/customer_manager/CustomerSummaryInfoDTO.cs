using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WL_OA.Data.entity;

namespace WL_OA.Data.dto
{
    public class CustomerSummaryInfoDTO : CustomerInfoEntity
    {
        public CustomerSummaryInfoDTO() { }

        public CustomerSummaryInfoDTO(CustomerInfoEntity rhs) : base(rhs)
        {
            
        }

        /// <summary>
        /// 关联联系人
        /// </summary>
        public IList<CustomerContactEntity> ContactInfoList { get; set; }

        /// <summary>
        /// 装卸地址
        /// </summary>
        public IList<CustomerHoldAddrEntity> HoldAddrInfoList { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public IList<CustomerBankAccountEntity> BankAccountInfoList { get; set; }

        /// <summary>
        /// 订舱收货人
        /// </summary>
        public IList<CustomerBookSpaceReceiverEntity> BookSpaceReceiverInfoList { get; set; }

        public void Linked(int linkCustomerID)
        {
            if(null != ContactInfoList && ContactInfoList.Count > 0)
            {
                foreach (var e in ContactInfoList) e.Fcustomer_id = linkCustomerID;
            }
            
            if(null != HoldAddrInfoList && HoldAddrInfoList.Count > 0)
            {
                foreach (var e in HoldAddrInfoList) e.Fcustomer_id = linkCustomerID;
            }
            
            if(null != BankAccountInfoList && BankAccountInfoList.Count > 0)
            {
                foreach (var e in BankAccountInfoList) e.Fcustomer_id = linkCustomerID;
            }
            
            if(null != BookSpaceReceiverInfoList && BookSpaceReceiverInfoList.Count > 0)
            {
                foreach (var e in BookSpaceReceiverInfoList) e.Fcustomer_id = linkCustomerID;
            }            
        }


        public override bool IsValid()
        {
            return base.IsValid();
        }
    }
}
