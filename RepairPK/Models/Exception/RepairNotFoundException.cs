namespace RepairPK.Models.Exception
{
    public class RepairNotFoundException: BadRequestException
    {
        public RepairNotFoundException(int repairId) : base($"Reapir id = ${repairId} not foubd" )
        {
            
        }
    }
}
