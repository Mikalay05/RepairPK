namespace RepairPK.Exception.AbstractException
{
    public abstract class BadRequestException : System.Exception
    {
        protected BadRequestException(string message) : base(message)
        {

        }
    }
}
