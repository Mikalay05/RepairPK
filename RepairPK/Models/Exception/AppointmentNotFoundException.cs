namespace RepairPK.Models.Exception
{
    public class AppointmentNotFoundException : BadRequestException
    {
        public AppointmentNotFoundException(int appointmentId) : base ($"Appointment id = {appointmentId} not found") 
        {
            
        }
    }
}
