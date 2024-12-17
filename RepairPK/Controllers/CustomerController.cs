using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;

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
    }
}
