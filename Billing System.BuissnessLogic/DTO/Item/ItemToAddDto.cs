using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System.BuissnessLogic.DTO.Item
{
    public class ItemToAddDto
    {
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
    }
}
