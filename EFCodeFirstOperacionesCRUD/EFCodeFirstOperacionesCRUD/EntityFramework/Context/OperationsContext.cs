using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstOperacionesCRUD.EntityFramework.Entities;

namespace EFCodeFirstOperacionesCRUD.EntityFramework.Context
{
    public class OperationsContext : DbContext
    {

        public OperationsContext() :base("OperationsSample")
        {
            
        }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Order> Orders { get; set; }


    }
}
