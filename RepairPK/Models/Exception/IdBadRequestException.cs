﻿namespace RepairPK.Models.Exception
{
    public sealed class  IdBadRequestException : BadRequestException
    {
        public IdBadRequestException(): base("One or more ID sent by a client is invalid")
        {
            
        }
    }
}
