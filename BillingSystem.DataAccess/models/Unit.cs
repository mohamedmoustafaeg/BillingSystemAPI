using System.ComponentModel.DataAnnotations;

namespace model.models
{
    public class Unit
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual List<Item>? Items { get; set; }
    }
}
