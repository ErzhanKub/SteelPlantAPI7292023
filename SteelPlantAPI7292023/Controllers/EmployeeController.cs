using Microsoft.AspNetCore.Mvc;
using SteelPlantAPI7292023.Interfaces;
using SteelPlantAPI7292023.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SteelPlantAPI7292023.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManagement _employeeManagement;

        public EmployeeController(IEmployeeManagement employeeManagement)
        {
            _employeeManagement = employeeManagement;
        }

        [HttpGet]
        [SwaggerOperation("Возвращает всех работников")]
        [SwaggerResponse(200, "Запрос выполнен успешно - возвращены все работники.", typeof(IEnumerable<Employee>))]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeManagement.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Возвращает работника по id.")]
        [SwaggerResponse(200, "Запрос выполнен успешно - работник получен", typeof(Employee))]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeManagement.GetEmployeeAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [SwaggerOperation("Добовляет нового работника.")]
        [SwaggerResponse(201, "Запрос выполнен успешно - новый работник добавлен", typeof(Employee))]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            await _employeeManagement.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        [SwaggerOperation("Изменение данныз работника.")]
        [SwaggerResponse(200, "Запрос выполнен успешно - данные были изменены.", typeof(Employee))]
        public async Task<IActionResult> EditEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            await _employeeManagement.EditEmployeeAsync(employee,id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Удаление работника.")]
        [SwaggerResponse(200, "Запрос выполнен успешно - работник удален.", typeof(Employee))]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await _employeeManagement.RemoveEmployeeAsync(id);
            return NoContent();
        }
    }

}
