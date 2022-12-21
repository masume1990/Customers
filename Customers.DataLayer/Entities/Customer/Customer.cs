using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Customers.DataLayer.Entities.Customer
{
    public class Customer
    {
        public Customer()
        {

        }

        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Frist Name")]
        [Required(ErrorMessage = "The {0} is required")]
        [MaxLength(100, ErrorMessage = "Maximum character is {1}")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The {0} is required")]
        [MaxLength(100, ErrorMessage = "Maximum character is {1}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "The {0} is required")]
        [MaxLength(12, ErrorMessage = "Maximum character is {1}")]
        public string PhoneNumber { get; set; }



        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The {0} is required")]
        [EmailAddress(ErrorMessage = "Invalid {0}")]
        [MaxLength(100, ErrorMessage = "Maximum character is {1}")]
        public string Email { get; set; }



        [Display(Name = "Bank Account Number")]
        [Required(ErrorMessage = "The {0} is required")]
        [MaxLength(16, ErrorMessage = "Maximum character is {1}")]
        public string BankAccountNumber { get; set; }

        public bool IsDelete { get; set; }
    }
}
