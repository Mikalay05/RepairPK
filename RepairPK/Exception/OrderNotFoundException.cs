using RepairPK.Exception.AbstractException;

namespace RepairPK.Exception
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(int orderId) : base($"Order id = {orderId} not foubd")
        {

        }
    }
}
