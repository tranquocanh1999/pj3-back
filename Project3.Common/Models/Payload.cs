using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Common.Models
{
    /// <summary>
    /// Dữ liệu cần filter của hóa đơn
    /// </summary>
 
    public class Payload
    {
        /// <summary>
        /// số bản ghi trên 1 trang
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// vị trí bắt đầu lọc
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// </summary>
        public string Param { get; set; }


        /// <summary>
        /// lọc cơ bản
        /// </summary>
        public List<Filter> Filter { get; set; }

  
    }
}
