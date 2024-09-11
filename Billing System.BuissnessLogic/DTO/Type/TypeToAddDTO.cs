using System.ComponentModel.DataAnnotations;

namespace Billing_System.BuissnessLogic.DTO.Type
{
    public class TypeToAddDTO
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Note { get; set; }
        public int companyId { get; set; }
    }
}
