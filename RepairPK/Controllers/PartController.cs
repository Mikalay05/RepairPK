using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Repository;

namespace RepairPK.Controllers
{
    [ApiController]
    [Route("api/part")]
    public class PartController : ControllerBase
    {
        private readonly IPartRepository _partRepository;
        public PartController(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }
        [HttpGet]
        public IActionResult GetAllParts()
        {
            var parts = _partRepository.GetAllPart(trackChanges: true);

            return Ok(parts);
        }
        [HttpGet("{id}", Name = "GetPartById")]
        public IActionResult GetPartById(int id)
        {
            var part = _partRepository.GetPart(id, true);

            if (part == null)
            {
                return NotFound();
            }

            return Ok(part);
        }
        [HttpPost]
        public IActionResult CreatePart([FromBody] PartForCreationDto partForCreationDto)
        {
            if(partForCreationDto is null)
            {
                return BadRequest("PartForCreationDto is null");
            }
            var createdPart = _partRepository.CreatePart(partForCreationDto);

            return CreatedAtRoute("GetPartById", new { id = createdPart.Id }, createdPart);
        }
    }
}
