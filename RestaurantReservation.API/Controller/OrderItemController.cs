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
    public class OrderItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly OrderItemService _orderItemService;

        public OrderItemController(IMapper mapper, OrderItemService orderItemService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderItemService = orderItemService ?? throw new ArgumentNullException(nameof(orderItemService));
        }
        [Authorize]
        [HttpGet("OrderItems")]
        public async Task<IActionResult> GetOrderItems()
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync();
            var orderItemDTOs = _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems);

            return Ok(orderItemDTOs);
        }
        [Authorize]
        [HttpGet("GetOrderItemById/{orderItemId}")]
        public async Task<IActionResult> GetOrderItemById(int orderItemId)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(orderItemId);

            if (orderItem is null)
            {
                return NotFound();
            }
            var orderItemDto = _mapper.Map<OrderItemDTO>(orderItem);

            return Ok(orderItemDto);
        }
        [Authorize]
        [HttpPost("AddOrderItem")]
        public async Task<IActionResult> CreateOrderItem([FromBody] OrderItemDTO orderItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newOrderItem = _mapper.Map<OrderItemDomain>(orderItemDto);

            await _orderItemService.CreateOrderItemAsync(newOrderItem);
            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateOrderItem/{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItem(int orderItemId, [FromBody] OrderItemDTO orderItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingOrderItem = await _orderItemService.GetOrderItemByIdAsync(orderItemId);

            if (existingOrderItem is null)
            {
                return NotFound();
            }
            try
            {
                var updatedOrderItem = _mapper.Map<OrderItemDomain>(orderItemDto);

                updatedOrderItem.OrderItemId = orderItemId;
                await _orderItemService.UpdateOrderItemAsync(updatedOrderItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize]
        [HttpDelete("DeleteOrderItem/{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItem(int orderItemId)
        {
            var existingOrderItem = await _orderItemService.GetOrderItemByIdAsync(orderItemId);

            if (existingOrderItem is null)
            {
                return NotFound();
            }
            await _orderItemService.DeleteOrderItemAsync(orderItemId);
            return NoContent();
        }
    }
}