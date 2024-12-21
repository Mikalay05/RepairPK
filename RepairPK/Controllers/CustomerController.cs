using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Repository;
using System.Security.Cryptography.X509Certificates;

namespace RepairPK.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomer(trackChanges: true);

            return Ok(customers);
        }
        [HttpGet("{id}", Name = "GetCustomerById")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomer(id, true);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerForCreationDto customerForCreationDto)
        {
            if (customerForCreationDto is null)
            {
                return BadRequest("CustomerForCreationDto is null");
            }
            var createdCustomer = _customerRepository.CreateCustomer(customerForCreationDto);

            return CreatedAtRoute("GetCustomerById", new { id = createdCustomer.Id }, createdCustomer);
        }
        [HttpGet("collection/({ids})", Name = "CustomerCollection")]
        public IActionResult GetCustomerCollection(string ids)
        {
            var idList = ids.Split(',').Select(int.Parse).ToList();
            var customers = _customerRepository.GetByIds(idList, trackChanges: false);

            return Ok(customers);
        }
    }
}
