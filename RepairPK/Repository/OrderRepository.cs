using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public OrderDto CreateOrder(int customerId, OrderForCreationDto order, bool trackChanges)
        {
            var customer = _context.Set<Customer>()
                .Where(c => c.Id.Equals(customerId))
                .AsNoTracking()
                .SingleOrDefault();

            if (customer is null)
            {
                throw new CustomerNotFound();
            }

            if (order is null)
            {
                throw new ArgumentNullException(nameof(order), "order cannot be null");
            }
            var orderEntity = _mapper.Map<Order>(order);
            orderEntity.CustomerId = customerId;

            Create(orderEntity);

            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);
            return orderToReturn;
        }
    }
}
