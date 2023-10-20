using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using RestaurantReservation.Db.EntityClass;
using Serilog;

namespace RestaurantReservation.Db.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<OrderDomain> GetOrderByIdAsync(int orderId)
        {
            try
            {
                var order = await _dbContext.Orders.FindAsync(orderId);

                return _mapper.Map<OrderDomain>(order);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while getting order by ID: {OrderId}", orderId);
                throw;
            }
        }
        public async Task CreateOrderAsync(OrderDomain order)
        {
            try
            {
                var orderEmtity = _mapper.Map<Order>(order);

                _dbContext.Orders.Add(orderEmtity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating an order");
                throw;
            }
        }
        public async Task UpdateOrderAsync(OrderDomain order)
        {
            try
            {
                var orderEntity=_mapper.Map<Order>(order);
                var existingOrder = await _dbContext.Orders.FindAsync(orderEntity.order_id);

                if (existingOrder is not null)
                {
                    _dbContext.Entry(existingOrder).CurrentValues.SetValues(order);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating an order");
                throw;
            }
        }
        public async Task DeleteOrderAsync(int orderId)
        {
            try
            {
                var order = await _dbContext.Orders.FindAsync(orderId);

                if (order is not null)
                {
                    _dbContext.Orders.Remove(order);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting an order with ID: {OrderId}", orderId);
                throw;
            }
        }
        public async Task<List<OrderDomain>> GetAllOrdersAsync()
        {
            try
            {
                var orders = await _dbContext.Orders.ToListAsync();
                var ordersDomain=orders.Select(o=>_mapper.Map<OrderDomain>(o)).ToList();

                return ordersDomain;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while getting all orders");
                throw;
            }
        }
        public async Task<List<OrderDomain>> ListOrdersAsync(int reservationId)
        {
            try
            {
                var orders = await _dbContext.Orders.Where(o => o.reservation_id == reservationId).ToListAsync();
                var ordersDomain = orders.Select(o => _mapper.Map<OrderDomain>(o)).ToList();

                return ordersDomain;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while listing orders for reservation: {ReservationId}", reservationId);
                throw;
            }
        }
    }
}