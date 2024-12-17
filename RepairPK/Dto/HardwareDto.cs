namespace RepairPK.Dto
{
    public record HardwareDto(
        int Id,
        string Manufacturer,
        string Model,
        string SerialNumber,
        string Type,
        int OrderId
    );
}
