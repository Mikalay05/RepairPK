using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;

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
        public IActionResult GetAllCustomers()
        {
            var parts = _partRepository.GetAllPart(trackChanges: true);

            return Ok(parts);
        }

    }
}
