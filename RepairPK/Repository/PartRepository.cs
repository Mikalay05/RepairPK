using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class PartRepository : RepositoryBase<Part>, IPartRepository
    {
        public PartRepository(RepositoryContext context) : base(context) { }
        public IEnumerable<PartDto> GetAllPart(bool trachChanges)
        {
            var parts = FindAll(trachChanges)
                .OrderBy(c => c.Id)
                .ToList();

            var partsDto = parts.Select(p =>

                new PartDto(p.Id, p.Name, p.QuantityAvailable, p.Price))
                .ToList();

            return partsDto;
        }
        public PartDto GetPart(int id, bool trachChanges)
        {
            var part = FindByCondition(c => c.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var partDto = new PartDto(part.Id, part.Name, part.QuantityAvailable, part.Price);
            return partDto;
        }
    }
}
