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

    }
}
