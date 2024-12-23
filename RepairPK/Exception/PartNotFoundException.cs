using RepairPK.Exception.AbstractException;

namespace RepairPK.Exception
{
    public class PartNotFoundException : NotFoundException
    {
        public PartNotFoundException(int partId) : base($"Part id = {partId}not found")
        {

        }
    }
}
