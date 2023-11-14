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
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly EmployeeService _employeeService;

        public EmployeeController(IMapper mapper, EmployeeService employeeService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }
        [Authorize]
        [HttpGet("Employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            var employeeDTOs = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            return Ok(employeeDTOs);
        }
        [Authorize]
        [HttpGet("GetEmployeeById/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

            if (employee is null)
            {
                return NotFound();
            }

            var employeeDto = _mapper.Map<EmployeeDTO>(employee);

            return Ok(employeeDto);
        }
        [Authorize]
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newEmployee = _mapper.Map<EmployeeDomain>(employeeDto);
            await _employeeService.CreateEmployeeAsync(newEmployee);

            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateEmployee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeeDTO employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(employeeId);

            if (existingEmployee is null)
            {
                return NotFound();
            }

            try
            {
                var newEmployee = _mapper.Map<EmployeeDomain>(employeeDto);

                newEmployee.EmployeeId = employeeId;
                await _employeeService.UpdateEmployeeAsync(newEmployee);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [Authorize]
        [HttpDelete("DeleteEmployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(employeeId);

            if (existingEmployee is null)
            {
                return NotFound();
            }

            await _employeeService.DeleteEmployeeAsync(employeeId);

            return NoContent();
        }
        [Authorize]
        [HttpGet("ListManagers")]
        public async Task<IActionResult> ListManagers()
        {
            var managers = await _employeeService.ListManagersAsync();
            var managerDTOs = _mapper.Map<List<EmployeeDTO>>(managers);

            return Ok(managerDTOs); 
        }
        [Authorize]
        [HttpGet("CalculateAverageOrderAmount/{employeeId}")]
        public async Task<IActionResult> CalculateAverageOrderAmount(int employeeId)
        {
            var averageAmount = await _employeeService.CalculateAverageOrderAmountAsync(employeeId);

            return Ok(averageAmount);
        }
    }
}