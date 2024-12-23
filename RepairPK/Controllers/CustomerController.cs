using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Dto.ForUpdateDto;
using RepairPK.Exception;
using RepairPK.Exception.AbstractException;
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

        // CRUD => C


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
        // CRUD => R

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomer(trackChanges: true);

            return Ok(customers);
        }
        [HttpGet("{id}", Name = "GetCustomerById")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                var customer = _customerRepository.GetCustomer(id, true);
                return base.Ok(customer);

            }
            catch(System.Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet("collection/({ids})", Name = "CustomerCollection")]
        public IActionResult GetCustomerCollection(string ids)
        {
            try
            {
                var idList = ids.Split(',').Select(int.Parse).ToList();
                var customers = _customerRepository.GetByIds(idList, trackChanges: false);
                return Ok(customers);

            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        // CRUD => U
        [HttpPut("{id:int}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerForUpdateDto customerForUpdate)
        {
            if (customerForUpdate is null)
            {
                return BadRequest("CustomerForUpdateDto object is null");
            }
            try
            {
                _customerRepository.UpdateCustomer(id, customerForUpdate, trackChanges: true);
            }

            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // CRUD => D

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _customerRepository.DeleteCustomer(id, trackChanges: false);
                return base.NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }


        }

    }
}
