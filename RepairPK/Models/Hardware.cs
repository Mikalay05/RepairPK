namespace RepairPK.Models
{
    public class Hardware
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public string Type { get; set; }

        public ICollection<Repair> Repairs = new List<Repair>();
    }
}
