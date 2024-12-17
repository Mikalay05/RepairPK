using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IHardwareRepository
    {
        IEnumerable<HardwareDto> GetAllHardwares(bool trackChanges);
        HardwareDto GetHardware(int id, bool trackChanges);
    }
}
