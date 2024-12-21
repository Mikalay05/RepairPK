using RepairPK.Dto;
using RepairPK.Dto.ForUpdateDto;
using RepairPK.Models;

namespace RepairPK.Contracts
{
    public interface ICustomerRepository
    {
        // CRUD => C
        CustomerDto CreateCustomer(CustomerForCreationDto customer);

        // CRUD => R
        IEnumerable<CustomerDto> GetAllCustomer(bool trackChanges);
        CustomerDto GetCustomer(int id, bool trackChanges);
        IEnumerable<CustomerDto> GetByIds(IEnumerable<int> ids, bool trackChanges);
        // CRUD => U
        void UpdateCustomer(int customerId, CustomerForUpdateDto customerForUpdate,bool trackChanges);

        // CRUD => D
        void DeleteCustomer(int customerId, bool trackChanges);

    }
}
