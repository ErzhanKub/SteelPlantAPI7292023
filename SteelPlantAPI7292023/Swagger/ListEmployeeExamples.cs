using SteelPlantAPI7292023.Models;
using Swashbuckle.AspNetCore.Filters;

namespace SteelPlantAPI7292023.Swagger
{
    public class ListEmployeeExamples : IExamplesProvider<List<Employee>>
    {
        public List<Employee> GetExamples()
        {
            return new List<Employee>
            {
              new Employee
              {
                FirstName = "Erzhan",
                LastName = "Kubancbek",
                Position = Enums.Position.Mechanic,
                Wage = 10,
                WorkExp = "10"
              },
              new Employee
              {
                FirstName = "Name",
                LastName = "LastName",
                Position = Enums.Position.Distributor,
                Wage = 1000,
                WorkExp = "13"
              }
            };

        }
    }
}
