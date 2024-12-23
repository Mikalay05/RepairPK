namespace RepairPK.Dto.ForUpdateDto
{
    public record AppointmentForUpdateDto
    {
        public string Content { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
