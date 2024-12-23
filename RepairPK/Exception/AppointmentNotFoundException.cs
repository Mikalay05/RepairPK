using RepairPK.Exception.AbstractException;

namespace RepairPK.Exception
{
    public class AppointmentNotFoundException : NotFoundException
    {
        public AppointmentNotFoundException(int appointmentId) : base($"Appointment id = {appointmentId} not found")
        {

        }
    }
}
