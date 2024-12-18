using AutoMapper;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.MappingProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<Feedback, FeedbackDto>();
            CreateMap<Hardware, HardwareDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Part, PartDto>();
            CreateMap<Repair, RepairDto>();
        }
    }
}
