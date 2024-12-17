namespace RepairPK.Dto
{
    public record FeedbackDto(
        int Id,
        int CustomerId,
        string CustomerName,
        short Rating,
        string Comment,
        DateTime Date
    );
}
