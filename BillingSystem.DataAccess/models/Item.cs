using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace model.models
{

    [Index(nameof(Name), IsUnique = true)]
    public class Item
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public string? Note { get; set; }
        public int AvailableQyantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Selling Price must be greater than or equal to 0")]
        public int BuyingPrice { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Selling Price must be greater than or equal to 0")]
        public int SellingPrice { get; set; }
        public int TypeId { get; set; }
        public int CompanyId { get; set; }
        public int UnitId { get; set; }
        public virtual Company? Company { get; set; }
        public virtual Unit? Unit { get; set; }
        public virtual model.models.Type? Type { get; set; }
        public virtual List<ItemInvoice>? ItemInvoices { get; set; }

    }
}
