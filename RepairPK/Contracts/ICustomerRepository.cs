using RepairPK.Models;

namespace RepairPK.Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomer(bool trachChanges);
        Customer GetCustomer(int id, bool trackChanges);
    }
}
