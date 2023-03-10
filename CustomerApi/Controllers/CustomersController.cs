using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IRepository<Customer> repository;
        public CustomersController(IRepository<Customer> repos)
        {
            repository = repos;
        }

        // GET products
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return repository.GetAll();
        }

        // GET products/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST products
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            var newCustomer = repository.Add(customer);

            return CreatedAtRoute("GetProduct", new { customerId = newCustomer.CustomerId }, newCustomer);
        }

        // PUT products/5
        [HttpPut("{id}")]
        public IActionResult Put(int customerId, [FromBody] Customer customer)
        {
            if (customer == null || customer.CustomerId != customerId)
            {
                return BadRequest();
            }

            var modifiedCustomer = repository.Get(customerId);

            if (modifiedCustomer == null)
            {
                return NotFound();
            }

            modifiedCustomer.Name = customer.Name;
            modifiedCustomer.BillingAdress = customer.BillingAdress;
            modifiedCustomer.CreditStanding = customer.CreditStanding;
            modifiedCustomer.EMail = customer.EMail;
            modifiedCustomer.PhoneNumber = customer.PhoneNumber;
            modifiedCustomer.ShippingAdress = customer.ShippingAdress;
            

            repository.Edit(modifiedCustomer);
            return new NoContentResult();
        }

        // DELETE products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int customerId)
        {
            if (repository.Get(customerId) == null)
            {
                return NotFound();
            }

            repository.Remove(customerId);
            return new NoContentResult();
        }
    }
}
