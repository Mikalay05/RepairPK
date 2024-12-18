using AutoMapper;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class PartRepository : RepositoryBase<Part>, IPartRepository
    {
        private readonly IMapper _mapper;

        public PartRepository(RepositoryContext context, IMapper mapper) : base(context) { _mapper = mapper; }
        public IEnumerable<PartDto> GetAllPart(bool trachChanges)
        {
            var parts = FindAll(trachChanges)
                .OrderBy(c => c.Id)
                .ToList();

            var partsDto = _mapper.Map<IEnumerable<PartDto>>(parts);

            return partsDto;
        }
        public PartDto GetPart(int id, bool trachChanges)
        {
            var part = FindByCondition(c => c.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var partDto = _mapper.Map<PartDto>(part);
            return partDto;
        }
    }
}
