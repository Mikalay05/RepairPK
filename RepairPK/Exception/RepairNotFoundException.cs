using RepairPK.Exception.AbstractException;

namespace RepairPK.Exception
{
    public class RepairNotFoundException : NotFoundException
    {
        public RepairNotFoundException(int repairId) : base($"Reapir id = ${repairId} not foubd")
        {

        }
    }
}
