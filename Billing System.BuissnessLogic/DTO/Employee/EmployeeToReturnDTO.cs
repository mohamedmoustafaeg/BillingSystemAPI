
namespace Billing_System.BuissnessLogic.DTO.Employee
{
    public class EmployeeToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
    }
}
