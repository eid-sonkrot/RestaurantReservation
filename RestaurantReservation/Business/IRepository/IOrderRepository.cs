using RestaurantReservation.Business.DomainClass;

namespace RestaurantReservation.Business.IRepository
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