using System;
using System.Collections.Generic;

namespace MISA.CukCuk08.Models
{
    public partial class Customer
    {

        /// <summary>
        /// Mã định danh khách hàng
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// Tên khách hàng khách hàng
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Ngày sinh khách hàng
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string Taxcode { get; set; }
        /// <summary>
        /// Số nợ 
        /// </summary>
        public decimal? DebitAmount { get; set; }
        /// <summary>
        /// Thành viên 5Food
        /// </summary>
        public bool? Is5FoodMember { get; set; }
        /// <summary>
        /// Mã Thành viên
        /// </summary>
        public string MemberCode { get; set; }
        /// <summary>
        /// Mã nhóm Thành viên
        /// </summary>
        public string GroupCustomer { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Avatar khách hàng
        /// </summary>
        public string Image { get; set; }
    }
}
