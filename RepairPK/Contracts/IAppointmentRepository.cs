using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IAppointmentRepository
    {
        IEnumerable<AppointmentDto> GetAllAppointments(bool trackChanges);
        AppointmentDto GetAppointment(int id, bool trackChanges);
        AppointmentDto CreateAppointment(int customerId,AppointmentForCreationDto appointment, bool trackChanges);
    }
}
