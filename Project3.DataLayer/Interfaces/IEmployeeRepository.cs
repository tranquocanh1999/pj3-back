using Project3.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.DataLayer.Interfaces
{
    /// <summary>
    /// interface cho nhân viên
    /// </summary>
    ///  Created by: TQAnh(16/03/2021)
    public interface IEmployeeRepository : IDbContext<Employee>
    {
    }
}
