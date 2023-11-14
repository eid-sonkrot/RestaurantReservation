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
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CustomerService _customerService;

        public CustomerController(IMapper mapper, CustomerService customerService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }
        [Authorize]
        [HttpGet("Customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            var customerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(customerDTOs);
        }
        [Authorize]
        [HttpGet("GetCustomerById/{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);

            if (customer is null)
            {
                return NotFound(); 
            }
            var customerDto = _mapper.Map<CustomerDTO>(customer);

            return Ok(customerDto);
        }
        [Authorize]
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newCustomer = _mapper.Map<CustomerDomain>(customerDto);
            await _customerService.CreateCustomerAsync(newCustomer);

            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateCustomer/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingCustomer =await _customerService.GetCustomerByIdAsync(customerId);

            if (existingCustomer is null)
            {
                return NotFound(); 
            }
            try
            {
                var newCustomer = _mapper.Map<CustomerDomain>(customerDto);

                newCustomer.CustomerId = customerId;
                await _customerService.UpdateCustomerAsync(newCustomer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
            return Ok();
        }
        [Authorize]
        [HttpDelete("DeleteCustomer/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var existingCustomer = await _customerService.GetCustomerByIdAsync(customerId);

            if (existingCustomer is null)
            {
                return NotFound(); 
            }
            await _customerService.DeleteCustomerAsync(customerId);

            return NoContent(); 
        }
    }
}