namespace RepairPK.Dto
{
    public record FeedbackDto(
        int Id,
        int CustomerId,
        short Rating,
        string Comment,
        DateTime Date
    );
}
