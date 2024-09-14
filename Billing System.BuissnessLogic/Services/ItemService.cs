using Billing_System.BuissnessLogic.DTO.Item;
using Billing_System.BuissnessLogic.Interfaces;
using BillingSystem.DataAccess.Interfaces;
using model.models;

namespace Billing_System.BuissnessLogic.Services
{
    public class Itemervices : IItemService
    {
        public readonly IUnitOfWork context;
        public Itemervices(IUnitOfWork _context)
        {
            context = _context;
        }
        public void Add(ItemToAddDto item)
        {
            if (item == null)
                throw new Exception("item Cant Be Null");
            var iteminDb = context.Items.GetAll().Where(c => c.Name == item.Name).FirstOrDefault();
            if (iteminDb != null)
                throw new Exception("Items already exists in database");
            if (item.SellingPrice <= item.BuyingPrice)
                throw new Exception("selling price must be greater than buying price");
            context.Items.Add(new Item
            {
                Name = item.Name,
                Note = item.Note,
                SellingPrice = item.SellingPrice,
                BuyingPrice = item.BuyingPrice,
                AvailableQyantity = item.AvailableQyantity,
                TypeId = item.TypeId,
                UnitId = item.UnitId,
                CompanyId = item.CompanyId

            });
            context.Complete();
        }
        public List<ItemToReturnDto> GetAll()
        {
            var items = context.Items.GetAll();
            var itemstoreturn = new List<ItemToReturnDto>();
            foreach (var item in items)
            {
                itemstoreturn.Add(new ItemToReturnDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Note = item.Note,
                    SellingPrice = item.SellingPrice,
                    BuyingPrice = item.BuyingPrice,
                    AvailableQyantity = item.AvailableQyantity,
                    TypeId = item.TypeId,
                    UnitId = item.TypeId,
                    CompanyId = item.TypeId
                }
                    );
            }
            return itemstoreturn;
        }
        public ItemToReturnDto GetById(int id)
        {
            var item = context.Items.GetById(id);
            if (item == null)
                throw new Exception("this item is not found please enter a valid Item");
            var itemtoreturn = new ItemToReturnDto
            {
                Id = item.Id,
                Name = item.Name,
                Note = item.Note,
                SellingPrice = item.SellingPrice,
                BuyingPrice = item.BuyingPrice,
                AvailableQyantity = item.AvailableQyantity,
                TypeId = item.TypeId,
                UnitId = item.UnitId,
                CompanyId = item.CompanyId
            };
            return itemtoreturn;
        }
    }
}
