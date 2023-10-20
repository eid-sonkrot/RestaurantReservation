using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using Serilog;

namespace RestaurantReservation.Business.ServiceClass
{
    public class OrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        public async Task<OrderItemDomain> GetOrderItemByIdAsync(int orderItemId)
        {
            try
            {
                return await _orderItemRepository.GetOrderItemByIdAsync(orderItemId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching order item with ID: {OrderItemId}", orderItemId);
                throw;
            }
        }
        public async Task CreateOrderItemAsync(OrderItemDomain orderItem)
        {
            try
            {
                await _orderItemRepository.CreateOrderItemAsync(orderItem);
                Log.Information("OrderItem {OrderItemId} created successfully", orderItem.OrderItemId);
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
                await _orderItemRepository.UpdateOrderItemAsync(orderItem);
                Log.Information("OrderItem {OrderItemId} updated successfully", orderItem.OrderItemId);
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
                await _orderItemRepository.DeleteOrderItemAsync(orderItemId);
                Log.Information("OrderItem {OrderItemId} deleted successfully", orderItemId);
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
                return await _orderItemRepository.GetAllOrderItemsAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all order items");
                throw;
            }
        }
    }
}