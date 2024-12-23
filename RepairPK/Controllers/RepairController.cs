using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Exception;
using RepairPK.Repository;

namespace RepairPK.Controllers
{
    [ApiController]
    [Route("api/repair")]
    public class RepairController : ControllerBase
    {
        private readonly IRepairRepository _repairRepository;
        public RepairController(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;
        }
        [HttpGet]
        public IActionResult GetAlRepairs()
        {
            var objects = _repairRepository.GetAllRepairs(trackChanges: true);

            return Ok(objects);
        }
        [HttpGet("{id}", Name = "GetRepairById")]
        public IActionResult GetRepairById(int id)
        {
            var thisObject = _repairRepository.GetRepair(id, true);

            if (thisObject == null)
            {
                return NotFound();
            }

            return Ok(thisObject);
        }
        [HttpPost]
        public IActionResult CreateRepair([FromQuery] int hardwareId, [FromQuery] int? partId, [FromBody] RepairForCreationDto repairForCreationDto)
        {
            if (repairForCreationDto is null)
            {
                return BadRequest("RepairForCreationDto object is nul");
            }

            try
            {
                var objectToReturn = _repairRepository.CreateRepair(hardwareId, partId, repairForCreationDto, false);
                return base.CreatedAtRoute("GetRepairById", new { id = objectToReturn.Id }, objectToReturn);
            }
            catch (CustomerNotFoundExeption ex)
            {
                return base.NotFound($"Customer with ID {hardwareId} not found.");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteRepair(int hardwareId, int? partId, int id)
        {
            _repairRepository.DeleteRepair(hardwareId, partId, id, false);
            return NoContent();
        }
    }
}
