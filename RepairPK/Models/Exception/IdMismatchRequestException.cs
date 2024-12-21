namespace RepairPK.Models.Exception
{
    public sealed class IdMismatchRequestException : BadRequestException
    {
        public IdMismatchRequestException(): base("Collection count mismatch compared to ids")
        {
            
        }
    }
}
