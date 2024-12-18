namespace RepairPK.Dto
{
    public record HardwareForCreationDto(
        string Manufacturer,
        string Model,
        string SerialNumber,
        string Type,
        int OrderId
    );
}
