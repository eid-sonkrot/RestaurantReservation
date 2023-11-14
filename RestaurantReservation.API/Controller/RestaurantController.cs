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
    public class RestaurantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly RestaurantService _restaurantService;

        public RestaurantController(IMapper mapper, RestaurantService restaurantService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _restaurantService = restaurantService ?? throw new ArgumentNullException(nameof(restaurantService));
        }
        [Authorize]
        [HttpGet("Restaurants")]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            var restaurantDTOs = _mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);

            return Ok(restaurantDTOs);
        }
        [Authorize]
        [HttpGet("GetRestaurantById/{restaurantId}")]
        public async Task<IActionResult> GetRestaurantById(int restaurantId)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(restaurantId);

            if (restaurant is null)
            {
                return NotFound();
            }
            var restaurantDto = _mapper.Map<RestaurantDTO>(restaurant);

            return Ok(restaurantDto);
        }
        [Authorize]
        [HttpPost("CreateRestaurant")]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantDTO restaurantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newRestaurant = _mapper.Map<RestaurantDomain>(restaurantDto);

            await _restaurantService.CreateRestaurantAsync(newRestaurant);
            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateRestaurant/{restaurantId}")]
        public async Task<IActionResult> UpdateRestaurant(int restaurantId, [FromBody] RestaurantDTO restaurantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingRestaurant = await _restaurantService.GetRestaurantByIdAsync(restaurantId);

            if (existingRestaurant is null)
            {
                return NotFound();
            }
            try
            {
                var updatedRestaurant = _mapper.Map<RestaurantDomain>(restaurantDto);

                updatedRestaurant.RestaurantId = restaurantId;
                await _restaurantService.UpdateRestaurantAsync(updatedRestaurant);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize]
        [HttpDelete("DeleteRestaurant/{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurant(int restaurantId)
        {
            var existingRestaurant = await _restaurantService.GetRestaurantByIdAsync(restaurantId);

            if (existingRestaurant is null)
            {
                return NotFound();
            }
            await _restaurantService.DeleteRestaurantAsync(restaurantId);
            return NoContent();
        }
    }
}