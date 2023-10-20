using RestaurantReservation.Business.DomainClass;

namespace RestaurantReservation.Business.IRepository
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