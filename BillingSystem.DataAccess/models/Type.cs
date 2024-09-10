using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace model.models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Type
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public string? Note { get; set; }
        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public virtual List<Item>? Items { get; set; }
    }
}
