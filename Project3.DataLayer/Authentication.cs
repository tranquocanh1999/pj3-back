using Dapper;
using Project3.Common.Models;
using Project3.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.DataLayer
{
    public class Authentication : IAuthentication
    {

        String _connectionString = "Host=localhost;" +
            "Database =project3 ;" +
            "Port=3307;User Id=root;" +
            " Password =123456 ;" +
            "Character Set=utf8";

        // khởi tạo kết nối 
        protected IDbConnection _dbConnection;


        //#region Constructor
        /// <summary>
        /// hàm khởi tạo s
        /// </summary>
        public Authentication()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        public Employee Login(string email, string password)
        {

            var sqlQuery = $"LoginEmployee";
            // thực thi truy vấn
            var entities = _dbConnection.Query<Employee>(sqlQuery, new { email, password }, commandType: CommandType.StoredProcedure).FirstOrDefault();

            // trả về cho client
            return entities;
        }

        public int ChangePass(string email, string password)
        {
            var sqlQuery = $"changePassword";
            // thực thi truy vấn
            var entities = _dbConnection.Execute(sqlQuery, new { email, password }, commandType: CommandType.StoredProcedure);

            // trả về cho client
            return entities;
        }
    }
}
