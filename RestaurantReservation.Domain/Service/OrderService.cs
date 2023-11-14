using RestaurantReservation.Domain.Domain;
using RestaurantReservation.Domain.IRepository;
using Serilog;

namespace RestaurantReservation.Business.ServiceClass
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderDomain> GetOrderByIdAsync(int orderId)
        {
            try
            {
                return await _orderRepository.GetOrderByIdAsync(orderId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching order with ID: {OrderId}", orderId);
                throw;
            }
        }
        public async Task CreateOrderAsync(OrderDomain orderDomain)
        {
            try
            {
                await _orderRepository.CreateOrderAsync(orderDomain);
                Log.Information("Order {OrderId} created successfully", orderDomain.OrderId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating order");
                throw;
            }
        }
        public async Task UpdateOrderAsync(OrderDomain orderDomain)
        {
            try
            {
                await _orderRepository.UpdateOrderAsync(orderDomain);
                Log.Information("Order {OrderId} updated successfully", orderDomain.OrderId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating order with ID: {OrderId}", orderDomain.OrderId);
                throw;
            }
        }
        public async Task DeleteOrderAsync(int orderId)
        {
            try
            {
                await _orderRepository.DeleteOrderAsync(orderId);
                Log.Information("Order {OrderId} deleted successfully", orderId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting order with ID: {OrderId}", orderId);
                throw;
            }
        }
        public async Task<List<OrderDomain>> GetAllOrdersAsync()
        {
            try
            {
                return await _orderRepository.GetAllOrdersAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all orders");
                throw;
            }
        }
        public async Task<List<OrderDomain>> ListOrdersAsync(int reservationId)
        {
            try
            {
                return await _orderRepository.ListOrdersAsync(reservationId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while listing orders for reservation {ReservationId}", reservationId);
                throw;
            }
        }
    }
}