using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext context) : base(context) { }
        public IEnumerable<CustomerDto> GetAllCustomer(bool trachChanges)
        {
            var customers = FindAll(trachChanges)
                .OrderBy(c => c.Id)
                .ToList();

            var customersDto = customers.Select(c =>

                new CustomerDto(c.Id, c.Name, c.PhoneNumber))
                .ToList();

            return customersDto;
        }
        public CustomerDto GetCustomer(int id, bool trachChanges)
        {
            var customer = FindByCondition(c => c.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var customerDto = new CustomerDto(customer.Id, customer.Name, customer.PhoneNumber);
            return customerDto;
        }
    }
}
