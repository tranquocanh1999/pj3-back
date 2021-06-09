using MiNET.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Common.Models
{

    public class Employee
    {
        #region Constructor
        #endregion

        #region Method

        #endregion

        #region Property 
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string FullName { get; set; }



        /// <summary>
        /// Vị trí công việc 1-Nhân viên 2-Giám đốc 3-Thu ngân
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ảnh đại diện
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính 0-Nam 1-Nữ
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Số chứng minh nhân dân
        /// </summary>
        public string IdentityCardNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public string IssuePlace { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string Taxcode { get; set; }

        /// <summary>
        /// Ngày gia nhập
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// Lương cơ bản
        /// </summary>
        public int BasicSalary { get; set; }

        /// <summary>
        /// Dẫ xóa hay chưa
        /// </summary>
        public string IsDelete { get; set; }
        #endregion

        #region Other

        /// <summary>
        /// Ngày tạo mới 
        /// </summary>
        public DateTime? createDate { get; set; }

        /// <summary>
        /// Người tạo mới
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion

    }
}
