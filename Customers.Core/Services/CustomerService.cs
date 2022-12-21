using Customers.Core.Services.Interfaces;
using Customers.DataLayer.Context;
using Customers.DataLayer.Entitites.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Customers.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private CustomerContext _context;
        public CustomerService(CustomerContext context)
        {
            _context = context;
        }

        public int AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.CustomerId;
        }

        public bool IsExistEmail(string email)
        {
            return _context.Customers.Any(customer => customer.Email == email);
        }
    }
}
