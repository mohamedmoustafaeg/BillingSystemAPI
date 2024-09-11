using Billing_System.BuissnessLogic.DTO.Client;
using Billing_System.BuissnessLogic.DTO.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System.BuissnessLogic.Interfaces
{
    public interface ITypeService
    {
        void Add(TypeToAddDTO type);
        List<TypeToReturnDTO> GetAll();
        TypeToReturnDTO GetById(int id);
        void DeleteById(int id);
        void Edit(int id, TypeToAddDTO type);
    }
}
