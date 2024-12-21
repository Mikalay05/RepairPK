namespace RepairPK.Dto.ForUpdateDto
{
    public record OrderForUpdateDto
    {
        public decimal TotalAmount { get; set; }
        public DateTime CompletionDate { get; set; }
        public bool PaymentStatus { get; set; }
        public int CustomerId { get; set; }
    }
}
