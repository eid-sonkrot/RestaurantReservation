using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Domain;
using RestaurantReservation.Domain.IRepository;
using Serilog;

namespace RestaurantReservation.Db.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MenuItemRepository(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<MenuItemDomain> GetMenuItemByIdAsync(int menuItemId)
        {
            try
            {
                var menuItem = await _dbContext.MenuItems.FindAsync(menuItemId);

                return _mapper.Map<MenuItemDomain>(menuItem);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while getting menu item by ID: {MenuItemId}", menuItemId);
                throw;
            }
        }
        public async Task CreateMenuItemAsync(MenuItemDomain menuItem)
        {
            try
            {
                var menuItemEntity = _mapper.Map<MenuItem>(menuItem);

                _dbContext.MenuItems.Add(menuItemEntity);
                await _dbContext.SaveChangesAsync();
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
                var menuItemEntity = _mapper.Map<MenuItem>(menuItem);

                _dbContext.Entry(menuItemEntity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
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
                var menuItem = await _dbContext.MenuItems.FindAsync(menuItemId);

                if (menuItem is not null)
                {
                    _dbContext.MenuItems.Remove(menuItem);
                    await _dbContext.SaveChangesAsync();
                }
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
                var menuItems = await _dbContext.MenuItems.ToListAsync();
                var menuItemsDomain = _mapper.Map<IEnumerable<MenuItemDomain>>(menuItems).ToList();

                return menuItemsDomain;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while getting all menu items");
                throw;
            }
        }
        public async Task<List<MenuItemDomain>> ListOrderedMenuItemsAsync(int reservationId)
        {
            try
            {
                var orderedMenuItems = await _dbContext.Orders
                    .Where(o => o.ReservationId == reservationId)
                    .Select(o => o.Item)
                    .Select(o=>o.Item)
                    .ToListAsync();
                var orderedMenuItemsDomain = orderedMenuItems.Select(o => _mapper.Map<MenuItemDomain>(o)).ToList();

                return orderedMenuItemsDomain;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while listing ordered menu items for reservation with ID: {ReservationId}", reservationId);
                throw;
            }
        }
    }
}