using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Common.Models
{
    public class Customer
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
        /// Tên nhân viên
        /// </summary>
        public string CustomerName { get; set; }


        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }


        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        /// Giới tính 0-Nam 1-Nữ
        /// </summary>
        public string Gender { get; set; }
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
