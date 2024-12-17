using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IAppointmentRepository
    {
        IEnumerable<AppointmentDto> GetAllAppointments(bool trackChanges);
        AppointmentDto GetAppointment(int id, bool trackChanges);
    }
}
