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

    public class ProductService : BaseService<Product>, IProductService
    {

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {

        }

        /// <summary>
        /// thêm mới một bản ghi 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ///  Created by: TQAnh(16/03/2021)
        public override ServiceResult Insert(Product entity)
        {

            var erroMsg = new ErroMsg();
            var isValid = ValidateData(entity, erroMsg);
            if (isValid == true)
            {
                entity.ProductCode = getCode("SP");
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

        public ServiceResult UpdateQuantity(Product[] products)
        {
            var value = "";
            foreach (Product product in products) { value += $"('{product.Id}', {product.Quantity}),"; }
            var sqlQuerry = $"INSERT INTO product (id,quantity) VALUES {value.Substring(0,value.Length-1)}  ON DUPLICATE KEY UPDATE quantity = VALUES(quantity); ";

            serviceResult.Data = _dbContext.ExecuteQuery(sqlQuerry);
            return serviceResult;

        }
    }
}
