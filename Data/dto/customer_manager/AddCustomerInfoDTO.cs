using System;
using System.Collections.Generic;
using System.Text;

using WL_OA.Data.entity;

namespace WL_OA.Data.dto
{
    /// <summary>
    /// 客户管理信息DTO
    /// </summary>
    public class CustomerInfoDTO : IDataValidator
    {
        public CustomerInfoDTO() { }


        /// <summary>
        /// 客户管理信息
        /// </summary>
        public CustomerSummaryInfoDTO CustomerInfo { get; set; }


        /// <summary>
        /// 资信信息
        /// </summary>
        public CustomerCreditInfoEntity CreditInfo { get; set; }



        /// <summary>
        /// 配置信息
        /// </summary>
        public CustomerConfigInfoEntity ConfigInfo { get; set; }


        /// <summary>
        /// 其他信息
        /// </summary>
        public CustomerOtherInfoEntity OtherInfo { get; set; }

        public bool IsValid()
        {
            return CustomerInfo.IsValid()
                && CreditInfo.IsValid()
                && CreditInfo.IsValid()
                && OtherInfo.IsValid();
        }



        /// <summary>
        /// 将这些信息链接到关联的customerId
        /// </summary>
        /// <param name="linkCustomerID">关联的customerId</param>
        public void Linked(int linkCustomerID)
        {
            /*
            ContactInfo.FcustomerId = linkCustomerID;
            HoldAddrInfo.FcustomerId = linkCustomerID;
            BankAccountInfo.FcustomerId = linkCustomerID;
            BookSpaceReceiverInfo.FcustomerId = linkCustomerID;
            */
            CustomerInfo.Linked(linkCustomerID);
            CreditInfo.FcustomerId = linkCustomerID;
            ConfigInfo.FcustomerId = linkCustomerID;
            OtherInfo.FcustomerId = linkCustomerID;
        }



    }
}
