namespace RepairPK.Dto
{
    public record OrderDto(
        int Id,
        decimal TotalAmount,
        DateTime CompletionDate,
        bool PaymentStatus,
        int CustomerId,
        string CustomerName,
        List<HardwareDto> Hardwares
    );
}
