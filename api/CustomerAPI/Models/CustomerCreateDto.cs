using CustomerAPI.ValidationAttirbutes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    [AddressAttribute]
    public class CustomerCreateDto
    {
        [Required(ErrorMessage = "Personal number cannot be empty")]
        [MaxLength(12, ErrorMessage = "Max length should be 12")]
        [MinLength(10, ErrorMessage = "Min length should be 10")]
        public string PersonalNumber { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        public string Email { get; set; }
        public CustomerAddressCreateDto Address { get; set; }

        [Required(ErrorMessage = "Phone number cannot be empty")]
        [MinLength(8, ErrorMessage = "Minimum 8 digits should be entered")]
        [MaxLength(15, ErrorMessage = "Maximum 15 digits should be entered")]
        public string PhoneNumber { get; set; }
    }
}
