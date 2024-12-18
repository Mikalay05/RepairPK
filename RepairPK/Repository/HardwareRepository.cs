using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

            var hardwareDto = _mapper.Map<HardwareDto>(hardware);
            return hardwareDto;
        }
        public HardwareDto CreateHardware( int orderId,HardwareForCreationDto hardware, bool trackChanges)
        {
            var order = _context.Set<Order>()
                .Where(o => o.Id.Equals(orderId))
                .AsNoTracking()
                .SingleOrDefault();

            if (order is null)
            {
                throw new CustomerNotFound();
            }

            if (hardware is null)
            {
                throw new ArgumentNullException(nameof(hardware), "hardware cannot be null");
            }
            var hardwareEntity = _mapper.Map<Hardware>(hardware);
            hardwareEntity.OrderId = orderId;

            Create(hardwareEntity);

            var hardwareToReturn = _mapper.Map<HardwareDto>(hardwareEntity);
            return hardwareToReturn;
        }
    }
}
