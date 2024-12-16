namespace RepairPK.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CompletionDate { get; set; }
        public bool PaymentStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<Hardware> Hardwares  { get; } = new List<Hardware>();
    }
}
