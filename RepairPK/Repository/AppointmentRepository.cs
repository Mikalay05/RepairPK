using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        private readonly IMapper _mapper;
        public AppointmentRepository(RepositoryContext context, IMapper mapper) : base(context) 
        { 
            _mapper = mapper;
        }
        public IEnumerable<AppointmentDto> GetAllAppointments(bool trackChanges)
        {
            var appointments = FindAll(trackChanges)
                .OrderBy(c => c.Id)
                .ToList();

            var appointmentsDto = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            return appointmentsDto;
        }
        public AppointmentDto GetAppointment(int id, bool trackChanges)
        {
            var appointment = FindByCondition(a => a.Id.Equals(id), trackChanges)
                .SingleOrDefault();

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return appointmentDto;
        }

        public AppointmentDto CreateAppointment(int customerId,AppointmentForCreationDto appointment, bool trackChanges)
        {
            var customer = _context.Set<Customer>()
                .Where(c => c.Id.Equals(customerId))
                .AsNoTracking()
                .SingleOrDefault();

            if (customer is null)
            {
                throw new CustomerNotFound();
            }

            if (appointment is null)
            {
                throw new ArgumentNullException(nameof(appointment), "appointment cannot be null");
            }
            var appointmentEntity = _mapper.Map<Appointment>(appointment);
            appointmentEntity.CustomerId = customerId;

            Create(appointmentEntity);

            var appointmentToReturn = _mapper.Map<AppointmentDto>(appointmentEntity);
            return appointmentToReturn;

        }
    }
}
