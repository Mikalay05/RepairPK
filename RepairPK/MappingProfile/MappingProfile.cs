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
        }
    }
}
