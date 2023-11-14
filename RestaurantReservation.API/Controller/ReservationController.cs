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
    public class ReservationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ReservationService _reservationService;

        public ReservationController(IMapper mapper, ReservationService reservationService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
        }
        [Authorize]
        [HttpGet("Reservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            var reservationDTOs = _mapper.Map<IEnumerable<ReservationDTO>>(reservations);

            return Ok(reservationDTOs);
        }
        [Authorize]
        [HttpGet("GetReservationById/{reservationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReservationById(int reservationId)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(reservationId);

            if (reservation is null)
            {
                return NotFound();
            }
            var reservationDto = _mapper.Map<ReservationDTO>(reservation);

            return Ok(reservationDto);
        }
        [Authorize]
        [HttpPost("CreateReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationDTO reservationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newReservation = _mapper.Map<ReservationDomain>(reservationDto);

            await _reservationService.CreateReservationAsync(newReservation);
            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateReservation/{reservationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateReservation(int reservationId, [FromBody] ReservationDTO reservationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingReservation = await _reservationService.GetReservationByIdAsync(reservationId);

            if (existingReservation is null)
            {
                return NotFound();
            }
            try
            {
                var updatedReservation = _mapper.Map<ReservationDomain>(reservationDto);

                updatedReservation.ReservationId = reservationId;
                await _reservationService.UpdateReservationAsync(updatedReservation);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize]
        [HttpDelete("DeleteReservation/{reservationId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            var existingReservation = await _reservationService.GetReservationByIdAsync(reservationId);

            if (existingReservation is null)
            {
                return NotFound();
            }
            await _reservationService.DeleteReservationAsync(reservationId);
            return NoContent();
        }
        [Authorize]
        [HttpGet("Customer/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReservationsByCustomerAsync(int customerId)
        {
            var existingReservations = await _reservationService.GetReservationsByCustomerAsync(customerId);

            if (existingReservations is null)
            {
                return NotFound();
            }
            return Ok(existingReservations);
        }
        [Authorize]
        [HttpGet("{reservationId}/orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrdersForReservation(int reservationId)
        {
            try
            {
                var orders = await _reservationService.GetOrdersForReservation(reservationId);

                if (orders is null)
                {
                    return NotFound($"No orders found for reservation with ID {reservationId}.");
                }
                var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);

                return Ok(orderDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [Authorize]
        [HttpGet("{reservationId}/menu-items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMenuItemsForReservation(int reservationId)
        {
            try
            {
                var menuItems = await _reservationService.GetMenuItemsForReservationAsync(reservationId);

                if (menuItems is null || !menuItems.Any())
                {
                    return NotFound($"No menu items found for reservation with ID {reservationId}.");
                }
                var menuItemDTOs = _mapper.Map<IEnumerable<MenuItemDTO>>(menuItems);

                return Ok(menuItemDTOs.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}