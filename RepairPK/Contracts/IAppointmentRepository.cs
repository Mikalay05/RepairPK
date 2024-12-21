using RepairPK.Dto;
using RepairPK.Dto.ForUpdateDto;

namespace RepairPK.Contracts
{
    public interface IAppointmentRepository
    {
        // CRUD => C
        AppointmentDto CreateAppointment(int customerId, AppointmentForCreationDto appointment, bool trackChanges);

        // CRUD => R
        IEnumerable<AppointmentDto> GetAllAppointments(bool trackChanges);
        AppointmentDto GetAppointment(int id, bool trackChanges);
        // CRUD => U
        void UpdateAppointment(int customerId, int appointmentId, AppointmentForUpdateDto appointmentForUpdate, bool trackChanges);
        // CRUD => D
        void DeleteAppointment(int customerId, int appoinmentId, bool trackChanges);
    }
}
