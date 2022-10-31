using CustomerAPI.Entities;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
   public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();

        Task<Customer> GetCustomer(Guid customerId);

        void CreateCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);

        
    }
}
