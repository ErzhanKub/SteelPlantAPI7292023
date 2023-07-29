using SteelPlantAPI7292023.Models;
using Swashbuckle.AspNetCore.Filters;

namespace SteelPlantAPI7292023.Swagger
{
    public class EmployeeExamples : IExamplesProvider<Employee>
    {
        public Employee GetExamples()
        {
            return new Employee
            {
                FirstName = "Erzhan",
                LastName = "Kubancbek",
                Position = Enums.Position.Mechanic,
                Wage = 10,
                WorkExp = "10"
            };
        }
    }
}
