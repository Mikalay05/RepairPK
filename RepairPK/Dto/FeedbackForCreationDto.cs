namespace RepairPK.Dto
{
    public record FeedbackForCreationDto(
        int CustomerId,
        short Rating,
        string Comment,
        DateTime Date
    );
}
