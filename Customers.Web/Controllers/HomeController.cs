using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.Core.Convertors;
using Customers.Core.Services.Interfaces;
using Customers.DataLayer.Entitites.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService _customerService;
        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            // return View();
            return Content("sassasa");
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            if (_customerService.IsExistEmail(FixedText.FixedEmail(customer.Email)))
            {
                ModelState.AddModelError("Email", "Email is invalid!");
                return View(customer);
            }

            Customer _customer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                BankAccountNumber = customer.BankAccountNumber,
                PhoneNumber = customer.PhoneNumber,
                Email = FixedText.FixedEmail(customer.Email)

            };
            _customerService.AddCustomer(_customer);
            return View("SuccessRegister",_customer);
        }
    }
}