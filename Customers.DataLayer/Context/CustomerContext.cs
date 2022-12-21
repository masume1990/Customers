using Customers.DataLayer.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.DataLayer.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }

        #region Customer

        public DbSet<Customer> Customers { get; set; }
        #endregion
    }
}
