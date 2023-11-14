using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.DTO;
using RestaurantReservation.Business.ServiceClass;
using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.API.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MenuItemService _menuItemService;

        public MenuItemController(IMapper mapper, MenuItemService menuItemService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _menuItemService = menuItemService ?? throw new ArgumentNullException(nameof(menuItemService));
        }
        [Authorize]
        [HttpGet("MenuItems")]
        public async Task<IActionResult> GetMenuItems()
        {
            var menuItems = await _menuItemService.GetAllMenuItemsAsync();
            var menuItemDTOs = _mapper.Map<IEnumerable<MenuItemDTO>>(menuItems);

            return Ok(menuItemDTOs);
        }
        [Authorize]
        [HttpGet("GetMenuItemById/{menuItemId}")]
        public async Task<IActionResult> GetMenuItemById(int menuItemId)
        {
            var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);

            if (menuItem is null)
            {
                return NotFound();
            }
            var menuItemDto = _mapper.Map<MenuItemDTO>(menuItem);

            return Ok(menuItemDto);
        }
        [Authorize]
        [HttpPost("AddMenuItem")]
        public async Task<IActionResult> CreateMenuItem([FromBody] MenuItemDTO menuItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newMenuItem = _mapper.Map<MenuItemDomain>(menuItemDto);

            await _menuItemService.CreateMenuItemAsync(newMenuItem);
            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateMenuItem/{menuItemId}")]
        public async Task<IActionResult> UpdateMenuItem(int menuItemId, [FromBody] MenuItemDTO menuItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingMenuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);

            if (existingMenuItem is null)
            {
                return NotFound();
            }
            try
            {
                var newMenuItem = _mapper.Map<MenuItemDomain>(menuItemDto);

                newMenuItem.ItemId = menuItemId;
                await _menuItemService.UpdateMenuItemAsync(newMenuItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize]
        [HttpDelete("DeleteMenuItem/{menuItemId}")]
        public async Task<IActionResult> DeleteMenuItem(int menuItemId)
        {
            var existingMenuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);

            if (existingMenuItem is null)
            {
                return NotFound();
            }
            await _menuItemService.DeleteMenuItemAsync(menuItemId);
            return NoContent();
        }
    }
}