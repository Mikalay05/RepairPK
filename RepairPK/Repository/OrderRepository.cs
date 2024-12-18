﻿using AutoMapper;
using RepairPK.Contracts;
using RepairPK.Dto;
using RepairPK.Models;

namespace RepairPK.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly IMapper _mapper;

        public OrderRepository(RepositoryContext context, IMapper mapper) : base(context) { _mapper = mapper; }
        public IEnumerable<OrderDto> GetAllOrders(bool trachChanges)
        {
            var orders = FindAll(trachChanges)
                .OrderBy(o => o.Id)
                .ToList();

            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return ordersDto;
        }
        public OrderDto GetOrder(int id, bool trachChanges)
        {
            var order = FindByCondition(o => o.Id.Equals(id), trachChanges)
                .SingleOrDefault();

            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }
        public OrderDto CreateOrder(OrderForCreationDto orderDto)
        {
            var orderEntity = _mapper.Map<Order>(orderDto);
            Create(orderEntity);
            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);
            return orderToReturn;
        }
    }
}
