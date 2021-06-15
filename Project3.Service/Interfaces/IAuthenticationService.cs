using Project3.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Service.Interfaces
{
    public interface IAuthenticationService
    {

        ServiceResult Login(string email, string password);
        ServiceResult ChangePass(string email, string oldPass, string newPass);
        ServiceResult ForgotPassword(string email);
    }
}
