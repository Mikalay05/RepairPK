namespace RepairPK.Dto
{
    public record CustomerDto(
        int Id,
        string Name,
        string PhoneNumber,
        List<AppointmentDto> Appointments,
        List<FeedbackDto> Feedbacks
    );
}
