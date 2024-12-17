﻿using RepairPK.Dto;

namespace RepairPK.Contracts
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDto> GetAllOrders(bool trackChanges);
        OrderDto GetOrder(int id, bool trackChanges);
    }
}