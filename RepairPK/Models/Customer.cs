namespace RepairPK.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();
        public ICollection<Appointment> Appointments { get; } = new List<Appointment>();
    }
}
