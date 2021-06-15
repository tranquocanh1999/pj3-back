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

        protected IAuthenticationService _authenticationService;
        public EmployeesController(IEmployeeService _iEmployeeService, IAuthenticationService iAuthenticationService) : base(_iEmployeeService)
        {
            _authenticationService = iAuthenticationService;

        }


        [HttpGet("login")]
        public IActionResult Login([FromQuery] string email, [FromQuery] string password)
        {


            try
            {
                var serviceResult = _authenticationService.Login(email, password);
                if (!serviceResult.Success)
                {
                    var erroMsg = new ErroMsg();
                    erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.Login_Err_Msg);
                    serviceResult.Data = erroMsg;
                    return StatusCode(400, serviceResult.Data);
                }
                return StatusCode(200, serviceResult.Data);
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;
                return StatusCode(500, serviceResult.Data);
            }
        }

        [HttpGet("changePass")]
        public IActionResult ChangePass([FromQuery] string email, [FromQuery] string oldPass, [FromQuery] string newPass)
        {


            try
            {
                var serviceResult = _authenticationService.ChangePass(email, oldPass, newPass);
                if (!serviceResult.Success)
                {
                    var erroMsg = new ErroMsg();
                    erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.ChangePass_Err_Msg);
                    serviceResult.Data = erroMsg;
                    return StatusCode(400, serviceResult.Data);
                }
                return StatusCode(200, serviceResult.Data);
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;
                return StatusCode(500, serviceResult.Data);
            }
        }

        [HttpGet("forgotPassword")]
        public IActionResult ForgotPassword([FromQuery] string email)
        {


            try
            {
                var serviceResult = _authenticationService.ForgotPassword(email);
                if (!serviceResult.Success)
                {
                    var erroMsg = new ErroMsg();
                    erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.ChangePass_Err_Msg);
                    serviceResult.Data = erroMsg;
                    return StatusCode(400, serviceResult.Data);
                }
                return StatusCode(200, serviceResult.Data);
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                var erroMsg = new ErroMsg();
                erroMsg.UserMsg.Add(Project3.Common.Properties.Resource.UserMsg_Exception);
                erroMsg.DevMsg = ex.ToString();
                serviceResult.Data = erroMsg;
                return StatusCode(500, serviceResult.Data);
            }
        }
    }
}
