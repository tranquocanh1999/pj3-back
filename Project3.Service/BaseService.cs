using Dapper;
using Project3.Common.Models;
using Project3.DataLayer.Interfaces;
using Project3.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Service
{
    public class BaseService<Entity> : IBaseService<Entity>
    {
        #region DECLARE
        // khai báo các thuộc tính
        protected string className = typeof(Entity).Name;
        protected ServiceResult serviceResult;
        protected IDbContext<Entity> _dbContext;
        protected String sqlQuerry;
        protected DynamicParameters Parameters = new DynamicParameters();
        #endregion

        #region Constructor

        /// <summary>
        /// hàm khởi tạo 
        /// </summary>
        /// <param name="dbContext"> một interface của IDbContext<Entity> </param>
        /// CreatedBy: TQAnh ( 08/02/2021)
        public BaseService(IDbContext<Entity> dbContext)
        {
            serviceResult = new ServiceResult();
            _dbContext = dbContext;
        }




        #endregion
        #region Method

        /// <summary>
        /// lấy danh sách 
        /// </summary>
        /// <param name="payload">trường cần filter </param>
        /// <returns></returns>
        /// Created by: TQAnh(16/03/2021)
        public ServiceResult GetData(Payload payload)
        {

            Page<Entity> page = new Page<Entity>();
            SqlQuerry(payload);
            page.Data = _dbContext.GetAll($"Select * from {className} {sqlQuerry}  LIMIT {payload.PageSize} OFFSET {payload.Offset* payload.PageSize}", Parameters);
            page.TotalElement = _dbContext.GetTotalEleMent($"Select count(*) from {className} {sqlQuerry}", Parameters);
            page.PageSize = payload.PageSize;
            serviceResult.Data = page;
            return serviceResult;
        }


        /// <summary>
        /// lấy danh sách 
        /// </summary>
        /// <returns> trả về một ServiceResult  </returns>
        /// Created by: TQAnh(16/03/2021)
        public ServiceResult GetData()
        {
            serviceResult.Data = _dbContext.GetAll();
            return serviceResult;
        }

        /// <summary>
        /// thêm mới một bản ghi 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ///  Created by: TQAnh(16/03/2021)
        public virtual ServiceResult Insert(Entity entity)
        {

            var erroMsg = new ErroMsg();
            var isValid = ValidateData(entity, erroMsg);
            if (isValid == true)
            {
                var response = _dbContext.Insert(entity);
                serviceResult.Data = response;
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = erroMsg;

            }
            return serviceResult;
        }

        /// <summary>
        /// xóa đối tượng
        /// </summary>
        /// <param name="id">khóa chính đối tượng cần xóa</param>
        /// <returns> trả về một ServiceResult  </returns>
        ///  Created by: TQAnh(16/03/2021)
        public ServiceResult Delete(string IDs)
        {

            serviceResult.Data = _dbContext.Delete(IDs);
            return serviceResult;
        }

        public ServiceResult GetByIDs(string IDs)
        {
            serviceResult.Data = _dbContext.GetByIDs(IDs);
            return serviceResult;
        }



        /// <summary>
        /// lấy dữ liệu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ///  Created by: TQAnh(16/03/2021)
        public ServiceResult GetByID(string id)
        {


            serviceResult.Data = _dbContext.GetByID(id);
            return serviceResult;


        }


        /// <summary>
        /// Chỉnh sửa một bản ghi 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ///  Created by: TQAnh(16/03/2021)
        public ServiceResult Update(Entity entity)
        {

            var erroMsg = new ErroMsg();
            var isValid = ValidateData(entity, erroMsg);
            if (isValid == true)
            {
                serviceResult.Data = _dbContext.Update(entity);


            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = erroMsg;

            }
            return serviceResult;

        }

        protected string getCode(string PreCode)
        {
            string Code = _dbContext.GetCode();
            if (Code == null) { Code = PreCode + "0"; }
            Code= Code.Substring(2, Code.Length - 2);
            Code = (Int32.Parse(Code) + 1).ToString();
            while (Code.Length < 4) { Code = "0" + Code; }

            return PreCode + Code;
        }

        /// <summary>
        /// validate dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="erroMsg"></param>
        /// <returns></returns>
        /// Created by: TQAnh(16/03/2021)
        protected virtual bool ValidateData(Entity entity, ErroMsg erroMsg)
        { return true; }

        /// <summary>
        /// tạo câu lệnh sql
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        /// Created by: TQAnh(16/03/2021)
        protected virtual string SqlQuerry(Payload payload)
        {

            var queryString = $" where isDelete=0";
        
            if (payload.Param != "")
            {
                if (className != "Bill")
                {
                    queryString = className == "Employee" ? queryString + $" and ({className}Code like @Param or FullName like @Param)" : queryString + $" and ({className}Code like @Param or {className}Name like @Param)";
                    this.Parameters.Add($"@Param", $"%{payload.Param}%");
                }
                else
                {
                    queryString = queryString + $" and {className}Code like @Param";
                    this.Parameters.Add($"@Param", $"%{payload.Param}%");
                }
            }
            foreach (Filter filter in payload.Filter)
            {

                switch (filter.Type)
                {
                    case "3":
                        {
                            queryString = queryString + $" and {filter.Name} is null";
                            break;
                        }
                    case "4":
                        {
                            queryString = queryString + $" and {filter.Name} is not null";
                            break;
                        }
                    case "10":
                        {
                            queryString = queryString + $" and {filter.Name} like @{filter.Name}";
                            this.Parameters.Add($"@{filter.Name}", $"%{filter.Value1}%");
                            break;
                        }
                    case "11":
                        {
                            queryString = queryString + $" and {filter.Name} not like @{filter.Name}";
                            this.Parameters.Add($"@{filter.Name}", $"%{filter.Value1}%");
                            break;
                        }
                    case "12":
                        {
                            queryString = queryString + $" and {filter.Name} >= @{filter.Name}";
                            this.Parameters.Add($"@{filter.Name}", $"{filter.Value1}");
                            break;
                        }
                    case "13":
                        {
                            queryString = queryString + $" and {filter.Name} <= @{filter.Name}";
                            this.Parameters.Add($"@{filter.Name}", $"{filter.Value1}");
                            break;
                        }
                    case "14":
                        {
                            queryString = queryString + $" and DATE({filter.Name}) >= @{filter.Name}";
                            this.Parameters.Add($"@{filter.Name}", $"{filter.Value1}");
                            break;
                        }
                    case "15":
                        {
                            queryString = queryString + $" and DATE({filter.Name}) <= @{filter.Name}";
                            this.Parameters.Add($"@{filter.Name}", $"{filter.Value1}");
                            break;
                        }
                    case "16":
                        {
                            queryString = queryString + $" and {filter.Name} not like @{filter.Name}";
                            this.Parameters.Add($"@{filter.Name}", $"{filter.Value1}");
                            break;
                        }
                    case "17":
                        {
                            queryString = queryString + $" and {filter.Name} like @{filter.Name}";
                            this.Parameters.Add($"@{filter.Name}", $"{filter.Value1}");
                            break;
                        }
                    case "18":
                        {
                            queryString = queryString + $" and DATE({filter.Name}) = @{filter.Name}";
                            this.Parameters.Add($"@{filter.Name}", $"{filter.Value1}");
                            break;
                        }
                    case "20":
                        {
                            queryString = queryString + $" and {filter.Name} BETWEEN  @{filter.Name}1 AND @{filter.Name}2";
                            this.Parameters.Add($"@{filter.Name}1", $"{filter.Value1}");
                            this.Parameters.Add($"@{filter.Name}2", $"{filter.Value2}");
                            break;
                        }
                    case "21":
                        {
                            queryString = queryString + $" and DATE({filter.Name}) BETWEEN  @{filter.Name}1 AND @{filter.Name}2";
                            this.Parameters.Add($"@{filter.Name}1", $"{filter.Value1}");
                            this.Parameters.Add($"@{filter.Name}2", $"{filter.Value2}");
                            break;
                        }

                    case "1":
                        {
                            if (filter.Value1 != "-1")
                            {
                                queryString = queryString + $" and {filter.Name} like @{filter.Name}";
                                this.Parameters.Add($"@{filter.Name}", $"{filter.Value1}");
                            }

                            break;
                        }
                }


            }


            this.sqlQuerry = queryString;
            return "";
        }

  
        #endregion
    }
}
