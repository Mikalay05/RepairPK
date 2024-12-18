namespace RepairPK.Dto
{
    public record AppointmentForCreationDto(
        int CustomerId,
        string Content,
        DateTime AppointmentDate
    );
}
