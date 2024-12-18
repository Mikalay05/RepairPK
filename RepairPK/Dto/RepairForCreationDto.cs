namespace RepairPK.Dto
{
    public record RepairForCreationDto(
        int HardwareId,
        DateTime RepairDate,
        string Description,
        decimal Cost,
        int? CountPart
    );
}
