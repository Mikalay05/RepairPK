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
        [HttpGet("collection/{ids}", Name = "PartCollection")]
        public IActionResult GetPartCollection(string ids)
        {
            var idList = ids.Split(',').Select(int.Parse).ToList();
            var result = _partRepository.GetByIds(idList, trackChanges: false);
            return Ok(result);
        }
        [HttpPost("collection")]
        public IActionResult CreatePartCollection([FromBody] IEnumerable<PartForCreationDto> partCollection)
        {
            var result = _partRepository.CreatePartCollection(partCollection);
            return CreatedAtRoute("PartCollection", new { result.ids }, result.parts);
        }
    }
}
