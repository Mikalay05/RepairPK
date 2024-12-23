using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Exception;
using RepairPK.Repository;

namespace RepairPK.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult GetAlOrders()
        {
            var orders = _orderRepository.GetAllOrders(trackChanges: true);

            return Ok(orders);
        }
        [HttpGet("{id}", Name = "GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderRepository.GetOrder(id, true);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
        [HttpPost]
        public IActionResult CreateOrder([FromQuery] int customerId, [FromBody] OrderForCreationDto orderForCreationDto)
        {
            if (orderForCreationDto is null)
            {
                return BadRequest("OrderForCreationDto object is nul");
            }

            try
            {
                var orderToReturn = _orderRepository.CreateOrder(customerId, orderForCreationDto, false);
                return CreatedAtRoute("GetOrderById", new { id = orderToReturn.Id }, orderToReturn);
            }
            catch (CustomerNotFoundException ex)
            {
                return NotFound($"Customer with ID {customerId} not found.");
            }
        }
    }
}
