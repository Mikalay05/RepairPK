namespace RepairPK.Dto
{
    public record PartDto(
        int Id,
        string Name,
        int QuantityAvailable,
        decimal Price
    );
}
