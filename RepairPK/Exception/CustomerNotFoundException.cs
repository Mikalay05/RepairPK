using RepairPK.Exception.AbstractException;

namespace RepairPK.Exception
{
    public sealed class CustomerNotFoundExeption : NotFoundException
    {
        public CustomerNotFoundExeption(int customerId) : base($"Customer id = {customerId} not foubd")
        {

        }
    }
}
