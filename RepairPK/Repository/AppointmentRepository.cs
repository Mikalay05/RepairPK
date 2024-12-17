using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext context) : base(context) { }
        public IEnumerable<AppointmentDto> GetAllAppointments(bool trachChanges)
        {
            var appointments = FindAll(trachChanges)
                .OrderBy(c => c.Id)
                .ToList();

            var appointmentsDto = appointments.Select(a =>

                new AppointmentDto(a.Id, a.CustomerId,  a.Content, a.AppointmentDate))
                .ToList();

            return appointmentsDto;
        }
        public AppointmentDto GetAppointment(int id, bool trachChanges)
        {
            var appointment = FindByCondition(a => a.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var appointmentDto = new AppointmentDto(appointment.Id, appointment.CustomerId, appointment.Content, appointment.AppointmentDate);
            return appointmentDto;
        }
    }
}
