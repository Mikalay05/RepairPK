namespace RepairPK.Models.Exception
{
    public class PartNotFoundException : BadRequestException
    {
        public PartNotFoundException(int partId) : base($"Part id = {partId}not found")
        {
            
        }
    }
}
