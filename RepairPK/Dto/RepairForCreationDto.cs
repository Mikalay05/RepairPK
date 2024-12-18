namespace RepairPK.Dto
{
    public record RepairForCreationDto(
        DateTime RepairDate,
        string Description,
        decimal Cost,
        int? CountPart
    );
}
