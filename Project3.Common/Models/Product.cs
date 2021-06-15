using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Common.Models
{
    public class Product
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
        public string ProductCode { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }



        /// <summary>
        /// loại sản phẩm
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>

        public string Image { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>


        /// <summary>
        /// Giá nám
        /// </summary>
        public int PriceOut { get; set; }

        /// <summary>
        /// giá nhập
        /// </summary>
        public int PriceIn { get; set; }

        /// <summary>
        ///Số lượng trong kho
        /// </summary>
        public int Quantity { get; set; }

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
