using AutoMapper;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class HardwareRepository : RepositoryBase<Hardware>, IHardwareRepository
    {
        private readonly IMapper _mapper;

        public HardwareRepository(RepositoryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<HardwareDto> GetAllHardwares(bool trachChanges)
        {
            var hardwares = FindAll(trachChanges)
                .OrderBy(h => h.Id)
                .ToList();

            var hardwaresDto = _mapper.Map<IEnumerable<HardwareDto>>(hardwares);

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
