using AutoMapper;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly IMapper _mapper;
        public CustomerRepository(RepositoryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<CustomerDto> GetAllCustomer(bool trachChanges)
        {
            var customers = FindAll(trachChanges)
                .OrderBy(c => c.Id)
                .ToList();

            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return customersDto;
        }
        public CustomerDto GetCustomer(int id, bool trachChanges)
        {
            var customer = FindByCondition(c => c.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }
        public CustomerDto CreateCustomer(CustomerForCreationDto customerDto)
        {
            var customerEntity = _mapper.Map<Customer>(customerDto);
            Create(customerEntity);
            var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);
            return customerToReturn;
        }
    }
}
