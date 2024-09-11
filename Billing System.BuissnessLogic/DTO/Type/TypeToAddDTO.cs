using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System.BuissnessLogic.DTO.Type
{
    public class TypeToAddDTO
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Note { get; set; }
    }
}
