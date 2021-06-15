using Project3.Common.Models;
using Project3.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.DataLayer
{
   
    public class ProductRepository : MariaDbContext<Product>, IProductRepository
    {

    }
}
