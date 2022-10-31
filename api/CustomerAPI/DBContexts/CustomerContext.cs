using CustomerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CustomerAPI.DBContexts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = Guid.Parse("991e0c2f-a768-40b9-9eaa-b7c31eb3fcc4"), CountryName = "Sweden", CountryCode = "+46" },
               new Country { CountryId = Guid.Parse("ba2dc307-32bf-4d24-8cd2-45f070975889"), CountryName = "Denmark", CountryCode = "+45" },
               new Country { CountryId = Guid.Parse("0f72123d-6095-490e-a051-6bb7fbcbc010"), CountryName = "Norway", CountryCode = "+47" },
               new Country { CountryId = Guid.Parse("01d942ed-522e-4e5f-908b-cae029c820d7"), CountryName = "Finland", CountryCode = "+358" });

            modelBuilder.Entity<Address>().HasData(new Address { Country = "Sweden", ZipCode = 15132, AddressId = Guid.Parse("78cebe6c-6dac-403e-82bd-43f3142ea805"), CustomerId = Guid.Parse("e2c46906-2ea4-4672-a81f-bd69890c9b16") },
                new Address { Country = "Denmark", ZipCode = 04268, AddressId = Guid.Parse("a02b03b7-36cb-4839-911c-f782bb3009e9"), CustomerId = Guid.Parse("21d937d1-f020-4e4f-9f26-add9801b6e75") },
                new Address { Country = "Norway", ZipCode = 30415, AddressId = Guid.Parse("5c3ac12f-ec83-449e-a37e-de7442cde7da"), CustomerId = Guid.Parse("5cee819a-f78d-49a9-866e-b69aba44c4f4") },
                new Address { Country = "Finland", ZipCode = 55603, AddressId = Guid.Parse("b84178a0-b0ff-4721-96cc-5d271d93f6b9"), CustomerId = Guid.Parse("fbf6dc01-93f9-4772-891f-46e5a79d6e2a") });

           

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = Guid.Parse("e2c46906-2ea4-4672-a81f-bd69890c9b16"), PersonalNumber = "199205251045", Email = "user1@domain.com", PhoneNumber = "+467455535" },
                new Customer { CustomerId = Guid.Parse("21d937d1-f020-4e4f-9f26-add9801b6e75"), PersonalNumber = "199307121428", Email = "user2@domain.com", PhoneNumber = "+4560555269" },
                new Customer { CustomerId = Guid.Parse("5cee819a-f78d-49a9-866e-b69aba44c4f4"), PersonalNumber = "198904208493", Email = "user3@domain.com", PhoneNumber = "+4795552843" },
                new Customer { CustomerId = Guid.Parse("fbf6dc01-93f9-4772-891f-46e5a79d6e2a"), PersonalNumber = "198602182748", Email = "user4@domain.com", PhoneNumber = "+3585005557352" });


            base.OnModelCreating(modelBuilder);
        }
    }
}
