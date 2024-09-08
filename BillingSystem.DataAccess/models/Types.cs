using System.ComponentModel.DataAnnotations.Schema;

namespace model.models
{
    public class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Note { get; set; }
        
        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}
