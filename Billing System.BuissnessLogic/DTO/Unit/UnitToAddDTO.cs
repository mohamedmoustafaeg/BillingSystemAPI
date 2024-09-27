using System.ComponentModel.DataAnnotations;

namespace Billing_System.BuissnessLogic.DTO.Unit
{
    public class UnitToAddDTO
    {
        [Required(ErrorMessage = "UNIT NAME is required.")]
        [StringLength(100, ErrorMessage = "UNIT NAME cannot exceed 100 characters.")]
        public string Name { get; set; }
        public string? Notes { get; set; }
    }
}
