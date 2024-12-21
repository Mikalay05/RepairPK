namespace RepairPK.Dto.ForUpdateDto
{
    public record HardwareForUpdateDto
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        public int OrderId { get; set; }
    }
}
