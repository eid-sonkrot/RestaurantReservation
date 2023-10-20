using RestaurantReservation.Business.DomainClass;

namespace RestaurantReservation.Business.IRepository
{
    public interface IMenuItemRepository
    {
        Task<MenuItemDomain> GetMenuItemByIdAsync(int menuItemId);
        Task CreateMenuItemAsync(MenuItemDomain menuItem);
        Task UpdateMenuItemAsync(MenuItemDomain menuItem);
        Task DeleteMenuItemAsync(int menuItemId);
        Task<List<MenuItemDomain>> GetAllMenuItemsAsync();
        Task<List<MenuItemDomain>> ListOrderedMenuItemsAsync(int reservationId);
    }
}
