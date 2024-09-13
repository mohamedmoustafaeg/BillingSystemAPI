using Billing_System.BuissnessLogic.DTO.Client;
using Billing_System.BuissnessLogic.DTO.Type;
using Billing_System.BuissnessLogic.DTO.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Billing_System.BuissnessLogic.Interfaces
{
    public interface IUnitService
    {
        void Add(UnitToAddDTO unitDto);
        List<UnitToReturnDTO> GetAll();
        UnitToReturnDTO GetById(int id);
        void DeleteById(int id);
        void Edit(int id, UnitToAddDTO unitDto);
        
    }
}
