using RepairPK.Exception.AbstractException;

namespace RepairPK.Exception
{
    public class PartCollectionBadRequestException : BadRequestException
    {
        public PartCollectionBadRequestException() : base("Part object is null")
        {

        }
    }
}
