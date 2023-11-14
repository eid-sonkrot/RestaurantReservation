using RestaurantReservation.Domain.Domain;

namespace RestaurantReservation.Domain.IRepository
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDomain> GetEmployeeByIdAsync(int employeeId);
        Task CreateEmployeeAsync(EmployeeDomain employee);
        Task UpdateEmployeeAsync(EmployeeDomain employee);
        Task DeleteEmployeeAsync(int employeeId);
        Task<List<EmployeeDomain>> GetAllEmployeesAsync();
        Task<List<EmployeeDomain>> ListManagersAsync();
        Task<double> CalculateAverageOrderAmountAsync(int employeeId);
    }
}
