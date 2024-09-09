using System.ComponentModel.DataAnnotations;

namespace Billing_System.BuissnessLogic.DTO
{
    public class CompanyToAddDTO
    {
        [MaxLength(30)]
        public string Name { get; set; }
        public string? Note { get; set; }
    }
}
