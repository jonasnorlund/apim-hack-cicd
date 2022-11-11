using CustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CustomerAPI.ValidationAttirbutes
{
    public class AddressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //  return base.IsValid(value, validationContext);

            var customerCreateDto = (CustomerCreateDto)validationContext.ObjectInstance;

            var personalNumber = customerCreateDto.PersonalNumber;
            if (personalNumber.Length != 10 && personalNumber.Length != 12)
                return new ValidationResult("Personal Number should be 10 or 12 digits long", new[] { "CustomerCreateDto" });


            var zip = (customerCreateDto.Address.ZipCode).ToString();
            if ((zip.Length != 4 && zip.Length != 5) && double.IsNaN(Convert.ToDouble(zip)) && string.IsNullOrEmpty(zip))
                return new ValidationResult("Zip code should be numerical with 4-5 digits", new[] { "CustomerCreateDto" });

            var country = customerCreateDto.Address.Country.ToLower();

           if (country != "sweden" && country != "denmark" && country != "norway" && country != "finland" && country != "iceland")
                return new ValidationResult("Country should be among (Sweden, Denmark, Norway, Finland, Iceland)", new[] { "CustomerCreateDto" });

            var phoneNumber = customerCreateDto.PhoneNumber;

            if (country == "sweden" && (!phoneNumber.StartsWith("+46") || !phoneNumber.StartsWith("0")))
                return new ValidationResult("Since the country is Sweden, Phone Number should start with +46 or 0", new[] { "CustomerCreateDto" });
            else if (country == "denmark" && !phoneNumber.StartsWith("+45"))
                return new ValidationResult("Since the country is Denmark, Phone Number should start with +45", new[] { "CustomerCreateDto" });
            else if (country == "norway" && !phoneNumber.StartsWith("+47"))
                return new ValidationResult("Since the country is Norway, Phone Number should start with +47", new[] { "CustomerCreateDto" });
            else if (country == "finland" && !phoneNumber.StartsWith("+358"))
                return new ValidationResult("Since the country is Finland, Phone Number should start with +358", new[] { "CustomerCreateDto" });

            else if (country == "iceland" && !phoneNumber.StartsWith("+354"))
                return new ValidationResult("Since the country is Iceland, Phone Number should start with +354", new[] { "CustomerCreateDto" });
            return ValidationResult.Success;

        }
    }
}
