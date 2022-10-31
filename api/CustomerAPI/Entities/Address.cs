using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerAPI.Entities
{
   public class Address
    {
        //[Key]
        //public Guid AddressId { get; set; }
        //[Required(ErrorMessage = "Zipcode cannot be empty")]
        //[MinLength(4, ErrorMessage ="Min length should be 4")]
        //[MaxLength(5, ErrorMessage ="Max length should be 5")]
        //public int ZipCode { get; set; }
        //public Guid CountryId { get; set; }
        //[ForeignKey("CountryId")]
        //public Country Country { get; set; }

        //[ForeignKey("CustomerId")]
        //public Guid CustomerId { get; set; }

        [Key]
        public Guid AddressId { get; set; }
        [Required(ErrorMessage = "Zipcode cannot be empty")]
        [MinLength(4, ErrorMessage = "Min length should be 4")]
        [MaxLength(5, ErrorMessage = "Max length should be 5")]
        public int ZipCode { get; set; }
        public string Country { get; set; }

        [ForeignKey("CustomerId")]
        public Guid CustomerId { get; set; }
    }
}
