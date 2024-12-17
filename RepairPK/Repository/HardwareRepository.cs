using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class HardwareRepository : RepositoryBase<Hardware>, IHardwareRepository
    {
        public HardwareRepository(RepositoryContext context) : base(context) { }
        public IEnumerable<HardwareDto> GetAllHardwares(bool trachChanges)
        {
            var hardwares = FindAll(trachChanges)
                .OrderBy(h => h.Id)
                .ToList();

            var hardwaresDto = hardwares.Select(h =>

                new HardwareDto(h.Id, h.Manufacturer, h.Model, h.SerialNumber, h.Type, h.OrderId))
                .ToList();

            return hardwaresDto;
        }
        public HardwareDto GetHardware(int id, bool trachChanges)
        {
            var hardware = FindByCondition(h => h.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var hardwareDto = new HardwareDto(hardware.Id, hardware.Manufacturer, hardware.Model, hardware.SerialNumber, hardware.Type, hardware.OrderId);
            return hardwareDto;
        }
    }
}
