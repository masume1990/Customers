using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.Core.Convertors;
using Customers.Core.DTOs.CustomersVM;
using Customers.Core.Services.Interfaces;
using Customers.DataLayer.Entities.Customer;
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

        public IActionResult Index(int pageId = 1, string filterLastName = "", string filterEmail = "")
        {
            CustomersViewModel customersViewModel = new CustomersViewModel();
            customersViewModel = _customerService.GetCustomers(pageId, filterEmail, filterLastName);
            return View(customersViewModel);

        }

        #region Register
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
            if (_customerService.IsExistEmail(FixedText.FixedEmail(customer.Email), 0))
            {
                ModelState.AddModelError("Email", "Email is invalid!");
                return View(customer);
            }

            Customer _customer = new Customer()
            {
                FirstName = FixedText.FixedString(customer.FirstName),
                LastName = FixedText.FixedString(customer.LastName),
                DateOfBirth = customer.DateOfBirth,
                BankAccountNumber = FixedText.FixedString(customer.BankAccountNumber),
                PhoneNumber = FixedText.FixedString(customer.PhoneNumber),
                Email = FixedText.FixedEmail(customer.Email)

            };
            if (_customerService.IsExistCustomer(_customer))
            {
                ModelState.AddModelError("FirstName", "Customer is invalid!");
                return View(customer);
            }
            _customerService.AddCustomer(_customer);
            ViewBag.Message = "Customer is Registered";
            return View("SuccessAlert");


        }
        #endregion

        #region Delete

        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);
            ViewBag.Message = "Customer Deleted";
            return View("SuccessAlert");
        }
        #endregion

        #region Update
        [Route("Update/{id}")]
        public IActionResult Update(int id)
        {
            Customer customer = new Customer();
            customer =  _customerService.GetCustomerById(id);
            ViewBag.Title = "Update  customer";
            return View(customer);
        }

        [Route("Update/{id}")]
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            if (_customerService.IsExistEmail(FixedText.FixedEmail(customer.Email), customer.CustomerId))
            {
                ModelState.AddModelError("Email", "Email is invalid!");
                return View(customer);
            }

            Customer _customer = new Customer()
            {
                CustomerId = customer.CustomerId,
                FirstName = FixedText.FixedString(customer.FirstName),
                LastName = FixedText.FixedString(customer.LastName),
                DateOfBirth = customer.DateOfBirth,
                BankAccountNumber = FixedText.FixedString(customer.BankAccountNumber),
                PhoneNumber = FixedText.FixedString(customer.PhoneNumber),
                Email = FixedText.FixedEmail(customer.Email)

            };
            if (_customerService.IsExistCustomer(_customer))
            {
                ModelState.AddModelError("FirstName", "Customer is invalid!");
                return View(customer);
            }
            _customerService.UpdateCustomer(_customer);
            ViewBag.Message = "Customer is updated";
            return View("SuccessAlert");


        }
        #endregion

    }
}