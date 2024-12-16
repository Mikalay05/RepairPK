namespace RepairPK.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public string Content { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
