using Dapper;
using Microsoft.Data.SqlClient;
using SteelPlantAPI7292023.Interfaces;
using SteelPlantAPI7292023.Models;
using System.Data.Common;
using System.Threading.Tasks;

namespace SteelPlantAPI7292023.Services
{
    public class EmployeeManagement : IEmployeeManagement
    {
        private readonly string _connectionString;

        public EmployeeManagement(string connectionString = "Server=.; Database=SteelPlant; Trusted_Connection=Yes; Encrypt=Optional")
        {
            _connectionString = connectionString;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            {
                var sqlcode = "SELECT * FROM Employees";
                var employees = await connection.QueryAsync<Employee>(sqlcode);
                return employees.ToList();
            }
        }

    
        public async Task RemoveEmployeeAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            {
                var sqlcode = "DELETE FROM Employees WHERE Id = @id";
                await connection.ExecuteAsync(sqlcode, new { id });
            }
        }

        public async Task EditEmployeeAsync(Employee employee, int id)
        {
            using var connection = new SqlConnection(_connectionString);
            {
                var sqlcode = "UPDATE Employees " +
                    "SET FirstName = @FirstName, LastName = @LastName, Position = @Position, Wage = @Wage, WorkExp = @WorkExp WHERE Id = @id";
                await connection.ExecuteAsync(sqlcode, new { employee.FirstName, employee.LastName, Position = (int)employee.Position, employee.Wage, employee.WorkExp, id });
            }
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            using var connection = new SqlConnection(_connectionString);
            {
                var sqlcode = "INSERT INTO Employees (FirstName, LastName, Position, Wage, WorkExp) VALUES (@FirstName,@LastName,@Position,@Wage,@WorkExp)";
                await connection.ExecuteAsync(sqlcode,employee);
            }
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            {
                var sqlcode = "SELECT * FROM Employees WHERE Id = @id";
                var employee = await connection.QueryFirstOrDefaultAsync<Employee>(sqlcode, new { id });
                return employee;
            }
        }

    }
}
