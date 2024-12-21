using RepairPK.Dto;

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
        void UpdateAppointment(int customerId, int appointmentId, );
        // CRUD => D
        void DeleteAppointment(int appoinmentId, bool trackChanges);
    }
}
