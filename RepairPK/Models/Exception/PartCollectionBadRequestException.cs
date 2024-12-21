namespace RepairPK.Models.Exception
{
    public class PartCollectionBadRequestException : BadRequestException
    {
        public PartCollectionBadRequestException() : base("Part object is null")
        {
            
        }
    }
}
