using AutoMapper;
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
        public RepairDto CreateRepair(RepairForCreationDto  repairDto)
        {
            var  repairEntity = _mapper.Map<Repair>( repairDto);
            Create( repairEntity);
            var repairToReturn = _mapper.Map<RepairDto>( repairEntity);
            return  repairToReturn;
        }
    }
}
