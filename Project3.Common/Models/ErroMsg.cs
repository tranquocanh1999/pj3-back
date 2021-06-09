using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Common.Models
{
    /// <summary>
    /// thông tin lỗi 
    /// CreatedBy: Created by: TQAnh(16/03/2021)
    /// </summary>

    public class ErroMsg
    {
        /// <summary>
        /// tin nhắn thông báo cho lập trình viên
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// tin nhắn thông báo cho người dùng
        /// </summary>
        public List<string> UserMsg { get; set; } = new List<string>();

        /// <summary>
        /// mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }

        public string MoreInfo { get; set; }
        public string TraceId { get; set; }
    }
}
