namespace RepairPK.Models.Exception
{
    public class CustomerNotFoundException: BadRequestException
    {
        public CustomerNotFoundException(int customerId) : base($"Customer id = {customerId} not foubd")
        {
            
        }
    }
}
