using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.Domain.IRepository
{
    public interface IOrderRepository
    {
        Task<OrderDomain> GetOrderByIdAsync(int orderId);
        Task CreateOrderAsync(OrderDomain orderDomain);
        Task UpdateOrderAsync(OrderDomain orderDomain);
        Task DeleteOrderAsync(int orderId);
        Task<List<OrderDomain>> GetAllOrdersAsync();
        Task<List<OrderDomain>> ListOrdersAsync(int reservationId);
    }
}
