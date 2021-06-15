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
   public class BillRespository : MariaDbContext<Bill>, IBillRepository
    {
        public override int Delete(string IDs)
        {

            var sqlQuery = $" DELETE FROM {className} WHERE id IN({IDs});";
            // thực thi truy vấn

            var efectRows = _dbConnection.Execute(sqlQuery, commandType: CommandType.Text);
            return efectRows;
        }
    }
}
