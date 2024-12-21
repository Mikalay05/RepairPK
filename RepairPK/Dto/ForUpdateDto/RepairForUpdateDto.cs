namespace RepairPK.Dto.ForUpdateDto
{
    public record RepairForUpdateDto
    {
        public int HardwareId { get; set; }
        public DateTime RepairDate { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int? PartId { get; set; }
        public int? CountPart { get; set; }
    }
}
