using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_Manager.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Date)] public DateTime Birthday { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Business> Businesses { get; set; }
    }
}