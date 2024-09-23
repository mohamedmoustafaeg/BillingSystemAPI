using Billing_System.BuissnessLogic.DTO.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System.BuissnessLogic.Interfaces
{
    public interface IItemService
    {
        public void Add(ItemToAddDto item);
        public List<ItemToReturnDto> GetAll();
        public ItemToReturnDto GetById(int id);
        public void Edit(int id, ItemToAddDto item);
        public void DeleteById(int id);
    }
}
