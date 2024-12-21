namespace RepairPK.Models.Exception
{
    public class HardwareNotFoundException : BadRequestException
    {
        public HardwareNotFoundException(int hardwareId) : base($"Hardware id = {hardwareId} not found ")
        {
            
        }
    }
}
