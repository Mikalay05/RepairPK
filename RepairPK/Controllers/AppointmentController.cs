using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Repository;

namespace RepairPK.Controllers
{
    [ApiController]
    [Route("api/appointment")] 
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            var appointments = _appointmentRepository.GetAllAppointments(trackChanges: true);

            return Ok(appointments);
        }
        [HttpGet("{id}", Name = "GetAppointmentById")]
        public IActionResult GetAppointmentById(int id)
        {
            var appointment = _appointmentRepository.GetAppointment(id, true);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }
        [HttpPost]
        public IActionResult CreateAppointment([FromQuery] int customerId, [FromBody] AppointmentForCreationDto appointmentForCreationDto)
        {
            if (appointmentForCreationDto is null)
            {
                return BadRequest("AppointmentForCreationDto object is nul");
            }

            try
            {
                var appointmentToReturn = _appointmentRepository.CreateAppointment(customerId, appointmentForCreationDto, false);
                return CreatedAtRoute("GetAppointmentById", new { id = appointmentToReturn.Id }, appointmentToReturn);
            }
            catch (CustomerNotFound ex)
            {
                return NotFound($"Customer with ID {customerId} not found.");
            }
        }
    }
}
