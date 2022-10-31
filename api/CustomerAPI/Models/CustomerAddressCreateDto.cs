using CustomerAPI.ValidationAttirbutes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    
    public class CustomerAddressCreateDto
    {
        [Required(ErrorMessage = "Zipcode cannot be empty")]        
        public int ZipCode { get; set; }

        public string Country { get; set; }
    }
}
