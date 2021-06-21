using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Common.Models
{
    public class Bill
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
        public string BillCode { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public Guid CustomerID { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// trạng thái đơn hàng
        /// </summary>
        public string Status { get; set; }


        /// <summary>
        /// Mô tả đơn hàng
        /// </summary>
        public string Description { get; set; }

        public long Amount { get; set; }

        /// <summary>
        /// giá nhập
        /// </summary>
        public long Promotion { get; set; }

        /// <summary>
        ///Số lượng trong kho
        /// </summary>
        public string Product { get; set; }

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
