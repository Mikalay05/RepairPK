using AutoMapper;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;
using RepairPK.Exception;

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
        public PartDto CreatePart(PartForCreationDto partDto)
        {
            var partEntity = _mapper.Map<Part>(partDto);
            Create(partEntity);
            var partToReturn = _mapper.Map<PartDto>(partEntity);
            return partToReturn;
        }

        public (IEnumerable<PartDto> parts, string ids) CreatePartCollection(IEnumerable<PartForCreationDto> partsForCreation)
        {
            if(partsForCreation is null)
            {
                throw new PartCollectionBadRequestException();
            }
            var partsEntities = _mapper.Map<IEnumerable<Part>>(partsForCreation);
            foreach (var partEntity in partsEntities)
            {
                Create(partEntity);
            }
            _context.SaveChanges();

            var partCollectionResult = _mapper.Map<IEnumerable<PartDto>>(partsEntities);
            var ids = string.Join(',', partCollectionResult.Select(p=>p.Id));

            return (parts: partCollectionResult, ids: ids);
        }

        public IEnumerable<PartDto> GetByIds(IEnumerable<int> ids, bool trackChanges)
        {
            if(ids is null)
            {
                throw new IdBadRequestException();
            }

            var partsEntities = FindByCondition(p => ids.Contains(p.Id), trackChanges).ToList();

            if (ids.Count() != partsEntities.Count())
                throw new IdMismatchRequestException();

            var partsToReturn = _mapper.Map<IEnumerable<PartDto>>(partsEntities);

            return partsToReturn;

        }
    }
}
