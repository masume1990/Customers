using Customers.Core.DTOs.CustomersVM;
using Customers.Core.Services.Interfaces;
using Customers.DataLayer.Context;
using Customers.DataLayer.Entities.Customer;
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

        public CustomersViewModel GetCustomers(int pageId = 1, string filterEmail = "", string filterLastName = "")
        {
             IQueryable<Customer> result = _context.Customers.Where(cu => cu.IsDelete == false);
       

            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(u => u.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterLastName))
            {
                result = result.Where(u => u.LastName.Contains(filterLastName));
            }

            // Show Item In Page
            int take = 20;
            int skip = (pageId - 1) * take;


            CustomersViewModel list = new CustomersViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Customers = result.OrderBy(u => u.CustomerId).Skip(skip).Take(take).ToList();

            return list;
        }

        public bool IsExistCustomer(Customer customer)
        {
            return _context.Customers.Any(_customer => _customer.FirstName == customer.FirstName && _customer.LastName == customer.LastName && _customer.PhoneNumber == customer.PhoneNumber);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Customers.Any(customer => customer.Email == email);
        }
    }
}
