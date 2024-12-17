using RepairPK.Contracts;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext context) : base(context) { }
        public IEnumerable<Customer> GetAllCustomer(bool trachChanges)
        {
            return FindAll(trachChanges)
                .OrderBy(c => c.Id)
                .ToList();
        }
        public Customer GetCustomer(int id, bool trachChanges)
        {
            return FindByCondition(c => c.Id.Equals(id), trachChanges)
                .SingleOrDefault();
        }
    }
}
