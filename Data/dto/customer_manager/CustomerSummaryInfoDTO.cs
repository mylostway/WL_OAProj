using System;
using System.Collections.Generic;
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
            foreach(var e in ContactInfoList)
            {
                e.FcustomerId = linkCustomerID;
            }

            foreach (var e in HoldAddrInfoList)
            {
                e.FcustomerId = linkCustomerID;
            }

            foreach (var e in BankAccountInfoList)
            {
                e.FcustomerId = linkCustomerID;
            }

            foreach (var e in BookSpaceReceiverInfoList)
            {
                e.FcustomerId = linkCustomerID;
            }
        }
    }
}
