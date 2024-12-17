﻿using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IRepairRepository
    {
        IEnumerable<RepairDto> GetAllRepairs(bool trackChanges);
        RepairDto GetRepair(int id, bool trackChanges);
    }
}