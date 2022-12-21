using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Customers.DataLayer.Entitites.Customer
{
    public class Customer
    {
        public Customer()
        {

        }

        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Frist Name")]
        [Required(ErrorMessage = " Please enter {0} ")]
        [MaxLength(100, ErrorMessage = "Maximum character is {1}")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = " Please enter {0} ")]
        [MaxLength(100, ErrorMessage = "Maximum character is {1}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = " Please enter {0} ")]

        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Phone")]
        [Required(ErrorMessage = " Please enter {0} ")]
        [MaxLength(12, ErrorMessage = "Maximum character is {1}")]
        public string PhoneNumber { get; set; }



        [Display(Name = "Email")]
        [Required(ErrorMessage = " Please enter {0} ")]
        [MaxLength(100, ErrorMessage = "Maximum character is {1}")]
        public string Email { get; set; }



        [Display(Name = "Bank Account Number")]
        [Required(ErrorMessage = " Please enter {0} ")]
        [MaxLength(16, ErrorMessage = "Maximum character is {1}")]
        public string BankAccountNumber { get; set; }
    }
}
