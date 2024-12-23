using RepairPK.Exception.AbstractException;

namespace RepairPK.Exception
{
    public class HardwareNotFoundException : NotFoundException
    {
        public HardwareNotFoundException(int hardwareId) : base($"Hardware id = {hardwareId} not found ")
        {

        }
    }
}
