using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Db;
using Serilog;

namespace RestaurantReservation.Business
{
    public class MenuItemService
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MenuItemService(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MenuItemDTO> GetMenuItemByIdAsync(int menuItemId)
        {
            try
            {
                var menuItem = await _dbContext.MenuItems.FindAsync(menuItemId);

                Log.Information("MenuItem {MenuItemId} retrieved successfully", menuItemId);
                return _mapper.Map<MenuItemDTO>(menuItem);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching menu item with ID: {MenuItemId}", menuItemId);
                throw;
            }
        }

        public async Task CreateMenuItemAsync(MenuItemDTO menuItemDTO)
        {
            try
            {
                var newMenuItem = _mapper.Map<MenuItem>(menuItemDTO);
                _dbContext.MenuItems.Add(newMenuItem);
                await _dbContext.SaveChangesAsync();

                Log.Information("MenuItem {MenuItemId} created successfully", newMenuItem.item_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating menu item");
                throw;
            }
        }

        public async Task UpdateMenuItemAsync(MenuItemDTO menuItemDTO)
        {
            try
            {
                var existingMenuItem = await _dbContext.MenuItems.FindAsync(menuItemDTO.ItemId);
                if (existingMenuItem is not null)
                {
                    _mapper.Map(menuItemDTO, existingMenuItem);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("MenuItem {MenuItemId} updated successfully", menuItemDTO.ItemId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating menu item with ID: {MenuItemId}", menuItemDTO.ItemId);
                throw;
            }
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            try
            {
                var menuItem = await _dbContext.MenuItems.FindAsync(menuItemId);
                if (menuItem is not null)
                {
                    _dbContext.MenuItems.Remove(menuItem);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("MenuItem {MenuItemId} deleted successfully", menuItemId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting menu item with ID: {MenuItemId}", menuItemId);
                throw;
            }
        }

        public async Task<List<MenuItemDTO>> GetAllMenuItemsAsync()
        {
            try
            {
                var menuItems = await _dbContext.MenuItems.ToListAsync();
                var menuItemDTOs = _mapper.Map<List<MenuItemDTO>>(menuItems);

                Log.Information("Retrieved all menu items successfully");
                return menuItemDTOs;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all menu items");
                throw;
            }
        }
        public async Task<List<MenuItemDTO>> ListOrderedMenuItemsAsync(int reservationId)
        {
            try
            {
                var orderedMenuItems = await _dbContext.Orders
                    .Where(o => o.reservation_id == reservationId)
                    .SelectMany(o => o.items.Select(it => it.item))
                    .ToListAsync();
                var orderedMenuItemsDTO = _mapper.Map<List<MenuItemDTO>>(orderedMenuItems);

                return orderedMenuItemsDTO;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while listing ordered menu items for reservation {ReservationId}", reservationId);

                // You can choose to rethrow the exception or handle it as needed.
                throw;
            }
        }

    }
}