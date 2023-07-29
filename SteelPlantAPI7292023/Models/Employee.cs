using SteelPlantAPI7292023.Enums;
using System.ComponentModel.DataAnnotations;

namespace SteelPlantAPI7292023.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
        [Required]
        public Position Position { get; set; }
        [Required]
        [Range(0, 1000000)]
        public int Wage { get; set; }
        public string? WorkExp { get; set; }
    }
}
