using AutoMapper;
using RestaurantReservation.Business.DomainClass;
using RestaurantReservation.Business.IRepository;
using Serilog;

namespace RestaurantReservation.Business.ServiceClass
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDomain> GetEmployeeByIdAsync(int employeeId)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

                Log.Information("Employee {EmployeeId} retrieved successfully", employeeId);
                return employee;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching employee with ID: {EmployeeId}", employeeId);
                throw;
            }
        }
        public async Task CreateEmployeeAsync(EmployeeDomain employee)
        {
            try
            {
                await _employeeRepository.CreateEmployeeAsync(employee);

                Log.Information("Employee {EmployeeId} created successfully", employee.EmployeeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while creating employee");
                throw;
            }
        }
        public async Task UpdateEmployeeAsync(EmployeeDomain employee)
        {
            try
            {
                await _employeeRepository.UpdateEmployeeAsync(employee);

                Log.Information("Employee {EmployeeId} updated successfully", employee.EmployeeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while updating employee with ID: {EmployeeId}", employee.EmployeeId);
                throw;
            }
        }
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                await _employeeRepository.DeleteEmployeeAsync(employeeId);

                Log.Information("Employee {EmployeeId} deleted successfully", employeeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while deleting employee with ID: {EmployeeId}", employeeId);
                throw;
            }
        }
        public async Task<List<EmployeeDomain>> GetAllEmployeesAsync()
        {
            try
            {
                var employees = await _employeeRepository.GetAllEmployeesAsync();

                Log.Information("Retrieved all employees successfully");
                return employees;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while fetching all employees");
                throw;
            }
        }
        public async Task<List<EmployeeDomain>> ListManagersAsync()
        {
            try
            {
                var managers = await _employeeRepository.ListManagersAsync();

                Log.Information("Retrieved all managers successfully");
                return managers;
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
                var averageAmount = await _employeeRepository.CalculateAverageOrderAmountAsync(employeeId);

                Log.Information("Calculated average order amount for employee {EmployeeId}", employeeId);
                return averageAmount;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while calculating average order amount for employee with ID: {EmployeeId}", employeeId);
                throw;
            }
        }
    }
}