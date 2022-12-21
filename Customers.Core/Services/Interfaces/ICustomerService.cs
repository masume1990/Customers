using Customers.Core.DTOs.CustomersVM;
using Customers.DataLayer.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        bool IsExistCustomer(Customer customer);
        bool IsExistEmail(string email);
        int AddCustomer(Customer customer);
        CustomersViewModel GetCustomers(int pageId = 1, string filterEmail = "", string filterLastName = "");
     }
}
