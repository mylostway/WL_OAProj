using System;
using System.Collections.Generic;
using System.Text;

using Data.entity;

namespace Data.dto
{
    /// <summary>
    /// 客户管理信息DTO
    /// </summary>
    public class CustomerInfoDTO
    {
        public CustomerInfoDTO() { }



        /// <summary>
        /// 客户管理信息
        /// </summary>
        public CustomerInfoEntity CustomerInfo { get; set; }

        /// <summary>
        /// 关联联系人
        /// </summary>
        public CustomerContactEntity ContactInfo { get; set; }

        /// <summary>
        /// 装卸地址
        /// </summary>
        public CustomerHoldAddrEntity HoldAddrInfo { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        public CustomerBankAccountEntity BankAccountInfo { get; set; }


        /// <summary>
        /// 订舱收货人
        /// </summary>
        public CustomerBookSpaceReceiverEntity BookSpaceReceiverInfo { get; set; }


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



        /// <summary>
        /// 将这些信息链接到关联的customerId
        /// </summary>
        /// <param name="linkCustomerID">关联的customerId</param>
        public void Linked(int linkCustomerID)
        {
            ContactInfo.FcustomerId = linkCustomerID;
            HoldAddrInfo.FcustomerId = linkCustomerID;
            BankAccountInfo.FcustomerId = linkCustomerID;
            BookSpaceReceiverInfo.FcustomerId = linkCustomerID;
            CreditInfo.FcustomerId = linkCustomerID;
            ConfigInfo.FcustomerId = linkCustomerID;
            OtherInfo.FcustomerId = linkCustomerID;
        }

    }
}
