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
    
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {
        public CustomerController(ICustomerService customerService) : base(customerService)
        {

        }
    }
}
