﻿using Microsoft.AspNetCore.Mvc;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Dto.ForUpdateDto;
using RepairPK.Exception;

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

        // CRUD => C
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
                return base.CreatedAtRoute("GetAppointmentById", new { id = appointmentToReturn.Id }, appointmentToReturn);
            }
            catch (CustomerNotFoundExeption ex)
            {
                return base.NotFound(ex.Message);
            }
        }

        // CRUD => R
        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            var appointments = _appointmentRepository.GetAllAppointments(trackChanges: true);

            return Ok(appointments);
        }
        [HttpGet("{id}", Name = "GetAppointmentById")]
        public IActionResult GetAppointmentById(int id)
        {
            try
            {
                var appointment = _appointmentRepository.GetAppointment(id, true);
                return Ok(appointment);
            }
            catch (AppointmentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }
        // CRUD => U
        [HttpPut("{customerId:int}/{id:int}")]
        public IActionResult UpdateAppointment(int customerId, int id, [FromBody] AppointmentForUpdateDto appointmentForUpdate)
        {
            if (appointmentForUpdate is null)
            {
                return BadRequest("AppointmentForUpdateDto object is null");
            }
            try
            {
                _appointmentRepository.UpdateAppointment(customerId, id, appointmentForUpdate, trackChanges: true);
            }
            catch(CustomerNotFoundExeption ex)
            {
                return base.NotFound(ex.Message);
            }
            catch (AppointmentNotFoundException ex)
            {
                return base.NotFound(ex.Message);
            }

            return NoContent();
        }

        // CRUD => D
        [HttpDelete("{customerId:int}/{id:int}")]
        public IActionResult DeleteAppointment(int customerId, int id)
        {
            try
            {
                _appointmentRepository.DeleteAppointment(customerId, id, trackChanges: false);
                return base.NoContent();
            }
            catch(CustomerNotFoundExeption ex)
            {
                return base.NotFound(ex.Message);
            }
            catch(AppointmentNotFoundException ex)
            {
                return base.NotFound(ex.Message);
            }

        }

    }
}
