 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk08.Models
{
    public class Employee
    {

        Employee()
        {
            this.EmployeeId = Guid.NewGuid();
            
        }
        /// <summary>
        /// Id nhân viên GUID - char(36)
        /// </summary>
        /// 
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// 
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Năm sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính 
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// CMND Hộ chiếu
        /// </summary>
        public string Passport { get; set; }
        /// <summary>
        /// Ngày Cấp
        /// </summary>
        public DateTime? IssuedDate { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IssuedBy { get; set; }
        /// <summary>
        /// Vị trí
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Phòng ban
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string TaxCode { get; set; }
        /// <summary>
        /// Mức lương
        /// </summary>
        public decimal? Salary { get; set; }
        /// <summary>
        /// Ngày tham gia
        /// </summary>
        public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Đường dẫn ảnh
        /// </summary>
        public string ImageUrl{ get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
