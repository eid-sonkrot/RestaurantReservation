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
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly OrderService _orderService;

        public OrderController(IMapper mapper, OrderService orderService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
        [Authorize]
        [HttpGet("Orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            var orderDTOs = _mapper.Map<IEnumerable<OrderDTO>>(orders);

            return Ok(orderDTOs);
        }
        [Authorize]
        [HttpGet("GetOrderById/{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);

            if (order is null)
            {
                return NotFound();
            }
            var orderDto = _mapper.Map<OrderDTO>(order);

            return Ok(orderDto);
        }
        [Authorize]
        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDTO orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newOrder = _mapper.Map<OrderDomain>(orderDto);

            await _orderService.CreateOrderAsync(newOrder);
            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateOrder/{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] OrderDTO orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingOrder = await _orderService.GetOrderByIdAsync(orderId);

            if (existingOrder is null)
            {
                return NotFound();
            }
            try
            {
                var updatedOrder = _mapper.Map<OrderDomain>(orderDto);

                updatedOrder.OrderId = orderId;
                await _orderService.UpdateOrderAsync(updatedOrder);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize]
        [HttpDelete("CancelOrder/{orderId}")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var existingOrder = await _orderService.GetOrderByIdAsync(orderId);

            if (existingOrder is null)
            {
                return NotFound();
            }
            await _orderService.DeleteOrderAsync(orderId);
            return NoContent();
        }
    }
}