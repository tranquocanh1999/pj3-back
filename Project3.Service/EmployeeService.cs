using Project3.Common.Models;
using Project3.DataLayer.Interfaces;
using Project3.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {

        }

        /// <summary>
        /// thêm mới một bản ghi 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ///  Created by: TQAnh(16/03/2021)
        public override ServiceResult Insert(Employee entity)
        {

            var erroMsg = new ErroMsg();
            var isValid = ValidateData(entity, erroMsg);
            if (isValid == true)
            {
                entity.EmployeeCode = getCode("NV");
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
    }
}
