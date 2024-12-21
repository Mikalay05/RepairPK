namespace RepairPK.Dto.ForUpdateDto
{
    public record AppointmentForUpdateDto
    {
        public int CustomerId { get; set; }
        public string Content { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
