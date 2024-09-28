using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace model.models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Client
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [Length(11, 11)]
        public string PhoneNumber { get; set; }
        public int Number { get; set; }
        public virtual List<Invoice>? Invoices { get; set; }
    }
}