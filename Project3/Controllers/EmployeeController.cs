using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3.Common.Models;
using Project3.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Api.Controllers
{
    /// <summary>
    /// Controller của nhân viên
    /// </summary>
    /// Created by: TQAnh(16/03/2021)
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        public EmployeesController(IEmployeeService _iEmployeeService) : base(_iEmployeeService)
        {

        }
    }
}
