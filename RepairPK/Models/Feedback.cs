namespace RepairPK.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public short Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
