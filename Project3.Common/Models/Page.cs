using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Common.Models
{
    /// <summary>
    /// phân trang 
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public class Page<Entity>
    {

        /// <summary>
        /// danh sách thực thể 
        /// </summary>
        public IEnumerable<Entity> Data { get; set; }

        /// <summary>
        /// Tổng số dữ liệu trong database
        /// </summary>
        public int TotalElement { get; set; }

        /// <summary>
        /// số bản ghi trên 1 trang 
        /// </summary>
        public int PageSize { get; set; }


    }
}
