namespace RepairPK.Models
{
    public class Part
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public int QuantityAvailable { get; set; }

        public decimal Price { get; set; }

        public ICollection<Repair> Repairs { get; } = new List<Repair>();
    }
}
