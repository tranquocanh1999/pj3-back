using Project3.Common.Models;
using Project3.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Api.Controllers
{
  
    public class ProductController : BaseController<Product>
    {
        public ProductController(IProductService productService) : base(productService)
        {

        }
    }
}
