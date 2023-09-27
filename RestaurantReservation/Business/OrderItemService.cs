using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Db;
using Serilog;

namespace RestaurantReservation.Business
{
    public class OrderItemService
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderItemService(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<OrderItemDTO> GetOrderItemByIdAsync(int orderItemId)
        {
            try
            {
                var orderItem = await _dbContext.OrderItems.FindAsync(orderItemId);

                Log.Information("OrderItem {OrderItemId} retrieved successfully", orderItemId);
                return _mapper.Map<OrderItemDTO>(orderItem);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching order item with ID: {OrderItemId}", orderItemId);
                throw;
            }
        }
        public async Task CreateOrderItemAsync(OrderItemDTO orderItemDTO)
        {
            try
            {
                var newOrderItem = _mapper.Map<OrderItem>(orderItemDTO);
                _dbContext.OrderItems.Add(newOrderItem);
                await _dbContext.SaveChangesAsync();

                Log.Information("OrderItem {OrderItemId} created successfully", newOrderItem.order_item_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating order item");
                throw;
            }
        }
        public async Task UpdateOrderItemAsync(OrderItemDTO orderItemDTO)
        {
            try
            {
                var existingOrderItem = await _dbContext.OrderItems.FindAsync(orderItemDTO.OrderItemId);

                if (existingOrderItem is not null)
                {
                    _mapper.Map(orderItemDTO, existingOrderItem);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("OrderItem {OrderItemId} updated successfully", orderItemDTO.OrderItemId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating order item with ID: {OrderItemId}", orderItemDTO.OrderItemId);
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

                    Log.Information("OrderItem {OrderItemId} deleted successfully", orderItemId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting order item with ID: {OrderItemId}", orderItemId);
                throw;
            }
        }
        public async Task<List<OrderItemDTO>> GetAllOrderItemsAsync()
        {
            try
            {
                var orderItems = await _dbContext.OrderItems.ToListAsync();
                var orderItemDTOs = _mapper.Map<List<OrderItemDTO>>(orderItems);

                Log.Information("Retrieved all order items successfully");
                return orderItemDTOs;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all order items");
                throw;
            }
        }
    }
}