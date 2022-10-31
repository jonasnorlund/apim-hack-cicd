using CustomerAPI.DBContexts;
using CustomerAPI.Entities;
using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(CustomerContext context, ILogger<CustomerRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async void CreateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var customerId = Guid.NewGuid();

            customer.CustomerId = customerId;
            customer.Address.CustomerId = customerId;
            customer.Address.AddressId = Guid.NewGuid();

            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();

            _logger.LogInformation("Customer added successfully");
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            _logger.LogInformation("Customer deleted successfully");
        }

        public async Task<Customer> GetCustomer(Guid customerId)
        {
            if (customerId == null)
                throw new ArgumentNullException(nameof(customerId));

            var customer = await (from cust in _context.Customers
                                  join address in _context.Addresses on cust.CustomerId equals address.CustomerId
                                  select new Customer
                                  {
                                      Address = new Address
                                      {
                                          ZipCode = address.ZipCode,
                                          Country = address.Country,
                                          AddressId = address.AddressId
                                      },
                                      PhoneNumber = cust.PhoneNumber,
                                      CustomerId = cust.CustomerId,
                                      Email = cust.Email,
                                      PersonalNumber = cust.PersonalNumber
                                  }).Where(customer => customer.CustomerId == customerId).FirstOrDefaultAsync();

            _logger.LogInformation("Customer fetched successfully");

            return customer ?? throw new ArgumentNullException(nameof(customer));
        }

        

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await (from cust in _context.Customers
                                   join address in _context.Addresses on cust.CustomerId equals address.CustomerId
                                   select new Customer
                                   {
                                       Address = new Address
                                       {
                                           ZipCode = address.ZipCode,
                                           Country = address.Country,
                                           AddressId = address.AddressId
                                       },
                                       PhoneNumber = cust.PhoneNumber,
                                       CustomerId = cust.CustomerId,
                                       Email = cust.Email,
                                       PersonalNumber = cust.PersonalNumber
                                   }).ToListAsync<Customer>();

            _logger.LogInformation("Customers fetched successfully");

            return customers ?? throw new ArgumentNullException(nameof(customers));
        }


        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            _logger.LogInformation("Customer updated successfully");
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            var customer = await (from cust in _context.Customers
                                  join address in _context.Addresses on cust.CustomerId equals address.CustomerId
                                  select new Customer
                                  {
                                      Address = new Address
                                      {
                                          ZipCode = address.ZipCode,
                                          Country = address.Country,
                                          AddressId = address.AddressId
                                      },
                                      PhoneNumber = cust.PhoneNumber,
                                      CustomerId = cust.CustomerId,
                                      Email = cust.Email,
                                      PersonalNumber = cust.PersonalNumber
                                  }).Where(customer => customer.Email == email).FirstOrDefaultAsync();

            _logger.LogInformation("Customer fetched successfully by email");

            return customer ?? throw new ArgumentNullException(nameof(customer));
        }
    }
}
