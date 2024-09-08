using System.ComponentModel.DataAnnotations;

namespace model.models
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime? Date { get; set; }
        public TimeOnly? StartTime { get; set; }

        public TimeOnly? EndTime { get; set; }
        public virtual List<Invoice>? Invoices { get; set; }
    }
}