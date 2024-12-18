namespace RepairPK.Dto
{
    public record PartForCreationDto(
        string Name,
        int QuantityAvailable,
        decimal Price
    );
}
