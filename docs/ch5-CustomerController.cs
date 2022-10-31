using AutoMapper;
using CustomerAPI.Entities;
using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        ILogger<CustomerController> _logger = null;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper, ILogger<CustomerController> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await Task.FromResult(_customerRepository.GetCustomers()).Result;
            if (customers == null)
                return NotFound();

            _logger.LogInformation("Fetching all customers");

            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var customer = await Task.FromResult(_customerRepository.GetCustomer(customerId)).Result;
            if (customer == null)
                return NotFound();

            _logger.LogInformation("Fetching a single customer");

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer([FromBody] CustomerCreateDto customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            _customerRepository.CreateCustomer(customerEntity);

            var customerToMap = _mapper.Map<CustomerDto>(customerEntity);

            _logger.LogInformation("Creating a customer");

            return CreatedAtRoute("GetCustomer", new { customerId = customerToMap.CustomerId }, customerToMap);
        }

        [HttpPut("{customerId}")]
        public ActionResult UpdateCustomer(Guid customerId, [FromBody] CustomerUpdateDto customerDto)
        {
            var customer = _customerRepository.GetCustomer(customerId).Result;
            if (customer == null)
                return NotFound();

            _logger.LogInformation("Updating a customer");

            _mapper.Map(customerDto, customer);
            _customerRepository.UpdateCustomer(customer);

            return Ok();
        }

        [HttpPatch("{customerId}")]
        public ActionResult PartialUpdateCustomer(Guid customerId, [FromBody] JsonPatchDocument<CustomerUpdateDto> customerPatchDocument)
        {
            var customer = _customerRepository.GetCustomer(customerId).Result;
            if (customer == null)
                return NotFound();

            _logger.LogInformation("Partially updating a customer");

            var customerToPatch = _mapper.Map<CustomerUpdateDto>(customer);
            customerPatchDocument.ApplyTo(customerToPatch);

            if (!TryValidateModel(customerToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(customerToPatch, customer);
            _customerRepository.UpdateCustomer(customer);

            return Ok();
        }

        [HttpDelete("{customerId}")]
        public ActionResult DeleteCustomer(Guid customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId).Result;
            if (customer == null)
                return NotFound();

            _logger.LogInformation("Deleting a customer");

            _customerRepository.DeleteCustomer(customer);

            return Ok();
        }

        [HttpGet("getcustomerbyemail/{email}", Name = "GetCustomerByEmail")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var customer = await Task.FromResult(_customerRepository.GetCustomerByEmail(email)).Result;
            if (customer == null)
                return NotFound();

            _logger.LogInformation("Fetching a single customer by email");

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

    }
}
