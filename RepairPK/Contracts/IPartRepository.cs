using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IPartRepository
    {
        IEnumerable<PartDto> GetAllPart(bool trackChanges);
        PartDto GetPart(int id, bool trackChanges);
    }
}
