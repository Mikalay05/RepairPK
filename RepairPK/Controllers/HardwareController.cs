using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Repository;

namespace RepairPK.Controllers
{
    [ApiController]
    [Route("api/hardware")]
    public class HardwareController : ControllerBase
    {
        private readonly IHardwareRepository _hardwareRepository;
        public HardwareController(IHardwareRepository hardwareRepository)
        {
            _hardwareRepository = hardwareRepository;
        }
        [HttpGet]
        public IActionResult GetAllHardwares()
        {
            var hardwares = _hardwareRepository.GetAllHardwares(trackChanges: true);

            return Ok(hardwares);
        }
        [HttpGet("{id}", Name = "GetHardwareById")]
        public IActionResult GetHardwareById(int id)
        {
            var hardware = _hardwareRepository.GetHardware(id, true);

            if (hardware == null)
            {
                return NotFound();
            }

            return Ok(hardware);
        }
        [HttpPost]
        public IActionResult CreateHardware([FromQuery] int orderId, [FromBody] HardwareForCreationDto hardwareForCreationDto)
        {
            if (hardwareForCreationDto is null)
            {
                return BadRequest("HardwareForCreationDto object is nul");
            }

            try
            {
                var HardwareToReturn = _hardwareRepository.CreateHardware(orderId, hardwareForCreationDto, false);
                return CreatedAtRoute("GetHardwareById", new { id = HardwareToReturn.Id }, HardwareToReturn);
            }
            catch (CustomerNotFound ex)
            {
                return NotFound($"Customer with ID {orderId} not found.");
            }
        }
    }
}
