namespace RepairPK.Dto
{
    public record FeedbackForCreationDto(
        short Rating,
        string Comment,
        DateTime Date
    );
}
