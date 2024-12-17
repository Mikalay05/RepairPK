namespace RepairPK.Dto
{
    public record RepairDto(
        int Id,
        int HardwareId,
        string HardwareType,
        DateTime RepairDate,
        string Description,
        decimal Cost,
        int? PartId,
        string? PartName,
        int? CountPart
    );
}
