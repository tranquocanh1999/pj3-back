using Project3.Common.Models;
using Project3.DataLayer.Interfaces;
using Project3.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Service
{
    public class AuthenticationService : IAuthenticationService
    {

        private static readonly string _from = "tranquocanh16031999@gmail.com"; // Email của Sender (của bạn)
        private static readonly string _pass = "anh16031999"; // Mật khẩu Email của Sender (của bạn)
        protected ServiceResult serviceResult;
        protected IAuthentication _dbContext;
        private string sendto = "";
        private string subject = "Đổi mật khẩu";
        private string content = "";
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";

        public AuthenticationService(IAuthentication dbContext)
        {
            serviceResult = new ServiceResult();
            _dbContext = dbContext;
        }

        public ServiceResult ChangePass(string email, string oldPass, string newPass)
        {
            var pass = GetMD5(oldPass);
            var entity = _dbContext.Login(email, pass);
            if (entity != null)
            {
                pass = GetMD5(newPass);
                serviceResult.Data = _dbContext.ChangePass(email, pass);
            }
            else
                serviceResult.Success = false;
            return serviceResult;
        }

        public ServiceResult Login(string email, string password)
        {
            var pass = GetMD5(password);
            serviceResult.Data = _dbContext.Login(email, pass);
            serviceResult.Success = serviceResult.Data != null;
            return serviceResult;
        }

        public ServiceResult ForgotPassword(string email)
        {
            sendto = email;
            var pass = GeneratePassword(12);
            content = $"Mật khẩu mới của bạn là {pass}";
            pass = GetMD5(pass);
            _dbContext.ChangePass(email, pass);
            serviceResult.Data = Send();
            return serviceResult;
        }


        private String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }




        private string Send()
        {
            //sendto: Email receiver (người nhận)
            //subject: Tiêu đề email
            //content: Nội dung của email, bạn có thể viết mã HTML
            //Nếu gửi email thành công, sẽ trả về kết quả: OK, không thành công sẽ trả về thông tin l�-i


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(_from);
            mail.To.Add(sendto);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = content;

            mail.Priority = MailPriority.High;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_from, _pass);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            return "OK";


        }

        public string GeneratePassword(int passwordSize)
        {
            char[] _password = new char[passwordSize];
            string charSet = "";
            System.Random _random = new Random();
            int counter;


            charSet += LOWER_CASE;

            charSet += UPPER_CASE;

            charSet += NUMBERS;

            for (counter = 0; counter < passwordSize; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return string.Join(null, _password);
        }


    }


}
