using RepairPK.Exception.AbstractException;

namespace RepairPK.Exception
{
    public sealed class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(int customerId) : base($"Customer id = {customerId} not foubd")
        {

        }
    }
}
