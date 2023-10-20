using RestaurantReservation.Business.DomainClass;

namespace RestaurantReservation.Business.IRepository
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
