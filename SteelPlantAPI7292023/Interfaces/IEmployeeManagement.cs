using SteelPlantAPI7292023.Models;

namespace SteelPlantAPI7292023.Interfaces
{
    public interface IEmployeeManagement
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task RemoveEmployeeAsync(int id);
        Task EditEmployeeAsync(Employee employee, int Id);
        Task AddEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeAsync(int id);
    }

}
