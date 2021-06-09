﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Common.Models
{
    public class ServiceResult
    {

        #region Constructor
        public ServiceResult()
        {
            Success = true;
        }
        #endregion

        #region Property
        /// <summary>
        /// Trạng thái Service ( true- thành công; failse - thấy bại)
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// dữ liệu trả về 
        /// </summary>
        public object Data { get; set; }
        public string MISACode { get; set; }

        #endregion
    }
}
