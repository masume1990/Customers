using Customers.DataLayer.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Text;


namespace Customers.Core.DTOs.CustomersVM
{
   

    public class CustomersViewModel
    {      
        public List<Customer> Customers { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }

    }
}
