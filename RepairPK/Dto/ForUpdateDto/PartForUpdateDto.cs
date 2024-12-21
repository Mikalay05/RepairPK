namespace RepairPK.Dto.ForUpdateDto
{
    public record PartForUpdateDto
    {
        public string Name { get; set; }
        public int QuantityAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
