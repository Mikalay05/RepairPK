namespace RepairPK.Dto
{
    public record AppointmentDto(
        int Id,
        int CustomerId,
        string Content,
        DateTime AppointmentDate
    );
}
