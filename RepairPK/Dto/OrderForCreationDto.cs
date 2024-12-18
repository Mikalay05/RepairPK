namespace RepairPK.Dto
{
    public record OrderForCreationDto(
        decimal TotalAmount,
        DateTime CompletionDate,
        bool PaymentStatus,
        int CustomerId
    );
}
