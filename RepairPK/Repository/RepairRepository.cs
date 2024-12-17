using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class RepairRepository : RepositoryBase<Repair>, IRepairRepository
    {
        public RepairRepository(RepositoryContext context) : base(context) { }
        public IEnumerable<RepairDto> GetAllRepairs(bool trachChanges)
        {
            var repairs = FindAll(trachChanges)
                .OrderBy(r => r.Id)
                .ToList();

            var repairsDto = repairs.Select(r =>

                new RepairDto(
                    r.Id,
                    r.HardwareId,
                    r.RepairDate,
                    r.Description,
                    r.Cost,
                    r.PartId,
                    r.CountPart
                    ))
                .ToList();

            return repairsDto;
        }
        public RepairDto GetRepair(int id, bool trachChanges)
        {
            var repair = FindByCondition(r => r.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var repairDto = new RepairDto(
                    repair.Id,
                    repair.HardwareId,
                    repair.RepairDate,
                    repair.Description,
                    repair.Cost,
                    repair.PartId,
                    repair.CountPart
                );
            return repairDto;
        }
    }
}
