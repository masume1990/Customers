using Customers.DataLayer.Entitites.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        bool IsExistEmail(string email);
        int AddCustomer(Customer customer);
     }
}
