using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Dto.ForUpdateDto;
using RepairPK.Models;
using RepairPK.Exception;
using RepairPK.Exception.AbstractException;

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
                .SingleOrDefault() ?? throw new CustomerNotFoundExeption(id);
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
        public IEnumerable<CustomerDto> GetByIds(IEnumerable<int> ids, bool trachChanges)
        {
            if(ids is null)
            {
                throw new IdBadRequestException();
            }

            var customersEntities = FindByCondition(c=> ids.Contains(c.Id), trachChanges).ToList();

            if (ids.Count() != customersEntities.Count())
                throw new IdMismatchRequestException();

            var customersToReturn = _mapper.Map<IEnumerable<CustomerDto>>(customersEntities);

            return customersToReturn;
        }

        public void UpdateCustomer(int customerId, CustomerForUpdateDto customerForUpdate, bool trackChanges)
        {

            var customer = _context.Set<Customer>()
                .Where(c => c.Id.Equals(customerId))
                .AsNoTracking()
                .SingleOrDefault() ?? throw new CustomerNotFoundExeption(customerId); ;

            var customerEntity = FindByCondition(c => c.Id.Equals(customer.Id), trackChanges)
                .SingleOrDefault() ?? throw new CustomerNotFoundExeption(customerId); ;

            _mapper.Map(customerForUpdate, customerEntity);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int customerId, bool trackChanges)
        {
            var customer = _context.Set<Customer>()
                .Where(c => c.Id.Equals(customerId))
                .AsNoTracking()
                .SingleOrDefault() ?? throw new CustomerNotFoundExeption(customerId);;

            Delete(customer);
            _context.SaveChanges();
        }
    }
}
