namespace RepairPK.Dto
{
    public record AppointmentDto(
        int Id,
        int CustomerId,
        string CustomerName,
        string Content,
        DateTime AppointmentDate
    );
}
