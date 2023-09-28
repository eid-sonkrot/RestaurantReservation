using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.ApplicationLayer;
using RestaurantReservation.Db;
using Serilog;

namespace RestaurantReservation.Business
{
    public class EmployeeService
    {
        private readonly RestaurantReservationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(RestaurantReservationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int employeeId)
        {
            try
            {
                var employee = await _dbContext.Employees.FindAsync(employeeId);

                Log.Information("Employee {EmployeeId} retrieved successfully", employeeId);
                return _mapper.Map<EmployeeDTO>(employee);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching employee with ID: {EmployeeId}", employeeId);
                throw;
            }
        }
        public async Task CreateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            try
            {
                var newEmployee = _mapper.Map<Employee>(employeeDTO);
                _dbContext.Employees.Add(newEmployee);
                await _dbContext.SaveChangesAsync();

                Log.Information("Employee {EmployeeId} created successfully", newEmployee.employee_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating employee");
                throw;
            }
        }
        public async Task UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            try
            {
                var existingEmployee = await _dbContext.Employees.FindAsync(employeeDTO.EmployeeId);
                if (existingEmployee is not null)
                {
                    _mapper.Map(employeeDTO, existingEmployee);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("Employee {EmployeeId} updated successfully", employeeDTO.EmployeeId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating employee with ID: {EmployeeId}", employeeDTO.EmployeeId);
                throw;
            }
        }
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                var employee = await _dbContext.Employees.FindAsync(employeeId);
                if (employee is not null)
                {
                    _dbContext.Employees.Remove(employee);
                    await _dbContext.SaveChangesAsync();

                    Log.Information("Employee {EmployeeId} deleted successfully", employeeId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting employee with ID: {EmployeeId}", employeeId);
                throw;
            }
        }
        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            try
            {
                var employees = await _dbContext.Employees.ToListAsync();
                var employeeDTOs = _mapper.Map<List<EmployeeDTO>>(employees);

                Log.Information("Retrieved all employees successfully");
                return employeeDTOs;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all employees");
                throw;
            }
        }
        public async Task<List<EmployeeDTO>> ListManagersAsync()
        {
            try
            {
                var managers = await _dbContext.Employees
                    .Where(employee => employee.position == EmployeePosition.Manager)
                    .ToListAsync();

                Log.Information("Retrieved all managers successfully");
                return _mapper.Map<List<EmployeeDTO>>(managers);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching managers");
                throw;
            }
        }
        public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
        {
            try
            {
                var orders = await _dbContext.Orders
                    .Where(o => o.employee_id == employeeId)
                    .ToListAsync();

                if (orders.Any())
                {
                    var totalAmount = orders.Sum(o => o.total_amount);
                    var averageAmount = totalAmount / orders.Count;

                    return averageAmount;
                }
                else
                {
                    // Handle the case where the employee has no orders
                    return 0.0; 
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while calculating average order amount for employee {EmployeeId}", employeeId);
                throw;
            }
        }
    }
}