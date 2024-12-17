namespace RepairPK.Dto
{
    public record RepairDto(
        int Id,
        int HardwareId,
        DateTime RepairDate,
        string Description,
        decimal Cost,
        int? PartId,
        int? CountPart
    );
}
