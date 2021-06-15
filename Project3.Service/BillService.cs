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
   public class BillService : BaseService<Bill>, IBillService
    {

        public BillService(IBillRepository billRepository) : base(billRepository)
        {

        }

        /// <summary>
        /// thêm mới một bản ghi 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override ServiceResult Insert(Bill entity)
        {

            var erroMsg = new ErroMsg();
            var isValid = ValidateData(entity, erroMsg);
            if (isValid == true)
            {
                entity.BillCode = getCode("RB");
                entity.Id = Guid.NewGuid();
                _dbContext.Insert(entity);
                serviceResult.Data = entity.Id;

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
