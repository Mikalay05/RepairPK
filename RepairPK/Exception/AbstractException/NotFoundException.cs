namespace RepairPK.Exception.AbstractException
{
    public abstract class NotFoundException : System.Exception
    {
        protected NotFoundException(string message) : base(message)
        {

        }
    }
}
