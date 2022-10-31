using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class CustomerUpdateDto
    {
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
