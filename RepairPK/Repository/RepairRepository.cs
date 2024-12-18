using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class RepairRepository : RepositoryBase<Repair>, IRepairRepository
    {
        private readonly IMapper _mapper;

        public RepairRepository(RepositoryContext context, IMapper mapper) : base(context) { _mapper = mapper; }
        public IEnumerable<RepairDto> GetAllRepairs(bool trachChanges)
        {
            var repairs = FindAll(trachChanges)
                .OrderBy(r => r.Id)
                .ToList();

            var repairsDto = _mapper.Map<IEnumerable<RepairDto>>(repairs);

            return repairsDto;
        }
        public RepairDto GetRepair(int id, bool trachChanges)
        {
            var repair = FindByCondition(r => r.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var repairDto = _mapper.Map<RepairDto>(repair);
            return repairDto;
        }
        public RepairDto CreateRepair(int perentId ,int? partId, RepairForCreationDto  objectDto, bool trachChanges)
        {
            var perentObject = _context.Set<Hardware>()
                .Where(c => c.Id.Equals(perentId))
                .AsNoTracking()
                .SingleOrDefault();

            if (perentObject is null)
            {
                throw new DllNotFoundException();
            }


            if (partId != null)
            {
                var part = _context.Set<Part>()
                .Where(p => p.Id.Equals(partId))
                .AsNoTracking()
                .SingleOrDefault();

                if (part is null)
                {
                    throw new DllNotFoundException();
                }
            }



            if (objectDto is null)
            {
                throw new ArgumentNullException(nameof(objectDto), "Repair cannot be null");
            }
            var objectEntity = _mapper.Map<Repair>(objectDto);
            objectEntity.HardwareId = perentId;
            objectEntity.PartId = partId;

            Create(objectEntity);

            var objectToReturn = _mapper.Map<RepairDto>(objectEntity);
            return objectToReturn;
        }
    }
}
