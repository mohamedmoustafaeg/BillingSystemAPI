using System.ComponentModel.DataAnnotations;

namespace Billing_System.BuissnessLogic.DTO.Employee
{
    public class EmployeeToAddDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime? Date { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
    }
}
