using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDto> GetAllCustomer(bool trackChanges);
        CustomerDto GetCustomer(int id, bool trackChanges);
        IEnumerable<CustomerDto> GetByIds(IEnumerable<int> ids, bool trackChanges);
        CustomerDto CreateCustomer(CustomerForCreationDto customer);

    }
}
