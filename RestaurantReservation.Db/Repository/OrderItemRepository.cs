using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using RestaurantReservation.Db.EntityClass;
using Serilog;

namespace RestaurantReservation.Db.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderItemRepository(RestaurantReservationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<OrderItemDomain> GetOrderItemByIdAsync(int orderItemId)
        {
            try
            {
                var orderItem = await _dbContext.OrderItems.FindAsync(orderItemId);
                
                return _mapper.Map<OrderItemDomain>(orderItem);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while getting order item by ID: {OrderItemId}", orderItemId);
                throw;
            }
        }
        public async Task CreateOrderItemAsync(OrderItemDomain orderItem)
        {
            try
            {
                var orderItemEntity=_mapper.Map<OrderItem>(orderItem);

                _dbContext.OrderItems.Add(orderItemEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating order item");
                throw;
            }
        }
        public async Task UpdateOrderItemAsync(OrderItemDomain orderItem)
        {
            try
            {
                var orderItemEntity = _mapper.Map<OrderItem>(orderItem);

                _dbContext.Entry(orderItem).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating order item with ID: {OrderItemId}", orderItem.OrderItemId);
                throw;
            }
        }
        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            try
            {
                var orderItem = await _dbContext.OrderItems.FindAsync(orderItemId);

                if (orderItem is not null)
                {
                    _dbContext.OrderItems.Remove(orderItem);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting order item with ID: {OrderItemId}", orderItemId);
                throw;
            }
        }
        public async Task<List<OrderItemDomain>> GetAllOrderItemsAsync()
        {
            try
            {
                var orderItems = await _dbContext.OrderItems.ToListAsync();
                var orderItemsDomain = orderItems.Select(o => _mapper.Map<OrderItemDomain>(o)).ToList();

                return orderItemsDomain;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while getting all order items");
                throw;
            }
        }
    }
}
