using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;
using RepairPK.Exception;

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
        public void DeleteRepair(int hardwareId, int? partId, int repairId, bool trackChanges)
        {
            var hardware = _context.Set<Hardware>()
                .Where(h => h.Id.Equals(hardwareId))
                .AsNoTracking()
                .SingleOrDefault();

            if (hardware is null)
                throw new HardwareNotFoundException(hardwareId);

            Part? part = null;
            if (partId.HasValue)
            {
                part = _context.Set<Part>()
                    .Where(p => p.Id.Equals(partId.Value))
                    .AsNoTracking()
                    .SingleOrDefault();

                if (part is null)
                    throw new PartNotFoundException(partId.Value);
            }

            var repair = _context.Set<Repair>()
                .Where(r => r.Id.Equals(repairId))
                .AsNoTracking()
                .SingleOrDefault();

            if (repair is null)
                throw new RepairNotFoundException(repairId);

            Delete(repair);
            _context.SaveChanges();
        }

    }
}
