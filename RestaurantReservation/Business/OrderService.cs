using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Db;

namespace RestaurantReservation.Business
{
    public class OrderService
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderService(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<OrderDTO> GetOrderByIdAsync(int orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);

            return _mapper.Map<OrderDTO>(order);
        }
        public async Task CreateOrderAsync(OrderDTO orderDTO)
        {
            var newOrder = _mapper.Map<Order>(orderDTO);
            _dbContext.Orders.Add(newOrder);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateOrderAsync(OrderDTO orderDTO)
        {
            var existingOrder = await _dbContext.Orders.FindAsync(orderDTO.OrderId);

            if (existingOrder is not null)
            {
                _mapper.Map(orderDTO, existingOrder);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);

            if (order is not null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _dbContext.Orders.ToListAsync();

            return _mapper.Map<List<OrderDTO>>(orders);
        }
    }
}