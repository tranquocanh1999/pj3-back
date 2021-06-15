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
    public class CustomerService : BaseService<Customer>, ICustomerService
    {

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {

        }
    }
}
