using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IRepairRepository
    {
        IEnumerable<RepairDto> GetAllRepairs(bool trackChanges);
        RepairDto GetRepair(int id, bool trackChanges);
        RepairDto CreateRepair(int hardwareId, int? partId, RepairForCreationDto repair, bool trackChanges);

        void DeleteRepair(int hardwareId, int? partId, int repairId, bool trackChanges);

    }
}
