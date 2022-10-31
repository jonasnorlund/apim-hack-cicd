using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerAPI.Entities;
using CustomerAPI.Models;

namespace CustomerAPI.Profiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Address, CustomerAddressCreateDto>().ReverseMap();
            CreateMap<CustomerUpdateDto, Customer>();
        }
    }
}
