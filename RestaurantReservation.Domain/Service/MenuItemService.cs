using RestaurantReservation.Domain.Domain;
using RestaurantReservation.Domain.IRepository;
using Serilog;

namespace RestaurantReservation.Business.ServiceClass
{
    public class MenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }
        public async Task<MenuItemDomain> GetMenuItemByIdAsync(int menuItemId)
        {
            try
            {
                var menuItem = await _menuItemRepository.GetMenuItemByIdAsync(menuItemId);

                if (menuItem is null)
                {
                    Log.Information("Menu item with ID {MenuItemId} not found", menuItemId);
                    return null;
                }
                Log.Information("Menu item {MenuItemId} retrieved successfully", menuItemId);
                return menuItem;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching menu item with ID: {MenuItemId}", menuItemId);
                throw;
            }
        }
        public async Task CreateMenuItemAsync(MenuItemDomain menuItem)
        {
            try
            {
                await _menuItemRepository.CreateMenuItemAsync(menuItem);
                Log.Information("Menu item {MenuItemId} created successfully", menuItem.ItemId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating menu item");
                throw;
            }
        }
        public async Task UpdateMenuItemAsync(MenuItemDomain menuItem)
        {
            try
            {
                await _menuItemRepository.UpdateMenuItemAsync(menuItem);
                Log.Information("Menu item {MenuItemId} updated successfully", menuItem.ItemId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating menu item with ID: {MenuItemId}", menuItem.ItemId);
                throw;
            }
        }
        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            try
            {
                await _menuItemRepository.DeleteMenuItemAsync(menuItemId);
                Log.Information("Menu item {MenuItemId} deleted successfully", menuItemId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting menu item with ID: {MenuItemId}", menuItemId);
                throw;
            }
        }
        public async Task<List<MenuItemDomain>> GetAllMenuItemsAsync()
        {
            try
            {
                var menuItems = await _menuItemRepository.GetAllMenuItemsAsync();

                Log.Information("Retrieved all menu items successfully");
                return menuItems;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all menu items");
                throw;
            }
        }
        public async Task<List<MenuItemDomain>> ListOrderedMenuItemsAsync(int reservationId)
        {
            try
            {
                var orderedMenuItems = await _menuItemRepository.ListOrderedMenuItemsAsync(reservationId);
                return orderedMenuItems;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while listing ordered menu items for reservation {ReservationId}", reservationId);
                throw;
            }
        }
    }
}