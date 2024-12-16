namespace RepairPK.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public int HardwareId { get; set; }
        public Hardware Hardware { get; set; } = null!;
        public DateTime RepairDate { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int PartId { get; set; }
        public Part Part { get; set; }
        public int CountPart { get; set; }

    }
}
