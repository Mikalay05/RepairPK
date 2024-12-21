namespace RepairPK.Dto.ForUpdateDto
{
    public record FeedbackForUpdateDto
    {
        public int CustomerId { get; set; }
        public short Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
