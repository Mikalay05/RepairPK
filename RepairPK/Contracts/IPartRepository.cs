using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IPartRepository
    {
        // CRUD => C
        // CRUD => R
        // CRUD => U
        // CRUD => D
        IEnumerable<PartDto> GetAllPart(bool trackChanges);
        PartDto GetPart(int id, bool trackChanges);
        PartDto CreatePart(PartForCreationDto part);
        (IEnumerable<PartDto> parts, string ids) CreatePartCollection 
            (IEnumerable<PartForCreationDto> partsForCreation);

        IEnumerable<PartDto> GetByIds(IEnumerable<int> ids, bool trackChanges);

    }
}
