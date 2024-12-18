using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IHardwareRepository
    {
        IEnumerable<HardwareDto> GetAllHardwares(bool trackChanges);
        HardwareDto GetHardware(int id, bool trackChanges);
        HardwareDto CreateHardware(int orderId, HardwareForCreationDto hardware, bool trackChanges);

    }
}
