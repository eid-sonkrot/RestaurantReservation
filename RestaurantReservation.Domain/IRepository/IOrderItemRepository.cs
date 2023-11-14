using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.Domain.IRepository
{
    public interface IOrderItemRepository
    {
        Task<OrderItemDomain> GetOrderItemByIdAsync(int orderItemId);
        Task CreateOrderItemAsync(OrderItemDomain orderItem);
        Task UpdateOrderItemAsync(OrderItemDomain orderItem);
        Task DeleteOrderItemAsync(int orderItemId);
        Task<List<OrderItemDomain>> GetAllOrderItemsAsync();
    }
}
