using System.ComponentModel.DataAnnotations;

namespace Billing_System.BuissnessLogic.DTO.Client
{
    public class ClientToAddDTO
    {

        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [Length(11, 11)]
        public string PhoneNumber { get; set; }
        public int Number { get; set; }
    }
}
